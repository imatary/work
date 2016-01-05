
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/27/2015 11:12:30
-- Generated from EDMX file: D:\Dev\Projects\Stock PMC-AC\Stock.Data\StockPMC-AC.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StockPMC-AC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employees_Departments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Departments];
GO
IF OBJECT_ID(N'[dbo].[FK_Inventories_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventories] DROP CONSTRAINT [FK_Inventories_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderExportDetails_OrderExports]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderExportDetails] DROP CONSTRAINT [FK_OrderExportDetails_OrderExports];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderExportDetails_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderExportDetails] DROP CONSTRAINT [FK_OrderExportDetails_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderImportDetails_OrderImports]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderImportDetails] DROP CONSTRAINT [FK_OrderImportDetails_OrderImports];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderImportDetails_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderImportDetails] DROP CONSTRAINT [FK_OrderImportDetails_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderImports_Suppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderImports] DROP CONSTRAINT [FK_OrderImports_Suppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionsToRoles_ControlPermissions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ControlsToRoles] DROP CONSTRAINT [FK_PermissionsToRoles_ControlPermissions];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionsToRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ControlsToRoles] DROP CONSTRAINT [FK_PermissionsToRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Colors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Colors];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_ProductGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_ProductGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Stock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Stock];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Suppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Suppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Units]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Units];
GO
IF OBJECT_ID(N'[dbo].[FK_Suppliers_Area]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_Suppliers_Area];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersToRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersToRoles] DROP CONSTRAINT [FK_UsersToRoles_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Areas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Areas];
GO
IF OBJECT_ID(N'[dbo].[Colors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colors];
GO
IF OBJECT_ID(N'[dbo].[Controls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Controls];
GO
IF OBJECT_ID(N'[dbo].[ControlsToRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ControlsToRoles];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Inventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventories];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[OrderExportDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderExportDetails];
GO
IF OBJECT_ID(N'[dbo].[OrderExports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderExports];
GO
IF OBJECT_ID(N'[dbo].[OrderImportDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderImportDetails];
GO
IF OBJECT_ID(N'[dbo].[OrderImports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderImports];
GO
IF OBJECT_ID(N'[dbo].[ProductGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductGroups];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Stock]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stock];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersToRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersToRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Areas'
CREATE TABLE [dbo].[Areas] (
    [AreaID] varchar(20)  NOT NULL,
    [AreaName] nvarchar(150)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierID] varchar(20)  NOT NULL,
    [AreaID] varchar(20)  NULL,
    [SupplierName] nvarchar(500)  NOT NULL,
    [Representatives] nvarchar(250)  NULL,
    [PhoneNumber] varchar(50)  NULL,
    [Mobile] varchar(50)  NULL,
    [Address] nvarchar(500)  NULL,
    [Email] varchar(250)  NULL,
    [AccountNumber] nvarchar(250)  NULL,
    [Bank] nvarchar(250)  NULL,
    [TaxCode] varchar(50)  NULL,
    [Fax] varchar(50)  NULL,
    [Website] varchar(250)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [UnitID] varchar(20)  NOT NULL,
    [UnitName] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'ProductGroups'
CREATE TABLE [dbo].[ProductGroups] (
    [ProductGroupID] varchar(20)  NOT NULL,
    [ProductGroupName] nvarchar(250)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [IsMain] bit  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentID] varchar(20)  NOT NULL,
    [DepartmentName] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] varchar(20)  NOT NULL,
    [DepartmentID] varchar(20)  NULL,
    [EmployeeCode] varchar(50)  NOT NULL,
    [EmployeeName] nvarchar(250)  NULL,
    [Alias] nvarchar(150)  NULL,
    [Sex] bit  NULL,
    [Address] nvarchar(250)  NULL,
    [HomeTell] varchar(20)  NULL,
    [Mobile] varchar(20)  NULL,
    [Fax] nvarchar(50)  NULL,
    [Email] nvarchar(250)  NULL,
    [Birthday] datetime  NULL,
    [Note] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [IsManagerStock] bit  NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [StockID] varchar(20)  NOT NULL,
    [EmployeeID] varchar(20)  NULL,
    [StockName] nvarchar(250)  NULL,
    [Contact] nvarchar(250)  NULL,
    [Adress] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [Telephone] varchar(20)  NULL,
    [Fax] varchar(50)  NULL,
    [Mobile] varchar(20)  NULL,
    [Manager] nvarchar(250)  NULL,
    [Description] nvarchar(500)  NULL,
    [IsActive] bit  NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] varchar(20)  NOT NULL,
    [ProductName] nvarchar(250)  NOT NULL,
    [ProductGroupID] varchar(20)  NULL,
    [StockID] varchar(20)  NULL,
    [UnitID] varchar(20)  NULL,
    [SupplierID] varchar(20)  NULL,
    [Barcode] varchar(50)  NULL,
    [Origin] nvarchar(250)  NULL,
    [TaxCode] varchar(20)  NULL,
    [Quantity] int  NULL,
    [ExpireDate] datetime  NULL,
    [Image] varbinary(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [CreatedDate] datetime  NULL,
    [ModifyDate] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [Price] bigint  NULL,
    [ColorID] int  NULL
);
GO

-- Creating table 'Colors'
CREATE TABLE [dbo].[Colors] (
    [ColorID] int IDENTITY(1,1) NOT NULL,
    [ColorName] nvarchar(50)  NULL,
    [ColorCode] nvarchar(50)  NULL,
    [Description] nvarchar(500)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'OrderImports'
CREATE TABLE [dbo].[OrderImports] (
    [OrderImportID] varchar(20)  NOT NULL,
    [SupplierID] varchar(20)  NOT NULL,
    [EmployeeID] varchar(20)  NULL,
    [ImportDate] datetime  NULL,
    [IsActive] bit  NULL,
    [Note] nvarchar(max)  NULL,
    [Price] bigint  NULL,
    [TotalMoney] bigint  NULL
);
GO

-- Creating table 'OrderImportDetails'
CREATE TABLE [dbo].[OrderImportDetails] (
    [OrderImportID] varchar(20)  NOT NULL,
    [ProductID] varchar(20)  NOT NULL,
    [Quantity] int  NULL,
    [Price] bigint  NULL,
    [IsActive] bit  NULL,
    [Total] bigint  NULL
);
GO

-- Creating table 'OrderExportDetails'
CREATE TABLE [dbo].[OrderExportDetails] (
    [OrderExportID] varchar(20)  NOT NULL,
    [ProductID] varchar(20)  NOT NULL,
    [Quantity] int  NULL,
    [Price] bigint  NULL,
    [Total] bigint  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'OrderExports'
CREATE TABLE [dbo].[OrderExports] (
    [OrderExportID] varchar(20)  NOT NULL,
    [EmployeeID] varchar(20)  NOT NULL,
    [ExportDate] datetime  NULL,
    [Price] bigint  NULL,
    [Note] nvarchar(max)  NULL,
    [CreatedExportBy] varchar(20)  NULL,
    [IsActive] bit  NULL,
    [Total] bigint  NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [InventoryDate] datetime  NOT NULL,
    [ProductID] varchar(20)  NOT NULL,
    [QuantityFirst] int  NULL,
    [QuantityImport] int  NULL,
    [QuantityExport] int  NULL,
    [QuantityInventory] int  NULL,
    [ID] uniqueidentifier  NOT NULL,
    [OrderImportID] varchar(20)  NULL
);
GO

-- Creating table 'Controls'
CREATE TABLE [dbo].[Controls] (
    [Page] varchar(50)  NOT NULL,
    [ControlID] varchar(50)  NOT NULL
);
GO

-- Creating table 'ControlsToRoles'
CREATE TABLE [dbo].[ControlsToRoles] (
    [FKRole] int  NOT NULL,
    [FKPage] varchar(50)  NOT NULL,
    [FKControlID] varchar(50)  NOT NULL,
    [Invisible] int  NOT NULL,
    [Disabled] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Password] varchar(150)  NOT NULL,
    [EmployeeID] varchar(20)  NOT NULL,
    [LastLogin] datetime  NULL,
    [Client] nvarchar(500)  NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [EmployeeName] nvarchar(250)  NULL,
    [LogDate] datetime  NULL,
    [Form] nvarchar(350)  NULL,
    [Action] nvarchar(250)  NULL,
    [ClientInfo] nvarchar(250)  NULL
);
GO

-- Creating table 'UsersToRoles'
CREATE TABLE [dbo].[UsersToRoles] (
    [Roles_RoleID] int  NOT NULL,
    [Users_UserID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AreaID] in table 'Areas'
ALTER TABLE [dbo].[Areas]
ADD CONSTRAINT [PK_Areas]
    PRIMARY KEY CLUSTERED ([AreaID] ASC);
GO

-- Creating primary key on [SupplierID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierID] ASC);
GO

-- Creating primary key on [UnitID] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([UnitID] ASC);
GO

-- Creating primary key on [ProductGroupID] in table 'ProductGroups'
ALTER TABLE [dbo].[ProductGroups]
ADD CONSTRAINT [PK_ProductGroups]
    PRIMARY KEY CLUSTERED ([ProductGroupID] ASC);
GO

-- Creating primary key on [DepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [StockID] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([StockID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [ColorID] in table 'Colors'
ALTER TABLE [dbo].[Colors]
ADD CONSTRAINT [PK_Colors]
    PRIMARY KEY CLUSTERED ([ColorID] ASC);
GO

-- Creating primary key on [OrderImportID] in table 'OrderImports'
ALTER TABLE [dbo].[OrderImports]
ADD CONSTRAINT [PK_OrderImports]
    PRIMARY KEY CLUSTERED ([OrderImportID] ASC);
GO

-- Creating primary key on [OrderImportID], [ProductID] in table 'OrderImportDetails'
ALTER TABLE [dbo].[OrderImportDetails]
ADD CONSTRAINT [PK_OrderImportDetails]
    PRIMARY KEY CLUSTERED ([OrderImportID], [ProductID] ASC);
GO

-- Creating primary key on [OrderExportID], [ProductID] in table 'OrderExportDetails'
ALTER TABLE [dbo].[OrderExportDetails]
ADD CONSTRAINT [PK_OrderExportDetails]
    PRIMARY KEY CLUSTERED ([OrderExportID], [ProductID] ASC);
GO

-- Creating primary key on [OrderExportID] in table 'OrderExports'
ALTER TABLE [dbo].[OrderExports]
ADD CONSTRAINT [PK_OrderExports]
    PRIMARY KEY CLUSTERED ([OrderExportID] ASC);
GO

-- Creating primary key on [ID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Page], [ControlID] in table 'Controls'
ALTER TABLE [dbo].[Controls]
ADD CONSTRAINT [PK_Controls]
    PRIMARY KEY CLUSTERED ([Page], [ControlID] ASC);
GO

-- Creating primary key on [FKRole], [FKPage], [FKControlID] in table 'ControlsToRoles'
ALTER TABLE [dbo].[ControlsToRoles]
ADD CONSTRAINT [PK_ControlsToRoles]
    PRIMARY KEY CLUSTERED ([FKRole], [FKPage], [FKControlID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [Id] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Roles_RoleID], [Users_UserID] in table 'UsersToRoles'
ALTER TABLE [dbo].[UsersToRoles]
ADD CONSTRAINT [PK_UsersToRoles]
    PRIMARY KEY CLUSTERED ([Roles_RoleID], [Users_UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AreaID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [FK_Suppliers_Area]
    FOREIGN KEY ([AreaID])
    REFERENCES [dbo].[Areas]
        ([AreaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Suppliers_Area'
CREATE INDEX [IX_FK_Suppliers_Area]
ON [dbo].[Suppliers]
    ([AreaID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_Departments]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_Departments'
CREATE INDEX [IX_FK_Employees_Departments]
ON [dbo].[Employees]
    ([DepartmentID]);
GO

-- Creating foreign key on [ProductGroupID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_ProductGroups]
    FOREIGN KEY ([ProductGroupID])
    REFERENCES [dbo].[ProductGroups]
        ([ProductGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_ProductGroups'
CREATE INDEX [IX_FK_Products_ProductGroups]
ON [dbo].[Products]
    ([ProductGroupID]);
GO

-- Creating foreign key on [StockID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Stock]
    FOREIGN KEY ([StockID])
    REFERENCES [dbo].[Stocks]
        ([StockID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Stock'
CREATE INDEX [IX_FK_Products_Stock]
ON [dbo].[Products]
    ([StockID]);
GO

-- Creating foreign key on [SupplierID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Suppliers]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Suppliers'
CREATE INDEX [IX_FK_Products_Suppliers]
ON [dbo].[Products]
    ([SupplierID]);
GO

-- Creating foreign key on [UnitID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Units]
    FOREIGN KEY ([UnitID])
    REFERENCES [dbo].[Units]
        ([UnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Units'
CREATE INDEX [IX_FK_Products_Units]
ON [dbo].[Products]
    ([UnitID]);
GO

-- Creating foreign key on [ColorID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Colors]
    FOREIGN KEY ([ColorID])
    REFERENCES [dbo].[Colors]
        ([ColorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Colors'
CREATE INDEX [IX_FK_Products_Colors]
ON [dbo].[Products]
    ([ColorID]);
GO

-- Creating foreign key on [EmployeeID] in table 'OrderImports'
ALTER TABLE [dbo].[OrderImports]
ADD CONSTRAINT [FK_OrderImports_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderImports_Employees'
CREATE INDEX [IX_FK_OrderImports_Employees]
ON [dbo].[OrderImports]
    ([EmployeeID]);
GO

-- Creating foreign key on [SupplierID] in table 'OrderImports'
ALTER TABLE [dbo].[OrderImports]
ADD CONSTRAINT [FK_OrderImports_Suppliers]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderImports_Suppliers'
CREATE INDEX [IX_FK_OrderImports_Suppliers]
ON [dbo].[OrderImports]
    ([SupplierID]);
GO

-- Creating foreign key on [OrderImportID] in table 'OrderImportDetails'
ALTER TABLE [dbo].[OrderImportDetails]
ADD CONSTRAINT [FK_OrderImportDetails_OrderImports]
    FOREIGN KEY ([OrderImportID])
    REFERENCES [dbo].[OrderImports]
        ([OrderImportID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'OrderImportDetails'
ALTER TABLE [dbo].[OrderImportDetails]
ADD CONSTRAINT [FK_OrderImportDetails_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderImportDetails_Products'
CREATE INDEX [IX_FK_OrderImportDetails_Products]
ON [dbo].[OrderImportDetails]
    ([ProductID]);
GO

-- Creating foreign key on [OrderExportID] in table 'OrderExportDetails'
ALTER TABLE [dbo].[OrderExportDetails]
ADD CONSTRAINT [FK_OrderExportDetails_OrderExports]
    FOREIGN KEY ([OrderExportID])
    REFERENCES [dbo].[OrderExports]
        ([OrderExportID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'OrderExportDetails'
ALTER TABLE [dbo].[OrderExportDetails]
ADD CONSTRAINT [FK_OrderExportDetails_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderExportDetails_Products'
CREATE INDEX [IX_FK_OrderExportDetails_Products]
ON [dbo].[OrderExportDetails]
    ([ProductID]);
GO

-- Creating foreign key on [ProductID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_Inventories_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Inventories_Products'
CREATE INDEX [IX_FK_Inventories_Products]
ON [dbo].[Inventories]
    ([ProductID]);
GO

-- Creating foreign key on [FKPage], [FKControlID] in table 'ControlsToRoles'
ALTER TABLE [dbo].[ControlsToRoles]
ADD CONSTRAINT [FK_PermissionsToRoles_ControlPermissions]
    FOREIGN KEY ([FKPage], [FKControlID])
    REFERENCES [dbo].[Controls]
        ([Page], [ControlID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PermissionsToRoles_ControlPermissions'
CREATE INDEX [IX_FK_PermissionsToRoles_ControlPermissions]
ON [dbo].[ControlsToRoles]
    ([FKPage], [FKControlID]);
GO

-- Creating foreign key on [FKRole] in table 'ControlsToRoles'
ALTER TABLE [dbo].[ControlsToRoles]
ADD CONSTRAINT [FK_PermissionsToRoles_Roles]
    FOREIGN KEY ([FKRole])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmployeeID] in table 'OrderExports'
ALTER TABLE [dbo].[OrderExports]
ADD CONSTRAINT [FK_OrderExports_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderExports_Employees'
CREATE INDEX [IX_FK_OrderExports_Employees]
ON [dbo].[OrderExports]
    ([EmployeeID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Employees'
CREATE INDEX [IX_FK_Users_Employees]
ON [dbo].[Users]
    ([EmployeeID]);
GO

-- Creating foreign key on [Roles_RoleID] in table 'UsersToRoles'
ALTER TABLE [dbo].[UsersToRoles]
ADD CONSTRAINT [FK_UsersToRoles_Role]
    FOREIGN KEY ([Roles_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserID] in table 'UsersToRoles'
ALTER TABLE [dbo].[UsersToRoles]
ADD CONSTRAINT [FK_UsersToRoles_User]
    FOREIGN KEY ([Users_UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersToRoles_User'
CREATE INDEX [IX_FK_UsersToRoles_User]
ON [dbo].[UsersToRoles]
    ([Users_UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------