USE [master]
GO
/****** Object:  Database [DerbyPub]    Script Date: 5/30/2020 3:47:35 PM ******/
CREATE DATABASE [DerbyPub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DerbyPub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DerbyPub.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DerbyPub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DerbyPub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DerbyPub] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DerbyPub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DerbyPub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DerbyPub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DerbyPub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DerbyPub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DerbyPub] SET ARITHABORT OFF 
GO
ALTER DATABASE [DerbyPub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DerbyPub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DerbyPub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DerbyPub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DerbyPub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DerbyPub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DerbyPub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DerbyPub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DerbyPub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DerbyPub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DerbyPub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DerbyPub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DerbyPub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DerbyPub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DerbyPub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DerbyPub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DerbyPub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DerbyPub] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DerbyPub] SET  MULTI_USER 
GO
ALTER DATABASE [DerbyPub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DerbyPub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DerbyPub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DerbyPub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DerbyPub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DerbyPub] SET QUERY_STORE = OFF
GO
USE [DerbyPub]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergen](
	[AllergenID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Allergens] PRIMARY KEY CLUSTERED 
(
	[AllergenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Product]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Product](
	[Menu_ProductID] [int] IDENTITY(1,1) NOT NULL,
	[FKMenuID] [int] NOT NULL,
	[FKProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Menu_Product] PRIMARY KEY CLUSTERED 
(
	[Menu_ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Menu]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Menu](
	[FKOderID] [int] NOT NULL,
	[FKMenuID] [int] NOT NULL,
	[Order_MenuID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Order_Menu] PRIMARY KEY CLUSTERED 
(
	[Order_MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[UniqueCode] [int] NOT NULL,
	[Order_Time] [datetime] NOT NULL,
	[Estimated_Time] [datetime] NOT NULL,
	[Transport_Cost] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[Total_Price] [real] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total_Quantity] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Allergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Allergen](
	[FKProductID] [int] NOT NULL,
	[FKAllergenID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Image]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Image](
	[ProductID] [int] NOT NULL,
	[ImageID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nchar](20) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nchar](30) NOT NULL,
	[Last_Name] [nchar](30) NOT NULL,
	[Email] [nchar](30) NOT NULL,
	[Phone] [nchar](11) NOT NULL,
	[Adress] [nchar](50) NOT NULL,
	[Password] [nchar](30) NOT NULL,
	[Account_Type] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Category]
GO
ALTER TABLE [dbo].[Menu_Product]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Product_Menu] FOREIGN KEY([FKMenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[Menu_Product] CHECK CONSTRAINT [FK_Menu_Product_Menu]
GO
ALTER TABLE [dbo].[Menu_Product]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Product_Product] FOREIGN KEY([FKProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Menu_Product] CHECK CONSTRAINT [FK_Menu_Product_Product]
GO
ALTER TABLE [dbo].[Order_Menu]  WITH CHECK ADD  CONSTRAINT [FK_Order_Menu_Menu_Product] FOREIGN KEY([FKMenuID])
REFERENCES [dbo].[Menu_Product] ([Menu_ProductID])
GO
ALTER TABLE [dbo].[Order_Menu] CHECK CONSTRAINT [FK_Order_Menu_Menu_Product]
GO
ALTER TABLE [dbo].[Order_Menu]  WITH CHECK ADD  CONSTRAINT [FK_Order_Menu_Orders] FOREIGN KEY([FKOderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Menu] CHECK CONSTRAINT [FK_Order_Menu_Orders]
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Product] CHECK CONSTRAINT [FK_Order_Product_Orders]
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order_Product] CHECK CONSTRAINT [FK_Order_Product_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_State_Order] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([StateID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_State_Order]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_User_Order] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_User_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product_Allergen]  WITH CHECK ADD  CONSTRAINT [FK_Product_Allergen_Allergen] FOREIGN KEY([FKAllergenID])
REFERENCES [dbo].[Allergen] ([AllergenID])
GO
ALTER TABLE [dbo].[Product_Allergen] CHECK CONSTRAINT [FK_Product_Allergen_Allergen]
GO
ALTER TABLE [dbo].[Product_Allergen]  WITH CHECK ADD  CONSTRAINT [FK_Product_Allergen_Product] FOREIGN KEY([FKProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Allergen] CHECK CONSTRAINT [FK_Product_Allergen_Product]
GO
ALTER TABLE [dbo].[Product_Image]  WITH CHECK ADD  CONSTRAINT [FK_Product_Image_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[Product_Image] CHECK CONSTRAINT [FK_Product_Image_Image]
GO
ALTER TABLE [dbo].[Product_Image]  WITH CHECK ADD  CONSTRAINT [FK_Product_Image_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Image] CHECK CONSTRAINT [FK_Product_Image_Product]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_AccountType] FOREIGN KEY([Account_Type])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_AccountType]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAllergen]
@AllergenName nchar(50)
AS
BEGIN

declare @AllergenId int
set @AllergenId = (select Allergen.AllergenID from Allergen where Allergen.Name = @AllergenName);

declare @ProductId int
set @ProductId = (select Product.ProductID from Product 
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID and Product_Allergen.FKAllergenID = @AllergenId)

