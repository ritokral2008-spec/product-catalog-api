# 🛒 ProductCatalogApi

ASP.NET Core Web API для управления каталогом продуктов с категориями, фильтрацией и JWT-аутентификацией.

---

## 🚀 Возможности

- ASP.NET Core Web API (.NET 8)
- Clean Architecture (Domain / Application / Infrastructure / API)
- Entity Framework Core
- SQLite база данных
- Swagger / OpenAPI
- JWT Authentication

---

## 📦 Основной функционал

### 📁 Продукты (Products)
- GET — получение списка продуктов
- GET by id — получение продукта по ID
- POST — создание продукта
- PUT — обновление продукта
- DELETE — удаление продукта

### 📂 Категории (Categories)
- CRUD операции для категорий
- Связь: категория → продукты

---

## 🔍 Дополнительно

- Валидация входных данных
- Фильтрация (по категории, цене и т.д.)
- Сортировка
- Пагинация
- Защищённые эндпоинты через JWT

---

## 🔐 Аутентификация

Проект использует JWT Bearer токены.

### Регистрация

POST /api/auth/register

### Логин

POST /api/auth/login
После логина получи токен и используй его:
Authorization: Bearer <token>

---

## 🧱 Архитектура

ProductCatalogApi
│
├── ProductCatalogApi.Api # Web API слой
├── ProductCatalogApi.Application # бизнес-логика
├── ProductCatalogApi.Domain # сущности
├── ProductCatalogApi.Infrastructure # EF Core, DB, репозитории

---

## 🗄 База данных

- SQLite (`products.db`)
- EF Core Migrations

---

## ▶️ Запуск проекта

### 1. Клонирование
<<<<<<< HEAD
<<<<<<< HEAD
git clone https://github.com/ritokral2008-spec/product-catalog-api.git

### 2. Перейти в папку
cd ProductCatalogApi

### 3. Запуск
=======
```bash
=======
>>>>>>> 5115d82 (Update README.md)
git clone https://github.com/ritokral2008-spec/product-catalog-api.git

### 2. Перейти в папку
cd ProductCatalogApi

### 3. Запуск
<<<<<<< HEAD
```bash
>>>>>>> 8854772 (Create README.md)
=======
>>>>>>> 5115d82 (Update README.md)
dotnet run --project ProductCatalogApi.Api

---

## 📌 Swagger

После запуска API доступен:
https://localhost:5001/swagger

---

## 🛠 Технологии
ASP.NET Core 8
Entity Framework Core
SQLite
Swagger (Swashbuckle)
JWT Authentication
LINQ

---

## 📈 Возможные улучшения
Redis caching
Role-based authorization (Admin/User)
Docker support
Unit tests (xUnit)
Logging (Serilog)
CI/CD (GitHub Actions)

---

## 👨‍💻 Автор

**Domino**  
Junior C# / .NET Developer

GitHub: https://github.com/ritokral2008-spec

---

# 💡 Если хочешь прокачать дальше

Могу тебе сделать:
- 🔥 бейджи (build passing / .NET / license)
- 🐳 Docker README + docker-compose
- 📊 Swagger кастомизацию (красивый UI)
- 🧪 unit tests структуру
- 🚀 GitHub Actions CI pipeline

Скажи, что хочешь дальше улучшить.
