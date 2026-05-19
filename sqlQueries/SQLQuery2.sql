-- Complete setup script
USE SwissArmyKnife;
GO

-- Delete existing data (if any)
DELETE FROM dbo.Users;
DELETE FROM dbo.Roles;
--TRUNCATE TABLE dbo.Roles;
GO

-- Insert Roles
INSERT INTO dbo.Roles (Name, Description) VALUES 
('Admin', 'Full system control and user management'),
('PremiumUser', 'Full access to all scanning tools and features'),
('RegularUser', 'Basic scanning tools with limited features'),
('Viewer', 'Read-only access to assigned reports'),
('ToolManager', 'Tool configuration and management');
GO

/*
-- Insert Admin User (password: admin123)
INSERT INTO dbo.Users (Username, PasswordHash, Email, RoleId, IsActive, CreatedAt) 
VALUES ('admin', 'uRgBcQmXp2s5v8y/B?E(H+MbQeThWmZq4t7w9z$C&F)J@NcRfUjXn2r5u8x!A%D*G', 'admin@swissarmyknife.com', 1, 1, GETUTCDATE());
GO
*/

-- Verify
SELECT u.Username, u.Email, r.Name as Role, u.IsActive
FROM dbo.Users u
INNER JOIN dbo.Roles r ON u.RoleId = r.RoleId;
GO

SELECT * FROM USERS;
SELECT * FROM ROLES;

