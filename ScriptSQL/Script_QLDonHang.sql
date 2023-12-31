USE [master]
GO
/****** Object:  Database [QLDonHang]    Script Date: 12/13/2023 11:20:26 PM ******/
CREATE DATABASE [QLDonHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDonHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLDonHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLDonHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLDonHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLDonHang] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDonHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDonHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDonHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDonHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDonHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDonHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDonHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLDonHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDonHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDonHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDonHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDonHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDonHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDonHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDonHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDonHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLDonHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDonHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDonHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDonHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDonHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDonHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDonHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDonHang] SET RECOVERY FULL 
GO
ALTER DATABASE [QLDonHang] SET  MULTI_USER 
GO
ALTER DATABASE [QLDonHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDonHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDonHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDonHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLDonHang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLDonHang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLDonHang', N'ON'
GO
ALTER DATABASE [QLDonHang] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLDonHang] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLDonHang]
GO
/****** Object:  Table [dbo].[ConstructionTypes]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstructionTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryTypes]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[TotalMoney] [decimal](18, 2) NOT NULL,
	[RealRevenue] [decimal](18, 2) NOT NULL,
	[LeftMoney] [decimal](18, 2) NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialTypes]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ID] [int] IDENTITY(18,2) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[MaterialTypeID] [int] NOT NULL,
	[ConstructionTypeID] [int] NOT NULL,
	[Length] [decimal](18, 2) NOT NULL,
	[Width] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](512) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[DeliveryTypeID] [int] NOT NULL,
	[OrderDate] [varchar](150) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[TotalMoney] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[PrePayment] [decimal](18, 2) NOT NULL,
	[FinalMoney] [decimal](18, 2) NOT NULL,
	[ExportDate] [varchar](150) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Orders__3214EC2774792EF4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTypes]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](512) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/13/2023 11:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[Fullname] [nvarchar](512) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](1024) NOT NULL,
	[RoleID] [int] NOT NULL,
	[IsActive] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateUser] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Users__3214EC271849478A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[ConstructionTypes] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('') FOR [FullName]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[DeliveryTypes] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [OrderID]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [TotalMoney]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [RealRevenue]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [LeftMoney]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[Incomes] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[MaterialTypes] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [OrderID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [ProductID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [MaterialTypeID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [ConstructionTypeID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [Length]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [Width]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Code__7B5B524B]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Customer__7C4F7684]  DEFAULT ((0)) FOR [CustomerID]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Phone__7D439ABD]  DEFAULT ((0)) FOR [Phone]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Address__7E37BEF6]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__PaymentT__7F2BE32F]  DEFAULT ((0)) FOR [PaymentTypeID]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Delivery__00200768]  DEFAULT ((0)) FOR [DeliveryTypeID]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Note__02FC7413]  DEFAULT ('') FOR [Note]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__TotalMon__03F0984C]  DEFAULT ((0)) FOR [TotalMoney]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__VAT__04E4BC85]  DEFAULT ((0)) FOR [VAT]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__PrePayme__05D8E0BE]  DEFAULT ((0)) FOR [PrePayment]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__FinalMon__06CD04F7]  DEFAULT ((0)) FOR [FinalMoney]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__ExportDa__07C12930]  DEFAULT ('') FOR [ExportDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__IsDelete__08B54D69]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__CreateUs__09A971A2]  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__CreateDa__0A9D95DB]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__UpdateUs__0B91BA14]  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__UpdateDa__0C85DE4D]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [Note]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Code__367C1819]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__UserName__37703C52]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Password__3864608B]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Fullname__395884C4]  DEFAULT ('') FOR [Fullname]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Email__3A4CA8FD]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Phone__3B40CD36]  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Gender]  DEFAULT ('') FOR [Gender]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Address__3C34F16F]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__RoleID__3D2915A8]  DEFAULT ((0)) FOR [RoleID]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__IsActive__3E1D39E1]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__IsDeleted__3F115E1A]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreateUse__40058253]  DEFAULT ((0)) FOR [CreateUser]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreateDat__40F9A68C]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__UpdateUse__41EDCAC5]  DEFAULT ((0)) FOR [UpdateUser]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__UpdateDat__42E1EEFE]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Incomes]  WITH CHECK ADD  CONSTRAINT [FK__Incomes__OrderID__6FB49575] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Incomes] CHECK CONSTRAINT [FK__Incomes__OrderID__6FB49575]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ConstructionTypeID])
REFERENCES [dbo].[ConstructionTypes] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([MaterialTypeID])
REFERENCES [dbo].[MaterialTypes] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__6BE40491] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__6BE40491]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__Customer__690797E6] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__Customer__690797E6]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__Delivery__6AEFE058] FOREIGN KEY([DeliveryTypeID])
REFERENCES [dbo].[DeliveryTypes] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__Delivery__6AEFE058]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__PaymentT__69FBBC1F] FOREIGN KEY([PaymentTypeID])
REFERENCES [dbo].[PaymentTypes] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__PaymentT__69FBBC1F]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleID__7C1A6C5A] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleID__7C1A6C5A]
GO
USE [master]
GO
ALTER DATABASE [QLDonHang] SET  READ_WRITE 
GO
