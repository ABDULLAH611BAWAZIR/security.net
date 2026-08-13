
# security.net

# Secure ASP.NET Core Web API

A security-focused ASP.NET Core Web API demonstrating common web application security practices.

## Project Overview

This project demonstrates how to build a secure Web API using ASP.NET Core.

The project focuses on:

- Input validation
- JWT Authentication
- Role-Based Access Control (RBAC)
- SQL Injection prevention
- XSS protection
- Secure database access
- Security testing

## Security Features

### 1. Input Validation

User input is validated before it reaches the application logic.

Examples:

- Required fields
- String length validation
- Valid data formats
- Invalid request rejection

### 2. JWT Authentication

The application uses JSON Web Tokens (JWT) to authenticate users.

Authentication flow:

Client
↓
Login
↓
Validate credentials
↓
Generate JWT
↓
Client stores token
↓
Send token with API requests

Example:

Authorization: Bearer <JWT>

### 3. Role-Based Access Control

The application uses RBAC to control access to protected endpoints.

Available roles:

- Admin
- User

Example:

[Authorize(Roles = "Admin")]

Only users with the Admin role can access the protected endpoint.

### 4. SQL Injection Prevention

The application avoids unsafe SQL string concatenation.

Instead, Entity Framework Core and parameterized queries are used.

Unsafe approach:

SELECT * FROM Users WHERE Username = '"
+ username + "'

Secure approach:

context.Users.FirstOrDefaultAsync(
    x => x.Username == username
);

User input is treated as data rather than executable SQL.

### 5. XSS Protection

The application treats user-controlled input as untrusted data.

Protection techniques include:

- Input validation
- Proper output encoding
- Avoiding unsafe HTML rendering
- Returning structured JSON from the API

### 6. Security Testing

Security tests are included to verify the application's security controls.

Tests cover:

- Valid authentication
- Invalid authentication
- Unauthorized access
- Role-based authorization
- SQL Injection attempts
- XSS-related input
- Invalid input
- Invalid JWT

## Project Structure

SecureApi/
│
├── Controllers/
│   ├── AuthController.cs
│   └── UsersController.cs
│
├── Models/
│   ├── User.cs
│   └── LoginRequest.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Services/
│   └── TokenService.cs
│
├── Program.cs
└── appsettings.json

Tests/
└── SecurityTests.cs

## Technologies

- C#
- ASP.NET Core Web API
- Entity Framework Core
- JWT
- RBAC
- SQL
- xUnit
- Git
- GitHub

## Running the Project

Clone the repository:

git clone <repository-url>

Navigate to the project:

cd SecureApi

Restore dependencies:

dotnet restore

Run the application:

dotnet run

The API will start on the configured localhost port.

## Authentication

Send a POST request to:

POST /api/auth/login

Example request:

{
    "username": "admin",
    "password": "Admin123!"
}

The API returns a JWT.

Use the JWT in protected requests:

Authorization: Bearer <token>

## Security Demonstration

The project demonstrates the difference between:

Unauthenticated request
→ 401 Unauthorized

Authenticated user with insufficient role
→ 403 Forbidden

Authenticated user with correct role
→ 200 OK

## Vulnerabilities Identified

The project addresses common vulnerabilities including:

| Vulnerability | Risk | Mitigation |
|---|---|---|
| SQL Injection | Database manipulation | EF Core / parameterized queries |
| XSS | Script execution | Validation and output encoding |
| Broken Authorization | Unauthorized access | JWT + RBAC |
| Invalid Input | Application errors / abuse | Input validation |
| Weak Authentication | Account compromise | JWT authentication |

## How GitHub Copilot Helped

GitHub Copilot was used as a development assistant during the project.

It helped with:

- Generating code suggestions
- Creating validation logic
- Suggesting secure coding patterns
- Creating authorization logic
- Assisting with security tests
- Reviewing possible security issues

Copilot was not treated as a security authority. The resulting implementation was manually reviewed and tested.

## Security Disclaimer

This project is intended for educational purposes and demonstrates common application security practices.

Production systems require additional security controls such as:

- Secure secret management
- HTTPS
- Password hashing
- Database security
- Rate limiting
- Logging and monitoring
- CSRF protection where applicable
- Secure token storage
- Dependency vulnerability scanning

## Author

Omar Abdullah

ASP.NET Core | C# | Web API | Cybersecurity | Backend Development