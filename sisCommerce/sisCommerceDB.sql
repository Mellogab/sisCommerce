USE [master]
GO
/****** Object:  Database [sisCommerce]    Script Date: 22/09/2017 17:07:11 ******/
CREATE DATABASE [sisCommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sisCommerce', FILENAME = N'C:\Users\GabrielC2\sisCommerce.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sisCommerce_log', FILENAME = N'C:\Users\GabrielC2\sisCommerce_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sisCommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sisCommerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sisCommerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sisCommerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sisCommerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sisCommerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [sisCommerce] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [sisCommerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sisCommerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sisCommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sisCommerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sisCommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sisCommerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sisCommerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sisCommerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sisCommerce] SET  ENABLE_BROKER 
GO
ALTER DATABASE [sisCommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sisCommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sisCommerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sisCommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sisCommerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sisCommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sisCommerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sisCommerce] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sisCommerce] SET  MULTI_USER 
GO
ALTER DATABASE [sisCommerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sisCommerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sisCommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sisCommerce] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sisCommerce] SET DELAYED_DURABILITY = DISABLED 
GO
USE [sisCommerce]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 22/09/2017 17:07:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](18) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 22/09/2017 17:07:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](18) NOT NULL,
	[description] [nchar](18) NOT NULL,
	[price] [real] NOT NULL,
	[quantify] [int] NOT NULL,
	[image] [varbinary](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/09/2017 17:07:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](18) NOT NULL,
	[user] [nchar](18) NOT NULL,
	[password] [nchar](18) NOT NULL,
	[idGroup] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([id], [name]) VALUES (1, N'Administracao     ')
INSERT [dbo].[Groups] ([id], [name]) VALUES (2, N'Comum             ')
INSERT [dbo].[Groups] ([id], [name]) VALUES (3, N'Financeiro        ')
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [user], [password], [idGroup]) VALUES (1, N'Gabriel Melo Costa', N'Gabriel           ', N'123               ', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [sisCommerce] SET  READ_WRITE 
GO
