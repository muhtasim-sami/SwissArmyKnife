/*
  SQL Server (T-SQL) schema for SwissArmyKnife
  - Create tables, PKs, FKs, basic indexes
  - JSON/large text fields use NVARCHAR(MAX)
  - Adjust types/constraints to your target RDBMS as needed
*/

BEGIN TRANSACTION;
GO

-- Roles
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Roles')
CREATE TABLE dbo.Roles (
    RoleId      INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(256) NULL
);
GO

-- Users
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users')
CREATE TABLE dbo.Users (
    UserId      INT IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email       NVARCHAR(256) NULL,
    RoleId      INT NOT NULL,
    IsActive    BIT NOT NULL DEFAULT(1),
    CreatedAt   DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    LastLogin   DATETIME2 NULL,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES dbo.Roles(RoleId)
);
CREATE INDEX IX_Users_RoleId ON dbo.Users(RoleId);
GO

-- Scans
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Scans')
CREATE TABLE dbo.Scans (
    ScanId          INT IDENTITY(1,1) PRIMARY KEY,
    UserId          INT NULL,
    Type            NVARCHAR(20) NOT NULL,      -- 'Network','SSH','Web'
    Target          NVARCHAR(512) NOT NULL,
    Mode            NVARCHAR(50) NULL,
    Options         NVARCHAR(MAX) NULL,         -- JSON of ScanOptions
    StartTime       DATETIME2 NULL,
    EndTime         DATETIME2 NULL,
    Status          NVARCHAR(20) NOT NULL,      -- 'Queued','Running','Done','Cancelled','Error'
    ResultReference NVARCHAR(512) NULL,
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Scans_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE SET NULL
);
CREATE INDEX IX_Scans_UserId ON dbo.Scans(UserId);
CREATE INDEX IX_Scans_Status ON dbo.Scans(Status);
CREATE INDEX IX_Scans_StartTime ON dbo.Scans(StartTime);
GO

-- HostResults
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'HostResults')
CREATE TABLE dbo.HostResults (
    HostResultId INT IDENTITY(1,1) PRIMARY KEY,
    ScanId       INT NOT NULL,
    IpAddress    NVARCHAR(50) NOT NULL,
    Hostname     NVARCHAR(256) NULL,
    IsAlive      BIT NOT NULL,
    PingMs       INT NULL,
    OsHint       NVARCHAR(128) NULL,
    ScanTime     DATETIME2 NOT NULL,
    CONSTRAINT FK_HostResults_Scans FOREIGN KEY (ScanId) REFERENCES dbo.Scans(ScanId) ON DELETE CASCADE
);
CREATE INDEX IX_HostResults_ScanId ON dbo.HostResults(ScanId);
GO

-- PortResults
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PortResults')
CREATE TABLE dbo.PortResults (
    PortResultId INT IDENTITY(1,1) PRIMARY KEY,
    HostResultId INT NOT NULL,
    Port         INT NOT NULL,
    Protocol     NVARCHAR(10) NOT NULL,
    ServiceName  NVARCHAR(100) NULL,
    Banner       NVARCHAR(MAX) NULL,
    ResponseMs   INT NULL,
    CONSTRAINT FK_PortResults_HostResults FOREIGN KEY (HostResultId) REFERENCES dbo.HostResults(HostResultId) ON DELETE CASCADE
);
CREATE INDEX IX_PortResults_HostResultId ON dbo.PortResults(HostResultId);
CREATE INDEX IX_PortResults_Port ON dbo.PortResults(Port);
GO

-- SSHScanResults
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SSHScanResults')
CREATE TABLE dbo.SSHScanResults (
    SSHScanId        INT IDENTITY(1,1) PRIMARY KEY,
    ScanId           INT NOT NULL,
    Host             NVARCHAR(128) NOT NULL,
    Port             INT NOT NULL,
    IsOpen           BIT NOT NULL,
    Banner           NVARCHAR(MAX) NULL,
    SoftwareVersion  NVARCHAR(256) NULL,
    ProtocolVersion  NVARCHAR(50) NULL,
    Implementation   NVARCHAR(128) NULL,
    ResponseMs       INT NULL,
    OsHint           NVARCHAR(128) NULL,
    ScanTime         DATETIME2 NOT NULL,
    Findings         NVARCHAR(MAX) NULL,    -- JSON/text of audit findings
    AlgorithmLists   NVARCHAR(MAX) NULL,    -- JSON {kex:[], hostkeys:[], ciphers:[], macs:[]}
    CONSTRAINT FK_SSHScanResults_Scans FOREIGN KEY (ScanId) REFERENCES dbo.Scans(ScanId) ON DELETE CASCADE
);
CREATE INDEX IX_SSHScanResults_ScanId ON dbo.SSHScanResults(ScanId);
CREATE INDEX IX_SSHScanResults_Host_Port ON dbo.SSHScanResults(Host, Port);
GO

