


DROP TABLE Project1.[InventoryLine], Project1.[Inventory], Project1.[OrderLine], Project1.[Order], Project1.[Customer], Project1.[Product], Project1.[Location], Project1.[User]
DROP SCHEMA Project1
GO

CREATE SCHEMA Project1
GO



/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE Project1.[User] (
    UserId INT NOT NULL IDENTITY UNIQUE,
    Username NVARCHAR(20) NOT NULL UNIQUE,
    Password NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY (UserId)
)

CREATE TABLE Project1.[Location] (
    LocationId INT NOT NULL IDENTITY UNIQUE,
    StoreNumber INT NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(10),
    Phone NVARCHAR(24) NOT NULL,
    CONSTRAINT PK_Location PRIMARY KEY (LocationId)
)

CREATE TABLE Project1.[Product] (
    ProductId INT NOT NULL IDENTITY UNIQUE,
    Name NVARCHAR(200) NOT NULL,
    BestBy DATETIME,
    UnitPrice NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY (ProductId)
)



CREATE TABLE Project1.[Customer] (
    CustomerId INT NOT NULL IDENTITY UNIQUE,
    UserId INT NOT NULL UNIQUE,
    FirstName NVARCHAR(40) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(10),
    Phone NVARCHAR(24),
    Email NVARCHAR(60) NOT NULL,
    CONSTRAINT PK_Customer PRIMARY KEY (CustomerId),
    CONSTRAINT FK_Customer_User FOREIGN KEY (UserId) REFERENCES Project1.[User]
)



CREATE TABLE Project1.[Order] (
    OrderId INT NOT NULL IDENTITY UNIQUE,
    CustomerId INT NOT NULL,
    LocationId INT NOT NULL,
    OrderTime DATETIME NOT NULL,
    OrderTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_Order PRIMARY KEY (OrderId),
    CONSTRAINT FK_Order_CustomerId FOREIGN KEY (CustomerId) REFERENCES Project1.[Customer],
    CONSTRAINT FK_Order_LocationId FOREIGN KEY (LocationId) REFERENCES Project1.[Location]
)

CREATE TABLE Project1.[OrderLine] (
    OrderLineId INT NOT NULL IDENTITY UNIQUE,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    LineTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_OrderLine PRIMARY KEY (OrderLineId),
    CONSTRAINT FK_OrderLine_Order FOREIGN KEY (OrderId) REFERENCES Project1.[Order],
    CONSTRAINT FK_OrderLine_Product FOREIGN KEY (ProductId) REFERENCES Project1.[Product]
)



CREATE TABLE Project1.[InventoryLine] (
    InventoryLineId INT NOT NULL IDENTITY UNIQUE,
    LocationId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    LineTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_InventoryLine PRIMARY KEY (InventoryLineId),
    CONSTRAINT FK_InventoryLine_Location FOREIGN KEY (LocationId) REFERENCES Project1.[Location],
    CONSTRAINT FK_InventoryLine_Product FOREIGN KEY (ProductId) REFERENCES Project1.[Product]
)



/*******************************************************************************
   Populate Tables
********************************************************************************/

INSERT INTO Project1.[User] (Username, Password) VALUES
    ('llister', 'llister'),
    ('kavalos', 'kavalos'),
    ('rfry',    'rfry'),
    ('ibailey', 'ibailey'),
    ('edrew',   'edrew');

INSERT INTO Project1.[Location] (StoreNumber, Address, City, State, Country, PostalCode, Phone) VALUES
    (1,   '123 1st Street', 'Mythopolis',       NULL, 'Hypothetican Republic', NULL, '202-555-0128'),
    (23,  '531 2nd Street', 'New Simula',       NULL, 'Hypothetican Republic', NULL, '202-555-0137'),
    (157, '529 2nd Street', 'Fantasy Heights',  NULL, 'Hypothetican Republic', NULL, '202-555-0165');

INSERT INTO Project1.[Product] (Name, BestBy, UnitPrice) VALUES
    ('Hammer', NULL, 9.99),
    ('Nails, 1 lb', NULL, 2.49),
    ('Toolbox', NULL, 49.99),
    ('Milk, 1 Gallon', '2021/3/1', 3.49),
    ('Sandwich Bread, Loaf, Sliced', '2021/3/21', 1.99),
    ('Eggs, 1 Dozen', '2021/4/1', 3.99),
    ('Roast Beef, 1 lb', '2021/4/1', 2.99),
    ('Swiss Cheese, 1 lb', '2021/5/16', 2.49),
    ('Turkey, Whole', '2021/4/1', 19.99);

INSERT INTO Project1.[Customer] (UserId, FirstName, LastName, Address, City, State, Country, PostalCode, Phone, Email) VALUES
    (1, 'Lauren', 'Lister', '101 Alpha Way',    'Fantasy Heights', NULL, 'Hypothetican Republic', NULL, NULL, 'llister@emailhost.net'),
    (2, 'Kaiser', 'Avalos', '258 Omega Blvd.',  'Mythopolis',      NULL, 'Hypothetican Republic', NULL, NULL, 'kavalos@emailhost.net'),
    (3, 'Rianne', 'Fry',    '741 Tango Ave.',   'New Simula',      NULL, 'Hypothetican Republic', NULL, NULL, 'rfry@emailhost.net'),
    (4, 'Isaac', 'Bailey',  '121 Alpha Way',    'New Simula',      NULL, 'Hypothetican Republic', NULL, NULL, 'ibailey@emailhost.net'),
    (5, 'Enzo', 'Drew',     '369 Delta Dr.',    'Fantasy Heights', NULL, 'Hypothetican Republic', NULL, NULL, 'edrew@emailhost.net');

INSERT INTO Project1.[Order] (CustomerId, LocationId, OrderTime, OrderTotal) VALUES
    (1, 2, '2021/2/21', 3.98),
    (2, 1, '2021/2/21', 12.45),
    (3, 3, '2021/2/21', 8.79),
    (4, 2, '2021/2/21', 3.99),
    (5, 3, '2021/2/21', 4.98);

INSERT INTO Project1.[OrderLine] (OrderId, ProductId, Quantity, LineTotal) VALUES
    (1, 5, 2, 3.98),
    (2, 2, 5, 12.45),
    (3, 7, 3, 8.79),
    (4, 6, 1, 3.99),
    (5, 8, 2, 4.98);

INSERT INTO Project1.InventoryLine (LocationId, ProductId, Quantity, LineTotal) VALUES
    (1, 1, 30, 299.70),
    (1, 2, 100, 249.00),
    (1, 3, 15, 749.85),
    (1, 4, 30, 104.70),
    (1, 5, 30, 59.70),
    (1, 6, 30, 119.70),
    (1, 7, 50, 149.50),
    (1, 8, 25, 62.25),
    (1, 9, 15, 299.85),
    (2, 1, 30, 299.70),
    (2, 2, 100, 249.00),
    (2, 3, 15, 749.85),
    (2, 4, 30, 104.70),
    (2, 5, 30, 59.70),
    (2, 6, 30, 119.70),
    (2, 7, 50, 149.50),
    (2, 8, 25, 62.25),
    (2, 9, 15, 299.85),
    (3, 1, 30, 299.70),
    (3, 2, 100, 249.00),
    (3, 3, 15, 749.85),
    (3, 4, 30, 104.70),
    (3, 5, 30, 59.70),
    (3, 6, 30, 119.70),
    (3, 7, 50, 149.50),
    (3, 8, 25, 62.25),
    (3, 9, 15, 299.85);