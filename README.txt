# ProductCatalogApi

ASP.NET Core Web API for managing product catalog with categories, filtering, sorting, pagination and JWT authentication.

## 🚀 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- JWT Authentication

---

## 📦 Features

- CRUD for Products
- CRUD for Categories
- Filtering
- Sorting
- Pagination
- Validation (Data Annotations / FluentValidation if used)
- JWT Authentication
- Swagger UI

---

## 🗄️ Database

Uses SQLite by default.

Connection string example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=productcatalog.db"
}