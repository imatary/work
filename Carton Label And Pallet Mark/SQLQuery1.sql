-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Labels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Labels];
GO
IF OBJECT_ID(N'[dbo].[Parts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Labels'
CREATE TABLE [dbo].[Labels] (
    [CreatedDate] varchar(250)  NOT NULL,
    [DeliveryDate] varchar(150)  NULL,
    [FinalConsignee] nvarchar(250)  NULL,
    [Supplier] nvarchar(500)  NULL,
    [PoNo] nvarchar(250)  NULL,
    [GrossWeight] varchar(150)  NULL,
    [BoxQuantity] varchar(150)  NULL,
    [POQuantity] varchar(150)  NULL,
    [PartNo] varchar(250)  NULL,
    [CNO] varchar(150)  NULL,
    [ManufactureDate] varchar(150)  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Parts'
CREATE TABLE [dbo].[Parts] (
    [PartNoID] varchar(50)  NOT NULL,
    [PartNoValue] varchar(50)  NOT NULL,
    [Quantity] int  NULL,
    [Price] bigint  NULL,
    [Description] nvarchar(500)  NULL,
    [Weight] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Labels'
ALTER TABLE [dbo].[Labels]
ADD CONSTRAINT [PK_Labels]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PartNoID], [PartNoValue] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [PK_Parts]
    PRIMARY KEY CLUSTERED ([PartNoID], [PartNoValue] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------