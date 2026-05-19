using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Database
{
    public static class DatabaseQueries
    {
        private static string connectionString = "Server=localhost;Database=SwissArmyKnife;Integrated Security=True;TrustServerCertificate=True;";

        #region Helper Methods

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        #endregion

        #region User Authentication

        public class UserInfo
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }
            public int RoleId { get; set; }
            public bool IsActive { get; set; }
            public string Email { get; set; }
            public DateTime? LastLogin { get; set; }
        }

        public static UserInfo AuthenticateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT u.UserId, u.Username, u.Email, u.RoleId, r.Name as RoleName, u.IsActive, u.LastLogin
                    FROM dbo.Users u
                    INNER JOIN dbo.Roles r ON u.RoleId = r.RoleId
                    WHERE u.Username = @Username AND u.PasswordHash = @PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserInfo
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                                RoleId = reader.GetInt32(3),
                                Role = reader.GetString(4),
                                IsActive = reader.GetBoolean(5),
                                LastLogin = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void UpdateLastLogin(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE dbo.Users SET LastLogin = @LastLogin WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LastLogin", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT COUNT(1) FROM dbo.Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool EmailExists(string email)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT COUNT(1) FROM dbo.Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool RegisterUser(string username, string email, string password, int roleId)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.Users (Username, PasswordHash, Email, RoleId, IsActive, CreatedAt)
                    VALUES (@Username, @PasswordHash, @Email, @RoleId, 1, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        #endregion

        #region Roles

        public static int GetRoleId(string roleName)
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

        public static List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT Name FROM dbo.Roles ORDER BY RoleId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return roles;
        }

        #endregion

        #region Audit Log

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

        public class AuditEntry
        {
            public int AuditId { get; set; }
            public int? UserId { get; set; }
            public string Username { get; set; }
            public string Action { get; set; }
            public string TargetType { get; set; }
            public string TargetId { get; set; }
            public string Details { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static List<AuditEntry> GetAuditLogs(int limit = 100)
        {
            List<AuditEntry> logs = new List<AuditEntry>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT TOP (@Limit) a.AuditId, a.UserId, u.Username, a.Action, a.TargetType, a.TargetId, a.Details, a.CreatedAt
                    FROM dbo.AuditLog a
                    LEFT JOIN dbo.Users u ON a.UserId = u.UserId
                    ORDER BY a.CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new AuditEntry
                            {
                                AuditId = reader.GetInt32(0),
                                UserId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                Username = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Action = reader.GetString(3),
                                TargetType = reader.IsDBNull(4) ? null : reader.GetString(4),
                                TargetId = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Details = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CreatedAt = reader.GetDateTime(7)
                            });
                        }
                    }
                }
            }
            return logs;
        }

        #endregion

        #region Scans

        public class ScanInfo
        {
            public int ScanId { get; set; }
            public int? UserId { get; set; }
            public string Username { get; set; }
            public string Type { get; set; }
            public string Target { get; set; }
            public string Mode { get; set; }
            public string Options { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string Status { get; set; }
            public string ResultReference { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static int InsertScan(int userId, string type, string target, string mode, string options, string status)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.Scans (UserId, Type, Target, Mode, Options, Status, StartTime, CreatedAt)
                    VALUES (@UserId, @Type, @Target, @Mode, @Options, @Status, @StartTime, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

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
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void UpdateScanStatus(int scanId, string status, DateTime? endTime = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE dbo.Scans SET Status = @Status, EndTime = @EndTime WHERE ScanId = @ScanId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@EndTime", endTime ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ScanId", scanId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<ScanInfo> GetUserScans(int userId, int daysLimit = 0)
        {
            List<ScanInfo> scans = new List<ScanInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT s.ScanId, s.UserId, u.Username, s.Type, s.Target, s.Mode, s.Options, 
                           s.StartTime, s.EndTime, s.Status, s.ResultReference, s.CreatedAt
                    FROM dbo.Scans s
                    LEFT JOIN dbo.Users u ON s.UserId = u.UserId
                    WHERE s.UserId = @UserId";

                if (daysLimit > 0)
                    query += " AND s.StartTime >= DATEADD(DAY, -@DaysLimit, GETUTCDATE())";

                query += " ORDER BY s.StartTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    if (daysLimit > 0)
                        cmd.Parameters.AddWithValue("@DaysLimit", daysLimit);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scans.Add(new ScanInfo
                            {
                                ScanId = reader.GetInt32(0),
                                UserId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                Username = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Type = reader.GetString(3),
                                Target = reader.GetString(4),
                                Mode = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Options = reader.IsDBNull(6) ? null : reader.GetString(6),
                                StartTime = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                                EndTime = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                Status = reader.GetString(9),
                                ResultReference = reader.IsDBNull(10) ? null : reader.GetString(10),
                                CreatedAt = reader.GetDateTime(11)
                            });
                        }
                    }
                }
            }
            return scans;
        }

        public static int GetUserScanCountToday(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT COUNT(1) FROM dbo.Scans 
                    WHERE UserId = @UserId AND StartTime >= DATEADD(DAY, 0, GETUTCDATE())";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static int GetUserTotalScanCount(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT COUNT(1) FROM dbo.Scans WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        #endregion

        #region Host Results

        public class HostResultInfo
        {
            public int HostResultId { get; set; }
            public int ScanId { get; set; }
            public string IpAddress { get; set; }
            public string Hostname { get; set; }
            public bool IsAlive { get; set; }
            public int? PingMs { get; set; }
            public string OsHint { get; set; }
            public DateTime ScanTime { get; set; }
        }

        public static int InsertHostResult(int scanId, string ipAddress, string hostname, bool isAlive, int? pingMs, string osHint)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.HostResults (ScanId, IpAddress, Hostname, IsAlive, PingMs, OsHint, ScanTime)
                    VALUES (@ScanId, @IpAddress, @Hostname, @IsAlive, @PingMs, @OsHint, @ScanTime);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScanId", scanId);
                    cmd.Parameters.AddWithValue("@IpAddress", ipAddress);
                    cmd.Parameters.AddWithValue("@Hostname", hostname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAlive", isAlive);
                    cmd.Parameters.AddWithValue("@PingMs", pingMs.HasValue ? (object)pingMs.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@OsHint", osHint ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ScanTime", DateTime.UtcNow);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        #endregion

        #region Port Results

        public class PortResultInfo
        {
            public int PortResultId { get; set; }
            public int HostResultId { get; set; }
            public int Port { get; set; }
            public string Protocol { get; set; }
            public string ServiceName { get; set; }
            public string Banner { get; set; }
            public int? ResponseMs { get; set; }
        }

        public static void InsertPortResult(int hostResultId, int port, string protocol, string serviceName, string banner, int? responseMs)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.PortResults (HostResultId, Port, Protocol, ServiceName, Banner, ResponseMs)
                    VALUES (@HostResultId, @Port, @Protocol, @ServiceName, @Banner, @ResponseMs)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HostResultId", hostResultId);
                    cmd.Parameters.AddWithValue("@Port", port);
                    cmd.Parameters.AddWithValue("@Protocol", protocol);
                    cmd.Parameters.AddWithValue("@ServiceName", serviceName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Banner", banner ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponseMs", responseMs.HasValue ? (object)responseMs.Value : DBNull.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Web Audit Results

        public class WebAuditInfo
        {
            public int WebAuditId { get; set; }
            public int ScanId { get; set; }
            public string Url { get; set; }
            public int? StatusCode { get; set; }
            public string Headers { get; set; }
            public string BodySnippet { get; set; }
            public string Findings { get; set; }
            public DateTime ScanTime { get; set; }
        }

        public static void InsertWebAuditResult(int scanId, string url, int? statusCode, string headers, string bodySnippet, string findings)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.WebAuditResults (ScanId, Url, StatusCode, Headers, BodySnippet, Findings, ScanTime)
                    VALUES (@ScanId, @Url, @StatusCode, @Headers, @BodySnippet, @Findings, @ScanTime)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScanId", scanId);
                    cmd.Parameters.AddWithValue("@Url", url);
                    cmd.Parameters.AddWithValue("@StatusCode", statusCode.HasValue ? (object)statusCode.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Headers", headers ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BodySnippet", bodySnippet ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Findings", findings ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ScanTime", DateTime.UtcNow);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Findings

        public class FindingInfo
        {
            public int FindingId { get; set; }
            public int ScanId { get; set; }
            public string Severity { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Remediation { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static void InsertFinding(int scanId, string severity, string category, string description, string remediation)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.Findings (ScanId, Severity, Category, Description, Remediation, CreatedAt)
                    VALUES (@ScanId, @Severity, @Category, @Description, @Remediation, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScanId", scanId);
                    cmd.Parameters.AddWithValue("@Severity", severity);
                    cmd.Parameters.AddWithValue("@Category", category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Remediation", remediation ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<FindingInfo> GetFindingsByScanId(int scanId)
        {
            List<FindingInfo> findings = new List<FindingInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT FindingId, ScanId, Severity, Category, Description, Remediation, CreatedAt FROM dbo.Findings WHERE ScanId = @ScanId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScanId", scanId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            findings.Add(new FindingInfo
                            {
                                FindingId = reader.GetInt32(0),
                                ScanId = reader.GetInt32(1),
                                Severity = reader.GetString(2),
                                Category = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Description = reader.GetString(4),
                                Remediation = reader.IsDBNull(5) ? null : reader.GetString(5),
                                CreatedAt = reader.GetDateTime(6)
                            });
                        }
                    }
                }
            }
            return findings;
        }

        #endregion

        #region Saved Configurations

        public class SavedConfigInfo
        {
            public int ConfigId { get; set; }
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Options { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static int SaveConfiguration(int userId, string name, string options)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.SavedConfigs (UserId, Name, Options, CreatedAt)
                    VALUES (@UserId, @Name, @Options, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Options", options);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<SavedConfigInfo> GetUserConfigurations(int userId)
        {
            List<SavedConfigInfo> configs = new List<SavedConfigInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT ConfigId, UserId, Name, Options, CreatedAt FROM dbo.SavedConfigs WHERE UserId = @UserId ORDER BY CreatedAt DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            configs.Add(new SavedConfigInfo
                            {
                                ConfigId = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Options = reader.GetString(3),
                                CreatedAt = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return configs;
        }

        public static void DeleteConfiguration(int configId, int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM dbo.SavedConfigs WHERE ConfigId = @ConfigId AND UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ConfigId", configId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Scheduled Scans

        public class ScheduledScanInfo
        {
            public int ScheduleId { get; set; }
            public int UserId { get; set; }
            public string Name { get; set; }
            public string ScanOptions { get; set; }
            public string CronExpression { get; set; }
            public DateTime? NextRun { get; set; }
            public bool Enabled { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static int AddScheduledScan(int userId, string name, string scanOptions, string cronExpression, DateTime? nextRun)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.ScheduledScans (UserId, Name, ScanOptions, CronExpression, NextRun, Enabled, CreatedAt)
                    VALUES (@UserId, @Name, @ScanOptions, @CronExpression, @NextRun, 1, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@ScanOptions", scanOptions);
                    cmd.Parameters.AddWithValue("@CronExpression", cronExpression ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NextRun", nextRun.HasValue ? (object)nextRun.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<ScheduledScanInfo> GetUserScheduledScans(int userId)
        {
            List<ScheduledScanInfo> schedules = new List<ScheduledScanInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT ScheduleId, UserId, Name, ScanOptions, CronExpression, NextRun, Enabled, CreatedAt FROM dbo.ScheduledScans WHERE UserId = @UserId ORDER BY NextRun";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new ScheduledScanInfo
                            {
                                ScheduleId = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                ScanOptions = reader.GetString(3),
                                CronExpression = reader.IsDBNull(4) ? null : reader.GetString(4),
                                NextRun = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                Enabled = reader.GetBoolean(6),
                                CreatedAt = reader.GetDateTime(7)
                            });
                        }
                    }
                }
            }
            return schedules;
        }

        public static void DeleteScheduledScan(int scheduleId, int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM dbo.ScheduledScans WHERE ScheduleId = @ScheduleId AND UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Reports

        public class ReportInfo
        {
            public int ReportId { get; set; }
            public int? ScanId { get; set; }
            public int? UserId { get; set; }
            public string Title { get; set; }
            public string ContentPath { get; set; }
            public string Content { get; set; }
            public string Format { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static int SaveReport(int? scanId, int? userId, string title, string contentPath, string content, string format)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO dbo.Reports (ScanId, UserId, Title, ContentPath, Content, Format, CreatedAt)
                    VALUES (@ScanId, @UserId, @Title, @ContentPath, @Content, @Format, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScanId", scanId.HasValue ? (object)scanId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", userId.HasValue ? (object)userId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@ContentPath", contentPath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Content", content ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Format", format);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<ReportInfo> GetReportsForUser(int userId, int limit = 50)
        {
            List<ReportInfo> reports = new List<ReportInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT TOP (@Limit) ReportId, ScanId, UserId, Title, ContentPath, Content, Format, CreatedAt
                    FROM dbo.Reports
                    WHERE UserId = @UserId
                    ORDER BY CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reports.Add(new ReportInfo
                            {
                                ReportId = reader.GetInt32(0),
                                ScanId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                UserId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                Title = reader.GetString(3),
                                ContentPath = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Content = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Format = reader.GetString(6),
                                CreatedAt = reader.GetDateTime(7)
                            });
                        }
                    }
                }
            }
            return reports;
        }

        #endregion

        #region Admin Functions

        public class UserManagementInfo
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public int RoleId { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? LastLogin { get; set; }
        }

        public static List<UserManagementInfo> GetAllUsers()
        {
            List<UserManagementInfo> users = new List<UserManagementInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT u.UserId, u.Username, u.Email, r.Name as Role, u.RoleId, u.IsActive, u.CreatedAt, u.LastLogin
                    FROM dbo.Users u
                    INNER JOIN dbo.Roles r ON u.RoleId = r.RoleId
                    ORDER BY u.UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserManagementInfo
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Role = reader.GetString(3),
                                RoleId = reader.GetInt32(4),
                                IsActive = reader.GetBoolean(5),
                                CreatedAt = reader.GetDateTime(6),
                                LastLogin = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                            });
                        }
                    }
                }
            }
            return users;
        }

        public static void UpdateUserRole(int userId, int roleId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE dbo.Users SET RoleId = @RoleId WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateUserStatus(int userId, bool isActive)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE dbo.Users SET IsActive = @IsActive WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteUser(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM dbo.Users WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<string, int> GetSystemStatistics()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT (SELECT COUNT(1) FROM dbo.Users) AS TotalUsers,
                           (SELECT COUNT(1) FROM dbo.Scans) AS TotalScans,
                           (SELECT COUNT(1) FROM dbo.Scans WHERE StartTime >= DATEADD(DAY, -30, GETUTCDATE())) AS ScansLast30Days,
                           (SELECT COUNT(1) FROM dbo.Findings WHERE Severity = 'High') AS HighFindings,
                           (SELECT COUNT(1) FROM dbo.Findings WHERE Severity = 'Medium') AS MediumFindings,
                           (SELECT COUNT(1) FROM dbo.Findings WHERE Severity = 'Low') AS LowFindings";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats["TotalUsers"] = reader.GetInt32(0);
                            stats["TotalScans"] = reader.GetInt32(1);
                            stats["ScansLast30Days"] = reader.GetInt32(2);
                            stats["HighFindings"] = reader.GetInt32(3);
                            stats["MediumFindings"] = reader.GetInt32(4);
                            stats["LowFindings"] = reader.GetInt32(5);
                        }
                    }
                }
            }
            return stats;
        }

        #endregion

        #region Premium User Functions
        public static int GetUserScanCountThisMonth(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT COUNT(1) FROM dbo.Scans 
            WHERE UserId = @UserId 
            AND StartTime >= DATEFROMPARTS(YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), 1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static int GetUserScanCountByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT COUNT(1) FROM dbo.Scans 
            WHERE UserId = @UserId 
            AND StartTime BETWEEN @StartDate AND @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<ScanInfo> GetUserScansByType(int userId, string scanType, int limit = 50)
        {
            List<ScanInfo> scans = new List<ScanInfo>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT TOP (@Limit) ScanId, UserId, NULL as Username, Type, Target, Mode, Options, 
                   StartTime, EndTime, Status, ResultReference, CreatedAt
            FROM dbo.Scans
            WHERE UserId = @UserId AND Type = @ScanType
            ORDER BY StartTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ScanType", scanType);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scans.Add(new ScanInfo
                            {
                                ScanId = reader.GetInt32(0),
                                UserId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                Type = reader.GetString(3),
                                Target = reader.GetString(4),
                                Mode = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Options = reader.IsDBNull(6) ? null : reader.GetString(6),
                                StartTime = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                                EndTime = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                Status = reader.GetString(9),
                                ResultReference = reader.IsDBNull(10) ? null : reader.GetString(10),
                                CreatedAt = reader.GetDateTime(11)
                            });
                        }
                    }
                }
            }
            return scans;
        }

        #endregion

        #region Role Management
        public static bool UpgradeUserToPremium(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Get PremiumUser RoleId
                int premiumRoleId = GetRoleId("PremiumUser");

                string query = "UPDATE dbo.Users SET RoleId = @RoleId WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleId", premiumRoleId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool IsUserPremium(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT COUNT(1) FROM dbo.Users u
            INNER JOIN dbo.Roles r ON u.RoleId = r.RoleId
            WHERE u.UserId = @UserId AND r.Name = 'PremiumUser'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool RequestPremiumUpgrade(int userId, string paymentMethod = null, string transactionId = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                // First check if audit log table has UpgradeRequests, or use existing AuditLog
                string query = @"
            INSERT INTO dbo.AuditLog (UserId, Action, TargetType, Details, CreatedAt)
            VALUES (@UserId, @Action, @TargetType, @Details, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    string details = $"Premium upgrade requested. Payment Method: {paymentMethod ?? "None"}, Transaction ID: {transactionId ?? "Pending"}";

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Action", "UPGRADE_REQUEST");
                    cmd.Parameters.AddWithValue("@TargetType", "Subscription");
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool ApprovePremiumUpgrade(int userId, int approvedByAdminId)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Start transaction
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update user role to Premium
                        int premiumRoleId = GetRoleId("PremiumUser");
                        string updateQuery = "UPDATE dbo.Users SET RoleId = @RoleId WHERE UserId = @UserId";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@RoleId", premiumRoleId);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Log the approval
                        string logQuery = @"
                    INSERT INTO dbo.AuditLog (UserId, Action, TargetType, TargetId, Details, CreatedAt)
                    VALUES (@UserId, @Action, @TargetType, @TargetId, @Details, @CreatedAt)";

                        using (SqlCommand cmd = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", approvedByAdminId);
                            cmd.Parameters.AddWithValue("@Action", "UPGRADE_APPROVED");
                            cmd.Parameters.AddWithValue("@TargetType", "User");
                            cmd.Parameters.AddWithValue("@TargetId", userId.ToString());
                            cmd.Parameters.AddWithValue("@Details", $"User {userId} upgraded to Premium by Admin {approvedByAdminId}");
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Upgarde Request

        public class UpgradeRequest
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public DateTime RequestDate { get; set; }
            public string PaymentMethod { get; set; }
            public string TransactionId { get; set; }
        }

        public static List<UpgradeRequest> GetUpgradeRequests()
        {
            List<UpgradeRequest> requests = new List<UpgradeRequest>();

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT a.UserId, u.Username, u.Email, a.CreatedAt, a.Details
            FROM dbo.AuditLog a
            INNER JOIN dbo.Users u ON a.UserId = u.UserId
            WHERE a.Action = 'UPGRADE_REQUEST'
            AND a.UserId NOT IN (
                SELECT UserId FROM dbo.AuditLog WHERE Action = 'UPGRADE_APPROVED'
            )
            ORDER BY a.CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UpgradeRequest request = new UpgradeRequest();
                            request.UserId = reader.GetInt32(0);
                            request.Username = reader.GetString(1);
                            request.Email = reader.IsDBNull(2) ? null : reader.GetString(2);
                            request.RequestDate = reader.GetDateTime(3);

                            string details = reader.GetString(4);
                            // Parse payment method and transaction ID from details
                            request.PaymentMethod = "Demo";
                            request.TransactionId = $"REQ_{request.RequestDate:yyyyMMddHHmmss}_{request.UserId}";

                            requests.Add(request);
                        }
                    }
                }
            }
            return requests;
        }

        #endregion
    }
}
