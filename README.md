# SabayBuy - E-Commerce & POS System

SabayBuy is a school graduation project for the Software Development Major at IT Academy STEP.

It is a multi-platform system for computer shops. It connects an online shopping website with an in-store POS system, so products, orders, stock, and sales can be managed in one place.

## Project Description

SabayBuy helps computer shop owners, sellers, stock managers, and customers. Customers can browse products and place orders online. Staff can use the POS app to process in-store sales and manage orders.

## Project Structure

```text
SabayBuy/
  API/              ASP.NET Core Web API
  Core/             Entities, DTOs, interfaces, and specifications
  Infrastructure/   Database, repositories, migrations, and services
  POS/              Windows Forms POS application
  web/              Angular web application
  ssl/              Local HTTPS certificates
  docker-compose.yml
  SabayBuy.sln
```

## Technologies

- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- Redis
- Azure Storage Azurite
- Angular 20
- Windows Forms .NET Framework 4.8

## Main Features

- User login and register
- Product and category management
- Inventory and stock tracking
- Shopping cart and checkout
- Order management
- ABA PayWay payment
- Role-based access control
- Admin dashboard
- Desktop POS order system
- Real-time notification with SignalR
