USE [master]
GO
/****** Object:  Database [FitnessTracker]    Script Date: 2024-07-04 11:53:33 pm ******/
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
/****** Object:  Table [dbo].[Tbl_Activity]    Script Date: 2024-07-04 11:53:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Activity](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivityTypeId] [int] NOT NULL,
	[Metric1] [decimal](18, 2) NULL,
	[Metric2] [decimal](18, 2) NULL,
	[Metric3] [decimal](18, 2) NULL,
	[CaloriesBurned] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Tbl_Activity] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ActivityType]    Script Date: 2024-07-04 11:53:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ActivityType](
	[ActivityTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ActivityTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_ActivityType] PRIMARY KEY CLUSTERED 
(
	[ActivityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 2024-07-04 11:53:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CalorieGoal] [int] NULL,
	[TotalCaloriesBurned] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_ActivityType] ON 

INSERT [dbo].[Tbl_ActivityType] ([ActivityTypeId], [ActivityTypeName]) VALUES (1, N'Walking')
INSERT [dbo].[Tbl_ActivityType] ([ActivityTypeId], [ActivityTypeName]) VALUES (2, N'Swimming')
INSERT [dbo].[Tbl_ActivityType] ([ActivityTypeId], [ActivityTypeName]) VALUES (3, N'Cycling')
INSERT [dbo].[Tbl_ActivityType] ([ActivityTypeId], [ActivityTypeName]) VALUES (4, N'Running')
INSERT [dbo].[Tbl_ActivityType] ([ActivityTypeId], [ActivityTypeName]) VALUES (5, N'Yoga')
SET IDENTITY_INSERT [dbo].[Tbl_ActivityType] OFF
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([UserId], [UserName], [Password], [CalorieGoal], [TotalCaloriesBurned]) VALUES (1, N'myothet', N'Admin123123!', 600, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_User] ([UserId], [UserName], [Password], [CalorieGoal], [TotalCaloriesBurned]) VALUES (2, N'susandarlin', N'Admin123123!', 700, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_User] ([UserId], [UserName], [Password], [CalorieGoal], [TotalCaloriesBurned]) VALUES (3, N'hninwuttyi', N'Admin123123!', 0, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_User] ([UserId], [UserName], [Password], [CalorieGoal], [TotalCaloriesBurned]) VALUES (4, N'myothet', N'Admin123123!', 0, CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_Tbl_User_CalorieGoal]  DEFAULT ((0)) FOR [CalorieGoal]
GO
USE [master]
GO
ALTER DATABASE [FitnessTracker] SET  READ_WRITE 
GO
