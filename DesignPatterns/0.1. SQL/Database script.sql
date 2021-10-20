USE [XXXX]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storages]') AND type in (N'U'))
ALTER TABLE [dbo].[Storages] DROP CONSTRAINT IF EXISTS [FK_Storages_Warehouses_WarehouseId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storages]') AND type in (N'U'))
ALTER TABLE [dbo].[Storages] DROP CONSTRAINT IF EXISTS [FK_Storages_Products_ProductId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT IF EXISTS [FK_Products_Categories_CategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InOuts]') AND type in (N'U'))
ALTER TABLE [dbo].[InOuts] DROP CONSTRAINT IF EXISTS [FK_InOuts_Storages_StorageId]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 27/09/2021 16:34:15 ******/
DROP TABLE IF EXISTS [dbo].[Warehouses]
GO
/****** Object:  Table [dbo].[Storages]    Script Date: 27/09/2021 16:34:15 ******/
DROP TABLE IF EXISTS [dbo].[Storages]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27/09/2021 16:34:15 ******/
DROP TABLE IF EXISTS [dbo].[Products]
GO
/****** Object:  Table [dbo].[InOuts]    Script Date: 27/09/2021 16:34:15 ******/
DROP TABLE IF EXISTS [dbo].[InOuts]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27/09/2021 16:34:15 ******/
DROP TABLE IF EXISTS [dbo].[Categories]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27/09/2021 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [nvarchar](50) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InOuts]    Script Date: 27/09/2021 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InOuts](
	[InOutId] [nvarchar](50) NOT NULL,
	[InOutDate] [datetime2](7) NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsInput] [bit] NOT NULL,
	[StorageId] [nvarchar](50) NULL,
 CONSTRAINT [PK_InOuts] PRIMARY KEY CLUSTERED 
(
	[InOutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27/09/2021 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductDescription] [nvarchar](600) NULL,
	[TotalQuantity] [int] NOT NULL,
	[CategoryId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storages]    Script Date: 27/09/2021 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storages](
	[StorageId] [nvarchar](50) NOT NULL,
	[LastUpdate] [datetime2](7) NOT NULL,
	[PartialQuantity] [int] NOT NULL,
	[ProductId] [nvarchar](10) NULL,
	[WarehouseId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[StorageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 27/09/2021 16:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouses](
	[WarehouseId] [nvarchar](50) NOT NULL,
	[WarehouseName] [nvarchar](100) NOT NULL,
	[WarehouseAddress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'ASH', N'Aseo Hogar')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'ASP', N'Aseo Personal')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'GOL-01', N'Golosinassss')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'HGR', N'Hogar')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'PRF', N'Perfumería')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'SLD', N'Salud')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (N'VDJ', N'Video Juegos')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Bike44943', N'Bike name 44943', N'This is the best Bike 44943', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Bike44960', N'Bike name 44960', N'This is the best Bike 44960', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Bike55744', N'Bike name 55744', N'This is the best Bike 55744', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Bike69148', N'Bike name 69148', N'This is the best Bike 69148', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Food23148', N'Food name 23148', N'This is the best Food 23148', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Food36763', N'Food name 36763', N'This is the best Food 36763', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Food47092', N'Food name 47092', N'This is the best Food 47092', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Food56', N'Food name 56', N'This is the best Food 56', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Food58546', N'Food name 58546', N'This is the best Food 58546', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Game30187', N'Game name 30187', N'This is the best Game 30187', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Game38487', N'Game name 38487', N'This is the best Game 38487', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Game40956', N'Game name 40956', N'This is the best Game 40956', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'Game64527', N'Game name 64527', N'This is the best Game 64527', 0, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'JDM-123456', N'Jabón de mano', N'Esta es una prueba', 109, N'VDJ')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [TotalQuantity], [CategoryId]) VALUES (N'ref1', N'Lejía', N'Lejía muy fuerte', 2, N'HGR')
GO
INSERT [dbo].[Storages] ([StorageId], [LastUpdate], [PartialQuantity], [ProductId], [WarehouseId]) VALUES (N'34d3da92-07dd-48d9-b60b-99138f586db0-JDM-123456', CAST(N'2020-11-09T19:52:29.8647738' AS DateTime2), 109, N'JDM-123456', N'34d3da92-07dd-48d9-b60b-99138f586db0')
GO
INSERT [dbo].[Storages] ([StorageId], [LastUpdate], [PartialQuantity], [ProductId], [WarehouseId]) VALUES (N'a47122f3-ec27-4a12-849f-34f7a8e14266', CAST(N'2020-11-09T19:33:36.3900346' AS DateTime2), 0, N'JDM-123456', N'34d3da92-07dd-48d9-b60b-99138f586db0')
GO
INSERT [dbo].[Storages] ([StorageId], [LastUpdate], [PartialQuantity], [ProductId], [WarehouseId]) VALUES (N'e2aa71de-c8d9-487e-bd9b-aa42edc8caaa', CAST(N'2020-11-09T19:33:29.6846696' AS DateTime2), 0, N'JDM-123456', N'34d3da92-07dd-48d9-b60b-99138f586db0')
GO
INSERT [dbo].[Warehouses] ([WarehouseId], [WarehouseName], [WarehouseAddress]) VALUES (N'34d3da92-07dd-48d9-b60b-99138f586db0', N'Second Warehouse', N'4447 Dane Street, Yakima, WA 98908')
GO
INSERT [dbo].[Warehouses] ([WarehouseId], [WarehouseName], [WarehouseAddress]) VALUES (N'3b99798c-689d-424f-b7b2-920f00fbb93c', N'Main Warehouse', N'932 Pallet Street, La Grange, NY 12540')
GO
INSERT [dbo].[Warehouses] ([WarehouseId], [WarehouseName], [WarehouseAddress]) VALUES (N'd7b51d26-e221-4b47-9783-a813a6c3d1b7', N'Third Warehouse', N'3003 Arrowood Drive, Jacksonville, FL 32257')
GO
ALTER TABLE [dbo].[InOuts]  WITH CHECK ADD  CONSTRAINT [FK_InOuts_Storages_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storages] ([StorageId])
GO
ALTER TABLE [dbo].[InOuts] CHECK CONSTRAINT [FK_InOuts_Storages_StorageId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Storages]  WITH CHECK ADD  CONSTRAINT [FK_Storages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Storages] CHECK CONSTRAINT [FK_Storages_Products_ProductId]
GO
ALTER TABLE [dbo].[Storages]  WITH CHECK ADD  CONSTRAINT [FK_Storages_Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([WarehouseId])
GO
ALTER TABLE [dbo].[Storages] CHECK CONSTRAINT [FK_Storages_Warehouses_WarehouseId]
GO
