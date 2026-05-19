using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SwissArmyKnife
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=SwissArmyKnife;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static void LogAudit(int userId, string action, string targetType, string targetId, string details)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.AuditLog (UserId, Action, TargetType, TargetId, Details, CreatedAt)
                    VALUES (@UserId, @Action, @TargetType, @TargetId, @Details, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId > 0 ? (object)userId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@TargetType", targetType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TargetId", targetId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Details", details ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetUserRoleId(string roleName)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT RoleId FROM dbo.Roles WHERE Name = @RoleName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleName", roleName);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? (int)result : 1;
                }
            }
        }

        public static void InsertScan(int userId, string type, string target, string mode, string options, string status)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.Scans (UserId, Type, Target, Mode, Options, Status, StartTime, CreatedAt)
                    VALUES (@UserId, @Type, @Target, @Mode, @Options, @Status, @StartTime, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId > 0 ? (object)userId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Target", target);
                    cmd.Parameters.AddWithValue("@Mode", mode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Options", options ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@StartTime", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