-- WebAuditResults
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'WebAuditResults')
CREATE TABLE dbo.WebAuditResults (
    WebAuditId  INT IDENTITY(1,1) PRIMARY KEY,
    ScanId      INT NOT NULL,
    Url         NVARCHAR(512) NOT NULL,
    StatusCode  INT NULL,
    Headers     NVARCHAR(MAX) NULL,  -- JSON/text
    BodySnippet NVARCHAR(MAX) NULL,
    Findings    NVARCHAR(MAX) NULL,  -- JSON/text
    ScanTime    DATETIME2 NOT NULL,
    CONSTRAINT FK_WebAuditResults_Scans FOREIGN KEY (ScanId) REFERENCES dbo.Scans(ScanId) ON DELETE CASCADE
);
CREATE INDEX IX_WebAuditResults_ScanId ON dbo.WebAuditResults(ScanId);
CREATE INDEX IX_WebAuditResults_Url ON dbo.WebAuditResults(Url);
GO

-- Findings (generic per-scan)
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Findings')
CREATE TABLE dbo.Findings (
    FindingId   INT IDENTITY(1,1) PRIMARY KEY,
    ScanId      INT NOT NULL,
    Severity    NVARCHAR(20) NOT NULL,
    Category    NVARCHAR(50) NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Remediation NVARCHAR(MAX) NULL,
    CreatedAt   DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Findings_Scans FOREIGN KEY (ScanId) REFERENCES dbo.Scans(ScanId) ON DELETE CASCADE
);
CREATE INDEX IX_Findings_ScanId ON dbo.Findings(ScanId);
CREATE INDEX IX_Findings_Severity ON dbo.Findings(Severity);
GO

-- Reports
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Reports')
CREATE TABLE dbo.Reports (
    ReportId    INT IDENTITY(1,1) PRIMARY KEY,
    ScanId      INT NULL,
    UserId      INT NULL,
    Title       NVARCHAR(256) NOT NULL,
    ContentPath NVARCHAR(512) NULL,    -- storage path or blob reference
    Content     NVARCHAR(MAX) NULL,    -- optional inline content
    Format      NVARCHAR(10) NOT NULL,
    CreatedAt   DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Reports_Scans FOREIGN KEY (ScanId) REFERENCES dbo.Scans(ScanId) ON DELETE SET NULL,
    CONSTRAINT FK_Reports_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE SET NULL
);
CREATE INDEX IX_Reports_ScanId ON dbo.Reports(ScanId);
CREATE INDEX IX_Reports_UserId ON dbo.Reports(UserId);
GO

-- SavedConfigs
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SavedConfigs')
CREATE TABLE dbo.SavedConfigs (
    ConfigId  INT IDENTITY(1,1) PRIMARY KEY,
    UserId    INT NOT NULL,
    Name      NVARCHAR(150) NOT NULL,
    Options   NVARCHAR(MAX) NOT NULL,  -- JSON
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_SavedConfigs_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE CASCADE
);
CREATE INDEX IX_SavedConfigs_UserId ON dbo.SavedConfigs(UserId);
GO

-- ScheduledScans
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ScheduledScans')
CREATE TABLE dbo.ScheduledScans (
    ScheduleId    INT IDENTITY(1,1) PRIMARY KEY,
    UserId        INT NOT NULL,
    Name          NVARCHAR(150) NOT NULL,
    ScanOptions   NVARCHAR(MAX) NOT NULL, -- JSON
    CronExpression NVARCHAR(128) NULL,
    NextRun       DATETIME2 NULL,
    Enabled       BIT NOT NULL DEFAULT(1),
    CreatedAt     DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_ScheduledScans_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE CASCADE
);
CREATE INDEX IX_ScheduledScans_UserId ON dbo.ScheduledScans(UserId);
CREATE INDEX IX_ScheduledScans_NextRun ON dbo.ScheduledScans(NextRun);
GO

-- ExportLogs
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ExportLogs')
CREATE TABLE dbo.ExportLogs (
    ExportId  INT IDENTITY(1,1) PRIMARY KEY,
    ReportId  INT NULL,
    UserId    INT NULL,
    Format    NVARCHAR(10) NOT NULL,
    Path      NVARCHAR(512) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_ExportLogs_Reports FOREIGN KEY (ReportId) REFERENCES dbo.Reports(ReportId) ON DELETE SET NULL,
    CONSTRAINT FK_ExportLogs_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE SET NULL
);
CREATE INDEX IX_ExportLogs_ReportId ON dbo.ExportLogs(ReportId);
CREATE INDEX IX_ExportLogs_UserId ON dbo.ExportLogs(UserId);
GO

-- AuditLog
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'AuditLog')
CREATE TABLE dbo.AuditLog (
    AuditId   INT IDENTITY(1,1) PRIMARY KEY,
    UserId    INT NULL,
    Action    NVARCHAR(100) NOT NULL,
    TargetType NVARCHAR(50) NULL,
    TargetId  NVARCHAR(100) NULL,
    Details   NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_AuditLog_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE SET NULL
);
CREATE INDEX IX_AuditLog_UserId ON dbo.AuditLog(UserId);
CREATE INDEX IX_AuditLog_CreatedAt ON dbo.AuditLog(CreatedAt);
GO

COMMIT TRANSACTION;
GO