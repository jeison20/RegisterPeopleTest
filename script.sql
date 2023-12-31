USE [RegisterPeople]
GO
ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_Phones_People_PeopleId]
GO
ALTER TABLE [dbo].[EmailAddress] DROP CONSTRAINT [FK_EmailAddress_People_PeopleId]
GO
ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_People_PeopleId]
GO
/****** Object:  Index [IX_Phones_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
DROP INDEX [IX_Phones_PeopleId] ON [dbo].[Phones]
GO
/****** Object:  Index [IX_EmailAddress_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
DROP INDEX [IX_EmailAddress_PeopleId] ON [dbo].[EmailAddress]
GO
/****** Object:  Index [IX_Address_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
DROP INDEX [IX_Address_PeopleId] ON [dbo].[Address]
GO
/****** Object:  Table [dbo].[Phones]    Script Date: 9/17/2023 11:29:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Phones]') AND type in (N'U'))
DROP TABLE [dbo].[Phones]
GO
/****** Object:  Table [dbo].[People]    Script Date: 9/17/2023 11:29:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
DROP TABLE [dbo].[People]
GO
/****** Object:  Table [dbo].[EmailAddress]    Script Date: 9/17/2023 11:29:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailAddress]') AND type in (N'U'))
DROP TABLE [dbo].[EmailAddress]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 9/17/2023 11:29:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
DROP TABLE [dbo].[Address]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/17/2023 11:29:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  User [test]    Script Date: 9/17/2023 11:29:38 PM ******/
DROP USER [test]
GO
USE [master]
GO
/****** Object:  Database [RegisterPeople]    Script Date: 9/17/2023 11:29:38 PM ******/
DROP DATABASE [RegisterPeople]
GO
/****** Object:  Database [RegisterPeople]    Script Date: 9/17/2023 11:29:38 PM ******/
CREATE DATABASE [RegisterPeople]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegisterPeople', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RegisterPeople.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegisterPeople_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RegisterPeople_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RegisterPeople] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegisterPeople].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegisterPeople] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegisterPeople] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegisterPeople] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegisterPeople] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegisterPeople] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegisterPeople] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegisterPeople] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegisterPeople] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegisterPeople] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegisterPeople] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegisterPeople] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegisterPeople] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegisterPeople] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegisterPeople] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegisterPeople] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RegisterPeople] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegisterPeople] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegisterPeople] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegisterPeople] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegisterPeople] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegisterPeople] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegisterPeople] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegisterPeople] SET RECOVERY FULL 
GO
ALTER DATABASE [RegisterPeople] SET  MULTI_USER 
GO
ALTER DATABASE [RegisterPeople] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegisterPeople] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegisterPeople] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegisterPeople] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegisterPeople] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RegisterPeople] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RegisterPeople', N'ON'
GO
ALTER DATABASE [RegisterPeople] SET QUERY_STORE = ON
GO
ALTER DATABASE [RegisterPeople] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RegisterPeople]
GO
/****** Object:  User [test]    Script Date: 9/17/2023 11:29:38 PM ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [test]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [test]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/17/2023 11:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 9/17/2023 11:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NOT NULL,
	[PhysicalAddress] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailAddress]    Script Date: 9/17/2023 11:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_EmailAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 9/17/2023 11:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityDocument] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phones]    Script Date: 9/17/2023 11:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230918035233_InitialCreate', N'7.0.11')
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [PeopleId], [PhysicalAddress]) VALUES (1, 1, N'cra 12 -566')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailAddress] ON 

INSERT [dbo].[EmailAddress] ([Id], [PeopleId], [Address]) VALUES (1, 1, N'osp_78@hotmail.com')
SET IDENTITY_INSERT [dbo].[EmailAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([Id], [IdentityDocument], [FirstName], [LastName], [BirthDate]) VALUES (1, N'454515454', N'luisa', N'perz', CAST(N'1985-09-18T03:35:16.1770000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Phones] ON 

INSERT [dbo].[Phones] ([Id], [PeopleId], [Number]) VALUES (1, 1, N'4785521')
SET IDENTITY_INSERT [dbo].[Phones] OFF
GO
/****** Object:  Index [IX_Address_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Address_PeopleId] ON [dbo].[Address]
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmailAddress_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmailAddress_PeopleId] ON [dbo].[EmailAddress]
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Phones_PeopleId]    Script Date: 9/17/2023 11:29:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Phones_PeopleId] ON [dbo].[Phones]
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_People_PeopleId] FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_People_PeopleId]
GO
ALTER TABLE [dbo].[EmailAddress]  WITH CHECK ADD  CONSTRAINT [FK_EmailAddress_People_PeopleId] FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailAddress] CHECK CONSTRAINT [FK_EmailAddress_People_PeopleId]
GO
ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [FK_Phones_People_PeopleId] FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_People_PeopleId]
GO
USE [master]
GO
ALTER DATABASE [RegisterPeople] SET  READ_WRITE 
GO
