-- إنشاء قاعدة البيانات
CREATE DATABASE Sales_Mvc_Vts_2;
GO

-- استخدام قاعدة البيانات
USE Sales_Mvc_Vts_2;
GO

-- إنشاء جدول Categories
CREATE TABLE [dbo].[Categories](
    [CategoryId] [int] IDENTITY(1,1) NOT NULL,
      NOT NULL,
      NULL,
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
    (
        [CategoryId] ASC
    )
) ON [PRIMARY]
GO

-- إدخال بيانات في جدول Categories
INSERT INTO [dbo].[Categories] (Name, Description) VALUES
('Fruits', 'All types of fruits'),
('Vegetables', 'Fresh and organic vegetables'),
('Dairy', 'Milk, cheese, and other dairy products'),
('Beverages', 'Drinks including soda, juice, and water'),
('Snacks', 'Chips, cookies, and other snacks'),
('Frozen Foods', 'Frozen meals and desserts'),
('Bakery', 'Freshly baked bread and pastries'),
('Condiments', 'Sauces and seasonings for cooking');
GO

-- إنشاء جدول Customers
CREATE TABLE [dbo].[Customers](
    [CustomerID] [int] IDENTITY(1,1) NOT NULL,
      NOT NULL,
      NOT NULL,
    [Gender] [int] NOT NULL,
    [Address] [nvarchar](max) NULL,
    [Email] [nvarchar](max) NOT NULL,
    [Phone] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
    (
        [CustomerID] ASC
    )
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- إدخال بيانات في جدول Customers
INSERT INTO [dbo].[Customers] (FirstName, LastName, Gender, Address, Email, Phone) VALUES
('John', 'Doe', 1, '123 Main St', 'john.doe@example.com', '123-456-7890'),
('Jane', 'Smith', 2, '456 Elm St', 'jane.smith@example.com', '098-765-4321'),
('Alice', 'Johnson', 1, '789 Oak St', 'alice.johnson@example.com', '555-123-4567'),
('Michael', 'Brown', 1, '321 Pine St', 'michael.brown@example.com', '321-654-9870'),
('Emily', 'Davis', 2, '654 Maple St', 'emily.davis@example.com', '987-321-6540');
GO

-- إنشاء جدول Products
CREATE TABLE [dbo].[Products](
    [ProductId] [int] IDENTITY(1,1) NOT NULL,
      NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
    [AddedOn] [datetime] NOT NULL,
    [CategoryId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
    (
        [ProductId] ASC
    )
) ON [PRIMARY]
GO

-- إدخال بيانات في جدول Products
INSERT INTO [dbo].[Products] (FullName, Price, AddedOn, CategoryId) VALUES
('Apple', 1.20, GETDATE(), 1),
('Carrot', 0.80, GETDATE(), 2),
('Milk', 1.50, GETDATE(), 3),
('Orange Juice', 2.50, GETDATE(), 4),
('Potato Chips', 1.50, GETDATE(), 5),
('Ice Cream', 3.00, GETDATE(), 6),
('Whole Wheat Bread', 2.00, GETDATE(), 7),
('Ketchup', 1.20, GETDATE(), 8);
GO

-- إنشاء جدول Invoices
CREATE TABLE [dbo].[Invoices](
    [InvoiceId] [int] IDENTITY(1,1) NOT NULL,
    [InvoiceDate] [datetime] NOT NULL,
    [CustomerId] [int] NOT NULL,
    [InvoiceDiscount] [decimal](18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Invoices] PRIMARY KEY CLUSTERED 
    (
        [InvoiceId] ASC
    )
) ON [PRIMARY]
GO

-- إدخال بيانات في جدول Invoices
INSERT INTO [dbo].[Invoices] (InvoiceDate, CustomerId, InvoiceDiscount) VALUES
(GETDATE(), 1, 0),
(GETDATE(), 2, 0),
(GETDATE(), 3, 0),
(GETDATE(), 4, 0),
(GETDATE(), 5, 0);
GO

-- إنشاء جدول InvoiceDetails
CREATE TABLE [dbo].[InvoiceDetails](
    [InvoiceDetailId] [int] IDENTITY(1,1) NOT NULL,
    [InvoiceId] [int] NOT NULL,
    [ProductId] [int] NOT NULL,
    [Quantity] [int] NOT NULL,
    [UnitPrice] [decimal](18, 2) NOT NULL,
    [Discount] [decimal](18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.InvoiceDetails] PRIMARY KEY CLUSTERED 
    (
        [InvoiceDetailId] ASC
    )
) ON [PRIMARY]
GO

-- إدخال بيانات في جدول InvoiceDetails
INSERT INTO [dbo].[InvoiceDetails] (InvoiceId, ProductId, Quantity, UnitPrice, Discount) VALUES
(1, 1, 3, 2.50, 0),  -- 3 Orange Juices
(1, 4, 1, 2.00, 0),  -- 1 Whole Wheat Bread
(2, 2, 5, 1.50, 0),  -- 5 Potato Chips
(3, 3, 2, 3.00, 0),  -- 2 Ice Creams
(4, 5, 1, 1.20, 0),  -- 1 Ketchup
(5, 6, 10, 1.00, 0); -- 10 Colas
GO

-- إنشاء جدول Users
CREATE TABLE [dbo].[Users](
    [UserId] [int] IDENTITY(1,1) NOT NULL,
      NOT NULL,
      NOT NULL,
    [SessionExpiry] [datetime] NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
    (
        [UserId] ASC
    )
) ON [PRIMARY]
GO

-- إدخال بيانات في جدول Users
INSERT INTO [dbo].[Users] (Username, Password, SessionExpiry) VALUES
('admin', 'password123', NULL),
('user1', 'password456', NULL);
GO