delete from Product_Allergen
where Product_Allergen.FKAllergenID = @AllergenId

declare @MenuId int
set @MenuId = (select Menu.MenuID from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu_Product.FKProductID = @ProductId)

delete from Menu_Product
where Menu_Product.FKMenuID = @MenuId

delete from Menu
where Menu.MenuID = @MenuId

delete from Product
where Product.ProductID = @ProductId

delete from Allergen
where Allergen.Name = @AllergenName
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCategory]
@CategoryName nchar(50)
AS
BEGIN

declare @CatId int
set @CatId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

delete from Product_Allergen
where Product_Allergen.FKProductID = (select Product.ProductID from Product where Product.CategoryID = @CatId) 

delete from Menu_Product
where Menu_Product.FKProductID = (select Product.ProductID from Product where Product.CategoryID = @CatId)

delete from Menu
where Menu.CategoryID = @CatId

delete from Product
where Product.CategoryID = @CatId

delete from Category
where Category.Name = @CategoryName
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMenu]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMenu]
@MenuName nchar(50)
AS
BEGIN
declare @MenuId int
set @MenuId = (select Menu.MenuID from Menu where Menu.Name = @MenuName)

delete from Menu_Product
where Menu_Product.FKMenuID = @MenuId

delete from Menu
where Menu.MenuID = @MenuId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteProduct]
@ProductName nchar(100)
AS
BEGIN
declare @ProductId int
set @ProductId = (select Product.ProductID from Product where Product.Name = @ProductName);

declare @AllergenId int
set @AllergenId = (select Allergen.AllergenID from Allergen 
join Product_Allergen on Allergen.AllergenID = Product_Allergen.FKAllergenID and Product_Allergen.FKProductID = @ProductId)

delete from Product_Allergen
where Product_Allergen.FKAllergenID = @AllergenId

declare @MenuId int
set @MenuId = (select Menu.MenuID from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu_Product.FKProductID = @ProductId)

delete from Menu_Product
where Menu_Product.FKMenuID = @MenuId

delete from Menu
where Menu.MenuID = @MenuId

delete from Product
where Product.ProductID = @ProductId

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategoryes]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCategoryes]
AS
BEGIN
	Select Category.Name from Category
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllergenFromProductName]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllergenFromProductName]
	@ProductName nchar(100)
AS
BEGIN
	select Allergen.Name from Allergen
join Product_Allergen on Allergen.AllergenID = Product_Allergen.FKAllergenID
join Product on Product_Allergen.FKProductID = Product.ProductID and Product.Name = @ProductName
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMenusBasedOnAllergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllMenusBasedOnAllergen]
@CategoryName nchar(50),
@AllergenName nchar(50)

AS
BEGIN
declare @CategoryId int
set @CategoryId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

declare @MenuName nchar(50)
set @MenuName = (
select Menu.Name from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID
join Product on Menu_Product.FKProductID = Product.ProductID
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID
join Allergen on Product_Allergen.FKAllergenID = Allergen.AllergenID
and Lower(Trim(Allergen.Name)) like '%' + Lower(Trim(@AllergenName)) + '%'
and Product.CategoryID = @CategoryId
group by Menu.Name)

select Menu.Name, sum(Product.Price) as Price from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu.Name = @MenuName
join Product on Product.ProductID = Menu_Product.FKProductID
group by Menu.Name

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMenusWithoutAnAllergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllMenusWithoutAnAllergen]
@CategoryName nchar(50),
@AllergenName nchar(50)
AS
BEGIN
declare @CategoryId int
set @CategoryId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

declare @MenuName nchar(50)
set @MenuName = (
select Menu.Name from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID
join Product on Menu_Product.FKProductID = Product.ProductID
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID
join Allergen on Product_Allergen.FKAllergenID = Allergen.AllergenID
and Lower(Trim(Allergen.Name)) not like '%' + Lower(Trim(@AllergenName)) + '%'
and Product.CategoryID = @CategoryId
group by Menu.Name)

select Menu.Name, sum(Product.Price) as Price from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu.Name = @MenuName
join Product on Product.ProductID = Menu_Product.FKProductID
group by Menu.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsWihoutAnAllergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllProductsWihoutAnAllergen]
@CategoryName nchar(50),
@AllergenName nchar(50)
AS
BEGIN
declare @categoryId int
set @categoryId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

select Product.Name, Product.Price, Product.Quantity from Product
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID
join Allergen on Allergen.AllergenID = Product_Allergen.FKAllergenID and Lower(Trim(Allergen.Name)) not like '%' + Lower(Trim(@AllergenName)) + '%'
where Product.CategoryID = @categoryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductWithAnAllergenBasedOnCategory]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllProductWithAnAllergenBasedOnCategory]
	@category nchar(20),
	@allegenName nchar(20)
AS
BEGIN
declare @categoryId int
set @categoryId = (select Category.CategoryID from Category where Category.Name = @category);

