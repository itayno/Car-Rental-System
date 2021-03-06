USE [master]
GO
/****** Object:  Database [CarRentSystem]    Script Date: 31/03/2020 11:01:51 ******/
CREATE DATABASE [CarRentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRentSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CarRentSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarRentSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CarRentSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarRentSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRentSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CarRentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRentSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CarRentSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CarRentSystem]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 31/03/2020 11:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[id] [int] NOT NULL,
	[BranchName] [nvarchar](50) NULL,
	[BranchAddress] [nvarchar](50) NULL,
	[LatitudeX] [int] NULL,
	[LongitudeY] [int] NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarRentalDetails]    Script Date: 31/03/2020 11:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarRentalDetails](
	[ID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[ActualReturnDate] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[CarNumber] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CarRentalDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 31/03/2020 11:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cars](
	[CarType] [int] NULL,
	[Mileage] [int] NULL,
	[Image] [image] NULL,
	[IsUndamaged] [bit] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[CarNumber] [varchar](50) NOT NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarTypes]    Script Date: 31/03/2020 11:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarTypes](
	[ID] [int] NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[DailyCost] [float] NOT NULL,
	[DailyLatePenalty] [float] NOT NULL,
	[ManufacturingYear] [date] NOT NULL,
	[GearType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 31/03/2020 11:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Branches] ([id], [BranchName], [BranchAddress], [LatitudeX], [LongitudeY]) VALUES (27, N'Tel Aviv', N'Hamasger 30', 32063541, 34785656)
INSERT [dbo].[Branches] ([id], [BranchName], [BranchAddress], [LatitudeX], [LongitudeY]) VALUES (36, N'Herzliya', N'Hahoshlim 9', 3448225, 3209323)
INSERT [dbo].[Branches] ([id], [BranchName], [BranchAddress], [LatitudeX], [LongitudeY]) VALUES (45, N'Rishon Letziyon', N'Lishanski 20', 31992956, 34767933)
INSERT [dbo].[Branches] ([id], [BranchName], [BranchAddress], [LatitudeX], [LongitudeY]) VALUES (51, N'Petah Tikva', N'Hasivim 2', 32092803, 34856767)
INSERT [dbo].[Branches] ([id], [BranchName], [BranchAddress], [LatitudeX], [LongitudeY]) VALUES (69, N'Ben Gurion Airport', N'Terminal 1 LLBG', 31995279, 34895375)
INSERT [dbo].[CarRentalDetails] ([ID], [StartDate], [ReturnDate], [ActualReturnDate], [UserID], [CarNumber], [IsActive]) VALUES (1, CAST(N'2020-02-10 00:00:00.000' AS DateTime), CAST(N'2020-02-15 00:00:00.000' AS DateTime), CAST(N'2020-02-15 00:00:00.000' AS DateTime), 1, N'2154487', 1)
INSERT [dbo].[CarRentalDetails] ([ID], [StartDate], [ReturnDate], [ActualReturnDate], [UserID], [CarNumber], [IsActive]) VALUES (2, CAST(N'2020-01-10 00:00:00.000' AS DateTime), CAST(N'2020-01-17 00:00:00.000' AS DateTime), CAST(N'2020-01-19 00:00:00.000' AS DateTime), 2, N'6107789', 0)
INSERT [dbo].[CarRentalDetails] ([ID], [StartDate], [ReturnDate], [ActualReturnDate], [UserID], [CarNumber], [IsActive]) VALUES (3, CAST(N'2020-01-10 00:00:00.000' AS DateTime), CAST(N'2020-01-16 00:00:00.000' AS DateTime), CAST(N'2020-01-16 00:00:00.000' AS DateTime), 3, N'2154487', 0)
INSERT [dbo].[CarRentalDetails] ([ID], [StartDate], [ReturnDate], [ActualReturnDate], [UserID], [CarNumber], [IsActive]) VALUES (4, CAST(N'2020-02-05 00:00:00.000' AS DateTime), CAST(N'2020-02-15 00:00:00.000' AS DateTime), CAST(N'2020-02-15 00:00:00.000' AS DateTime), 4, N'3257745', 1)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (1, 15476, NULL, 1, 1, N'1354778', 27)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (4, 42154, NULL, 1, 1, N'1547884', 51)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (4, 34215, NULL, 1, 1, N'2154487', 69)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (3, 31247, NULL, 1, 0, N'3257745', 45)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (2, 34256, NULL, 1, 1, N'4265523', 69)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (2, 24325, NULL, 0, 0, N'5212547', 27)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (1, 28576, NULL, 1, 1, N'6107789', 36)
INSERT [dbo].[Cars] ([CarType], [Mileage], [Image], [IsUndamaged], [IsAvailable], [CarNumber], [BranchID]) VALUES (5, 22547, NULL, 1, 0, N'6745211', 27)
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (1, N'Chevrolet', N'Spark', 95, 39, CAST(N'2014-07-10' AS Date), N'Manual')
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (2, N'Kia', N'Picanto', 98, 32, CAST(N'2015-07-16' AS Date), N'Automatic')
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (3, N'Hyundai', N'I10', 94, 31, CAST(N'2016-08-26' AS Date), N'Automatic')
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (4, N'Mazda', N'3', 102, 36, CAST(N'2015-06-16' AS Date), N'Automatic')
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (5, N'Honda', N'Civic', 106, 38, CAST(N'2015-06-16' AS Date), N'Automatic')
INSERT [dbo].[CarTypes] ([ID], [Manufacturer], [Model], [DailyCost], [DailyLatePenalty], [ManufacturingYear], [GearType]) VALUES (6, N'Mitzubishi', N'Pajero', 115, 45, CAST(N'2017-06-16' AS Date), N'Automatic')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (1, N'Yossef', N'Mizrahi', N'YosMiz', CAST(N'1996-07-16' AS Date), N'Male      ', N'yosmiz@gmail.com', N'yoyo123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (2, N'Judy', N'Koper', N'Judk', CAST(N'1975-08-24' AS Date), N'Female    ', N'jude@gmail.com', N'jud123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (3, N'Itzik', N'Cohen', N'Itzko', CAST(N'1980-04-12' AS Date), N'Male      ', N'itzko@gmail.com', N'itz123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (4, N'Eli', N'Levi', N'Elilo', CAST(N'1982-01-06' AS Date), N'Male      ', N'elilo@gmail.com', N'eli123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (5, N'Shira', N'Bernstein', N'Shirb', CAST(N'1990-04-16' AS Date), N'Female    ', N'shirb@gmail.com', N'shi123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (6, N'Miko', N'Belilti', N'Mikb', CAST(N'1986-10-26' AS Date), N'Male      ', N'mikb@gmail.com', N'mik123', 0, NULL)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DateOfBirth], [Gender], [Email], [UserPassword], [IsAdmin], [Image]) VALUES (7, N'Itay', N'Normand', N'itayno', CAST(N'1996-07-11' AS Date), N'Male      ', N'itayno@gmail.com', N'itay123', 1, NULL)
ALTER TABLE [dbo].[CarRentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarRentalDetails_Cars] FOREIGN KEY([CarNumber])
REFERENCES [dbo].[Cars] ([CarNumber])
GO
ALTER TABLE [dbo].[CarRentalDetails] CHECK CONSTRAINT [FK_CarRentalDetails_Cars]
GO
ALTER TABLE [dbo].[CarRentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarRentalDetails_Users] FOREIGN KEY([ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[CarRentalDetails] CHECK CONSTRAINT [FK_CarRentalDetails_Users]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Branches]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarTypes] FOREIGN KEY([CarType])
REFERENCES [dbo].[CarTypes] ([ID])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarTypes]
GO
USE [master]
GO
ALTER DATABASE [CarRentSystem] SET  READ_WRITE 
GO
