# UserService – eCommerce User Management

The **UserService** is a microservice for handling **user management** in an eCommerce application.  
It provides functionality for **user registration** and **login**, built with a focus on clean architecture and maintainability.

---

## 🚀 Features
- User **registration** with validation
- User **login** with credential verification
- Built using **.NET Core** with **Clean Architecture**
- **Dapper** for lightweight and efficient data access
- **FluentValidation** for robust DTO validation
- Extensible design for future features (roles, JWT authentication, profile management, etc.)

---

## 🛠️ Tech Stack
- **.NET Core** (ASP.NET Core Web API)
- **Clean Architecture** principles
- **Dapper** – micro ORM for data persistence
- **FluentValidation** – DTO validation
- **SQL Server / PostgreSQL** (choose your DB)
- **Swagger** – API documentation (optional, but recommended)

---

## 📂 Project Structure
```plaintext
src/
 ├── Core/        # Business rules & use cases
 ├── Infrastructure/     # Dapper repositories, DB context
 ├── WebApi/             # API layer (controllers, endpoints)
 └── Tests/              # Unit and integration tests