select Product.Name, Product.Price, Product.Quantity from Product
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID
join Allergen on Allergen.AllergenID = Product_Allergen.FKAllergenID and Lower(Trim(Allergen.Name)) like '%' + Lower(Trim(@allegenName)) + '%'
where Product.CategoryID = @categoryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetImagesByProductName]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetImagesByProductName]

@ProductName nchar(50)

AS
BEGIN
declare @ProductId int;
set @ProductId = (select Product.ProductID from Product where Product.Name = @ProductName);

select Image.Image from Image
join Product_Image on Image.ImageId = Product_Image.ImageID
join Product on Product.ProductID = Product_Image.ProductID and Product.ProductID = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[GetMenuByCategory]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMenuByCategory]
@CategoryName nchar(50)
AS
BEGIN
declare @CategoryId int;
set @CategoryId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

select Menu.Name, sum(Product.Price) as Price from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu.CategoryID = @CategoryId
join Product on Product.ProductID = Menu_Product.FKProductID
group by Menu.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetMenuDetails]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMenuDetails]
@MenuName nchar(50)
AS
BEGIN
declare @MenuId int;
set @MenuId = (select Menu.MenuID from Menu where menu.Name = @MenuName);

select Menu.Name, sum(Product.Price) as Price from Menu
join Menu_Product on Menu.MenuID = Menu_Product.FKMenuID and Menu.MenuID = @MenuId
join Product on Product.ProductID = Menu_Product.FKProductID
group by Menu.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetMenuDetaliesAboutOrder]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMenuDetaliesAboutOrder]
@OrderCode int 
AS
BEGIN
select Menu.Name, Count(Menu.Name) as MenuCount from Menu
join Order_Menu on Order_Menu.FKMenuID = Menu.MenuID
join Orders on Orders.OrderID = Order_Menu.FKOderID and Orders.UniqueCode = @OrderCode
group by Menu.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersFromUser]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOrdersFromUser]
@UserId int
AS
BEGIN
select Orders.Estimated_Time, Orders.Order_Time, Orders.Total_Price, Orders.UniqueCode, State.StateName
from Orders
join State on Orders.StateID = State.StateID and Orders.UserID = @UserId

END
GO
/****** Object:  StoredProcedure [dbo].[GetPriceOfMenu]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPriceOfMenu]
@MenuName nchar(50)
AS
BEGIN
declare @MenuId int
set @MenuId = ( select Menu.MenuID from Menu where Menu.Name = @MenuName);

select sum(product.price) from menu
join Menu_Product on Menu_Product.FKMenuID = Menu.MenuID and Menu.MenuID = @MenuId
join Product on Menu_Product.FKProductID = Product.ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductBasedOnAllergens]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProductBasedOnAllergens]
@CategoryName nchar(50),
@AllergenName nchar(50)
AS
BEGIN
declare @CategoryId int
set @CategoryId = (select Category.CategoryID from Category where Category.Name = @CategoryName);

select Product.Name, Product.Price, Product.Quantity from Product
join Product_Allergen on Product.ProductID = Product_Allergen.FKProductID
join Allergen on Product_Allergen.FKAllergenID = Allergen.AllergenID and Lower(Allergen.Name) like '%'+ Lower(TRIM(@AllergenName)) + '%' and Product.CategoryID = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByCategory]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByCategory]
	@CategoryName nchar(50)
AS
BEGIN
declare @id int
set	@id = ( SELECT Category.CategoryID as ID from Category where Category.Name = @CategoryName);

select * from Product where Product.CategoryID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[GetProductDetaliesAboutOrder]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProductDetaliesAboutOrder]

@OrderCode int
AS
BEGIN
select Product.Name, Count(Product.Name) as ProductCount from Product
join Order_Product on Order_Product.ProductID = Product.ProductID
join Orders on Order_Product.OrderID = Orders.OrderID and Orders.UniqueCode = @OrderCode
group by Product.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByAllergen]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProductsByAllergen]
	@AllergenName nchar(20)
AS
BEGIN
declare @AllergenID int
set @AllergenID = (Select Allergen.AllergenID from Allergen where Allergen.Name = @AllergenName);

select * from Product join Product_Allergen on Product_Allergen.FKAllergenID = @AllergenID and Product_Allergen.FKProductID = Product.ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByMenuName]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductsByMenuName]

@MenuName nchar(50)

AS
BEGIN

declare @MenuId int
set @MenuId = (select menu.MenuID from Menu where Menu.Name = @MenuName);

select Product.Name, Menu_Product.Quantity, Product.Price from product
join Menu_Product on Product.ProductID = Menu_Product.FKProductID
join Menu on Menu_Product.FKMenuID = Menu.MenuID and Menu.MenuID = 2
END
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoOrder_Menu]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertIntoOrder_Menu]
@OderId int,
@MenuId int
AS
BEGIN
insert into Order_Menu
values (@OderId,@MenuId)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoOrder_Product]    Script Date: 5/30/2020 3:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertIntoOrder_Product]
@OrderId int,
@ProductId int
AS
BEGIN
insert into Order_Product
values (@OrderId,@ProductId)
END
GO
USE [master]
GO
ALTER DATABASE [DerbyPub] SET  READ_WRITE 
GO
