# Project Name

A **.NET 8** MVC web application demonstrating a multi-layered architecture with **Entity Framework Core**, **ASP.NET Core Identity**, **PostgreSQL** (via Npgsql), and **Stripe** integration for payment processing.

---
## Project Demo

Click the image below to watch the demo video:

[![Project Demo](https://img.youtube.com/vi/u_TuI90GZug/0.jpg)](https://www.youtube.com/watch?v=u_TuI90GZug)


---

## Table of Contents

- [Overview](#overview)
- [Folder and File Summaries](#folder-and-file-summaries)
  - [project_name (Main Web Project)](#project_name-main-web-project)
  - [solution_file.DataAccess](#solution_filedataaccess)
  - [solution_file.Models](#solution_filemodels)
  - [solution_file.Utility](#solution_fileutility)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Configuration](#configuration)
  - [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Features](#features)



---

## Overview

This solution showcases:

- **ASP.NET Core 8.0 MVC** for the presentation layer.
- **ASP.NET Core Identity** for user registration, login, and role management.
- **Entity Framework Core** with a repository/unit-of-work pattern for data access.
- **PostgreSQL** as the primary database (Npgsql).
- **Stripe** for payment processing.
- Separation of concerns into multiple projects:
  - **solution_file.Models** – Entities and view models
  - **solution_file.DataAccess** – Database context, repositories, and migrations
  - **solution_file.Utility** – Utility classes (e.g., EmailSender, constants, configuration helpers)
  - **project_name** – The main ASP.NET Core MVC web application

---

## Folder and File Summaries

### project_name (Main Web Project)

**Key Files/Folders:**

- **Properties\launchSettings.json**  
  Launch settings for running/debugging the project (IIS Express, https, etc.).

- **Areas\Admin\Controllers**  
  - `CategoryController.cs`  
  - `CompanyController.cs`  
  - `OrderController.cs`  
  - `ProductController.cs`  
  Controllers for administrative tasks (CRUD operations for categories, products, companies, orders).

- **Areas\Admin\Views**  
  - `Category\[Index.cshtml, Create.cshtml, Edit.cshtml, Delete.cshtml]`  
  - `Company\[Index.cshtml, Upsert.cshtml]`  
  - `Order\Index.cshtml`  
  - `Product\[Index.cshtml, Upsert.cshtml]`  
  Razor views for the admin area.

- **Areas\Customer\Controllers**  
  - `CartController.cs`  
  - `HomeController.cs`  
  Handles customer-facing endpoints, shopping cart features, product listings, checkout, etc.

- **Areas\Customer\Views**  
  - `Cart\[Index.cshtml, Summary.cshtml, OrderConfirmation.cshtml]`  
  - `Home\[Index.cshtml, Details.cshtml, Privacy.cshtml]`  
  Customer-facing UI.

- **Views\Shared**  
  - `_Layout.cshtml` – Main layout for the site.  
  - `_LoginPartial.cshtml` – Partial for login/logout user display.  
  - `_Notification.cshtml` – Handles toastr notifications from TempData.  
  - `_ValidationScriptsPartial.cshtml` – Scripts for client-side validation.

- **Program.cs**  
  The main entry point that sets up the web host, services (Identity, EF Core, Stripe, etc.), and middleware.

- **appsettings.json & appsettings.Development.json**  
  Configuration files with logging levels, connection strings, and Stripe API keys.

---

### solution_file.DataAccess

This project encapsulates:

- **Data\WebAppDbContext.cs**  
  Main EF Core `DbContext` for the application, includes `DbSets` for `Category`, `Product`, `Company`, `ShoppingCart`, `OrderHeader`, `OrderDetail`, etc.  
  Seeding initial data in `OnModelCreating`.

- **Repository\**  
  - `Repository.cs` – Base generic repository for CRUD.  
  - `IRepository` – Interfaces defining the repository contracts (e.g., `ICategoryRepository`, `IProductRepository`, `ICompanyRepository`, etc.).  
  - `UnitOfWork.cs` – Central place to combine multiple repositories and `Save()` operation.  
  - Concrete repository classes like:
    - `CategoryRepository.cs`
    - `CompanyRepository.cs`
    - `ProductRepository.cs`
    - `OrderHeaderRepository.cs`
    - `OrderDetailRepository.cs`
    - `ShoppingCartRepository.cs`
    - `ApplicationUserRepository.cs`

- **Migrations\**  
  EF Core migration files (if you run `dotnet ef migrations add <name>`, they appear here).

---

### solution_file.Models

Holds domain entities and view models:

- **ApplicationUser.cs** – Extends `IdentityUser` with extra fields: `Name`, `StreetAddress`, `City`, etc.
- **Category.cs** – Entity for categories.
- **Company.cs** – Entity for companies.
- **Product.cs** – Entity for products (Title, Description, Price, etc.).
- **OrderHeader.cs & OrderDetail.cs** – Entities representing orders and their details.
- **ShoppingCart.cs** – Entity representing a user’s shopping cart items.

- **ViewModels**  
  - `ProductVM.cs` – Used for Product + Category list.  
  - `OrderVM.cs` – Used to display order headers and details together.  
  - `ShoppingCartVm.cs` – Used to display a shopping cart with an OrderHeader object.

---

### solution_file.Utility

- **SD.cs** – Static class with constants such as user roles and order/payment statuses.  
- **EmailSender.cs** – A stubbed class implementing `IEmailSender` for email logic.  
- **StripeSettings.cs** – Holds Stripe’s secret/publishable keys to be bound from `appsettings.json`.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (version 14+ recommended)
- Optional: [Visual Studio 2022 or VS Code](https://visualstudio.microsoft.com/) for development.

### Configuration

1. **Stripe Keys**  
   Update the `"Stripe"` section in `appsettings.json` with your test/production keys:
   ```json
   "Stripe": {
     "SecretKey": "your_secret_key_here",
     "PublishableKey": "your_publishable_key_here"
   }



Identity Configuration
The project uses ASP.NET Core Identity, etc.

Ensure your connection string is correct in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=yourdatabase;Username=yourusername;Password=YourPassword"
}

From the solution_file.DataAccess project directory or from the main solution root, run:

dotnet ef database update --project "solution_file.DataAccess" --startup-project "project_name"

This applies any existing migrations to your PostgreSQL database.

If you need to create new migrations (after modifying models or DbContext):

dotnet ef migrations add <MigrationName> --project "solution_file.DataAccess" --startup-project "project_name"
dotnet ef database update --project "solution_file.DataAccess" --startup-project "project_name"

Running the Application
Open the .sln file in Visual Studio (or open the folder in VS Code).
Ensure the startup project is project_name.
Press F5 (or dotnet run in a terminal within the project_name directory).
The application should launch in your browser at http://localhost:<port> or https://localhost:<port>.

Features
User Management – Register, Login, Roles (Admin, Customer, Company, Employee).
Product Management – CRUD for products, categories, companies.
Shopping Cart – Add, remove, update item quantity; displays total cost.
Stripe Payment – Checkout flow with Stripe for test/production payments.
Order Management – Admin can view orders, update status; users can place orders.
Clean Architecture – Repositories and UnitOfWork to keep concerns separated.


---









