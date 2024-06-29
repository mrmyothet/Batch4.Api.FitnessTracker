USE [master]
GO
/****** Object:  Database [FitnessTracker]    Script Date: 6/29/2024 7:19:11 PM ******/
CREATE DATABASE [FitnessTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FitnessTracker', FILENAME = N'C:\DB\FitnessTracker.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FitnessTracker_log', FILENAME = N'C:\DB\FitnessTracker_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FitnessTracker] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FitnessTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FitnessTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FitnessTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FitnessTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FitnessTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FitnessTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FitnessTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FitnessTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FitnessTracker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FitnessTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FitnessTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FitnessTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FitnessTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FitnessTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FitnessTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FitnessTracker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FitnessTracker] SET  MULTI_USER 
GO
ALTER DATABASE [FitnessTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FitnessTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FitnessTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FitnessTracker] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FitnessTracker]
GO
/****** Object:  Table [dbo].[Tbl_Activity]    Script Date: 6/29/2024 7:19:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Activity](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivityTypeId] [int] NOT NULL,
	[Metric1] [decimal](18, 2) NULL,
	[Metric2] [decimal](18, 2) NULL,
	[Metric3] [decimal](18, 2) NULL,
	[CaloriesBurned] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ActivityType]    Script Date: 6/29/2024 7:19:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ActivityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_ActivityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 6/29/2024 7:19:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CalorieGoal] [int] NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_ActivityType] ON 

INSERT [dbo].[Tbl_ActivityType] ([Id], [Name]) VALUES (1, N'Walking')
INSERT [dbo].[Tbl_ActivityType] ([Id], [Name]) VALUES (2, N'Swimming')
INSERT [dbo].[Tbl_ActivityType] ([Id], [Name]) VALUES (3, N'Cycling')
INSERT [dbo].[Tbl_ActivityType] ([Id], [Name]) VALUES (4, N'Running')
INSERT [dbo].[Tbl_ActivityType] ([Id], [Name]) VALUES (5, N'Yoga')
SET IDENTITY_INSERT [dbo].[Tbl_ActivityType] OFF
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([Id], [Name], [Password], [CalorieGoal]) VALUES (1, N'myothet', N'Admin123123!', NULL)
INSERT [dbo].[Tbl_User] ([Id], [Name], [Password], [CalorieGoal]) VALUES (2, N'susandarlin', N'Admin123123!', NULL)
INSERT [dbo].[Tbl_User] ([Id], [Name], [Password], [CalorieGoal]) VALUES (3, N'hninwuttyi', N'Admin123123!', NULL)
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
USE [master]
GO
ALTER DATABASE [FitnessTracker] SET  READ_WRITE 
GO
