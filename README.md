# Swiss Army Knife — Penetration Testing Toolkit

A comprehensive .NET 8 WinForms application for authorized network and web security assessments. Combines multiple specialized tools into a unified dashboard for reconnaissance, scanning, auditing, and reporting.

---

## Overview

**Swiss Army Knife** is an integrated penetration testing platform designed for security professionals conducting authorized assessments. It provides a modern UI-driven interface for:

- **Network Scanning**: Host discovery, port scanning, banner grabbing, OS detection
- **SSH Auditing**: Service detection, algorithm auditing, CVE flagging, configuration assessment
- **Web Security Testing**: HTTP header analysis, TLS/SSL inspection, response analysis, technology fingerprinting
- **Report Management**: View, export, and manage assessment results with role-based access
- **Multi-User Support**: Premium and regular user roles with appropriate access controls

---

## Features

### 1. Network Scanner
- **CIDR range expansion** and single-host scanning
- **Top 100/1000 port lists** with custom port specification
- **Banner grabbing** and service identification
- **OS fingerprinting** from response patterns
- **Ping sweep** for fast host discovery
- **Parallel scanning** with configurable thread pools
- **CSV/TXT export** of results

### 2. SSH Scanner
- **SSH banner parsing** and version detection
- **Algorithm auditing** (KEX, encryption, MAC, host keys)
- **Known vulnerability checks** (CVE-2024-6387 regreSSHion, CVE-2023-38408, etc.)
- **OpenSSH version analysis** with remediation guidance
- **Multi-port scanning** with configurable timeout
- **Severity-based reporting** (None/Info/Low/Medium/High/Critical)

### 3. Web Security Auditor
- **HTTP Header Audit**: Security header presence/validation (HSTS, CSP, X-Frame-Options, etc.)
- **TLS/SSL Inspector**: Certificate validation, protocol version detection, cipher strength analysis
- **HTTP Response Analysis**: Redirect chain tracking, sensitive data pattern detection (emails, IPs, API keys, private keys)
- **Technology Fingerprinting**: Web server, framework, CDN, and CMS detection
- **Multi-tab interface** for organized scanning workflows

### 4. Report Viewer
- **Role-based report access** (Regular/Premium/Admin roles)
- **Report preview and export** to text format
- **Scan metadata** (target, timestamp, tool used)
- **Filterable report list** with status tracking

### 5. User Management
- **Login/Registration system**
- **Role-based access control** (Regular User, Premium User, Admin roles)
- **Session management** with form-based transitions

---


---

## Technology Stack

- **Language**: C# 12.0
- **Framework**: .NET 8 (Windows Forms)
- **UI**: WinForms with custom dark theme
- **Async/Await**: Task-based async operations
- **Networking**: TcpClient, HttpClient, SslStream
- **Security**: RFC 4253 SSH protocol parsing, X.509 certificate inspection
- **Threading**: SemaphoreSlim for parallelization

---

## Core Components

### NetworkScanner.cs
- Performs TCP port scanning with configurable timeouts
- Implements banner grabbing for service identification
- OS fingerprinting based on response patterns
- Supports CIDR range expansion and batch scanning

### SSHScanner.cs
- Connects to SSH services and reads server banners
- Parses SSH protocol version and implementation details
- Reads SSH_MSG_KEXINIT to extract algorithm lists
- Audits for weak protocols, ciphers, and known CVEs
- Generates severity-rated findings

### WebSecurityAuditForm.cs
- Four-tab security auditing interface
- HTTP header validation against OWASP recommendations
- TLS certificate validation and expiration checking
- Response body pattern analysis (secrets detection)
- Web technology identification (CMS, framework, CDN detection)

### ReportViewerForm.cs
- Simple report display in RichTextBox
- Export capability (text format, with PDF placeholder)
- Role-based report filtering

---

## Usage

### Getting Started

1. **Build & Run**:

2. **Login/Register**:
   - First-time users create account at registration form
   - Select role during registration (Regular/Premium)
   - Login with credentials

3. **Select Tool from Dashboard**:
   - Click "Network Scanning" → NetworkScannerForm
   - Click "Web Security Audit" → WebSecurityAuditForm
   - View Reports → ReportViewerForm

### Network Scanner Example

Results display:
- **Hosts Tab**: IP, hostname, state, ping time, OS hint, open port count
- **Ports Tab**: Host:port, protocol, service name, banner, response time
- **Raw Output**: Unformatted scan log
- **Export**: CSV or TXT

### Web Security Auditor Example

### SSH Scanner Example

Results include:
- SSH protocol version (1.0, 2.0, 1.99)
- Software version (OpenSSH_9.3p1)
- Implementation (OpenSSH, Cisco, Dropbear, etc.)
- Supported algorithms (KEX, host keys, ciphers, MACs)
- Audit findings with CVE references and remediation

---

## Disclaimer

⚠️ **Authorized Use Only**

This toolkit is intended for:
- Authorized penetration testing
- Network assessments on systems you own or have written permission to test
- Educational purposes
- Security research

**Unauthorized network scanning, port scanning, or web security testing is illegal.** Ensure you have proper authorization before using any module.

---

## Report Generation & Export

### Formats Supported

- **CSV**: Tabular format for import into spreadsheets
- **TXT**: Human-readable formatted reports with summary tables
- **PDF**: Placeholder (requires additional library integration)

### Data Exported

- Scan metadata (target, timestamp, tool, duration)
- Host/port findings
- Severity levels and remediation guidance
- Algorithm/certificate details
- Technology fingerprints

---

## Security Considerations

1. **SSL/TLS Certificate Validation**: Web auditor accepts self-signed certs for testing purposes
2. **No Credential Storage**: Passwords not stored locally; implement secure database in production
3. **Output Handling**: Reports may contain sensitive findings—export with appropriate access controls
4. **Command Injection**: Web shell templates (WebShellManager) are for educational reference only; do not deploy

---

## Future Enhancements

- [ ] Database backend for persistent storage
- [ ] Multi-user collaboration and report sharing
- [ ] Scheduled scan automation
- [ ] Real-time alert notifications
- [ ] OWASP Top 10 vulnerability matching
- [ ] PDF report generation with charts
- [ ] Dark/light theme toggle
- [ ] Proxy integration (Burp, OWASP ZAP)
- [ ] Custom script execution framework

---

## License

This project is provided as-is for educational and authorized security testing purposes.

---

## Support & Contributing

For issues, feature requests, or contributions:
1. Review codebase structure in `src/`
2. Follow C# 12 / .NET 8 conventions
3. Add XML documentation comments
4. Test on Windows with .NET 8 runtime

---

## Quick Reference

| Module | Purpose | Status |
|--------|---------|--------|
| **Network Scanner** | Host discovery, port scanning, banner grabbing | ✅ Full |
| **SSH Scanner** | SSH auditing, CVE detection, algorithm analysis | ✅ Full |
| **Web Auditor** | HTTP headers, TLS, response analysis, tech fingerprint | ✅ Full |
| **Report Viewer** | View and export scan results | ✅ Basic |
| **User Management** | Role-based access control | ✅ Basic |
| **Web Shell Manager** | Educational reference only | ⚠️ Reference |

---

**Built with .NET 8 WinForms | For Authorized Security Professionals**

