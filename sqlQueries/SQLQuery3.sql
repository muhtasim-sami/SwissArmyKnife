-- Allow manual insertion of RoleId values
SET IDENTITY_INSERT dbo.Roles ON;

-- Insert with fixed RoleId values
INSERT INTO dbo.Roles (RoleId, Name, Description) VALUES 
(1, 'Admin', 'Full system control and user management'),
(2, 'PremiumUser', 'Full access to all scanning tools and features'),
(3, 'RegularUser', 'Basic scanning tools with limited features'),
(4, 'Viewer', 'Read-only access to assigned reports'),
(5, 'ToolManager', 'Tool configuration and management');

-- Turn off identity insert
SET IDENTITY_INSERT dbo.Roles OFF;

-- Now reset identity seed to 5
DBCC CHECKIDENT ('dbo.Roles', RESEED, 5);