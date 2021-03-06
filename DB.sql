USE [master]
GO
/****** Object:  Database [Zagorod_Nedvig]    Script Date: 20.02.2019 9:03:36 ******/
CREATE DATABASE [Zagorod_Nedvig]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Zagorod_Nedvig', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Zagorod_Nedvig.mdf' , SIZE = 158720KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Zagorod_Nedvig_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Zagorod_Nedvig_log.ldf' , SIZE = 63424KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Zagorod_Nedvig] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Zagorod_Nedvig].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Zagorod_Nedvig] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET ARITHABORT OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Zagorod_Nedvig] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Zagorod_Nedvig] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Zagorod_Nedvig] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Zagorod_Nedvig] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Zagorod_Nedvig] SET  MULTI_USER 
GO
ALTER DATABASE [Zagorod_Nedvig] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Zagorod_Nedvig] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Zagorod_Nedvig] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Zagorod_Nedvig] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Zagorod_Nedvig] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Zagorod_Nedvig]
GO
/****** Object:  User [user]    Script Date: 20.02.2019 9:03:36 ******/
CREATE USER [user] FOR LOGIN [user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [user]
GO
/****** Object:  Schema [db_zn]    Script Date: 20.02.2019 9:03:37 ******/
CREATE SCHEMA [db_zn]
GO
/****** Object:  Table [dbo].[test]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NULL,
	[D_B] [nvarchar](10) NULL,
	[Pometka] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[test1]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NULL,
	[D_B] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Documents]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Documents](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[id_zayavl] [tinyint] NULL,
	[Naimenovanie] [nvarchar](50) NULL,
	[Seria] [nvarchar](10) NULL,
	[Nomer] [nvarchar](10) NULL,
	[Date_D] [date] NULL,
	[Avtor] [nvarchar](100) NULL,
	[Dop_info] [nvarchar](100) NULL,
	[Scan] [varbinary](max) NULL,
 CONSTRAINT [PK_Zagorod_Nedvig_Documents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Dogovor]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Dogovor](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[id_zayavl] [tinyint] NULL,
	[id_pokupat] [tinyint] NULL,
	[id_object] [tinyint] NULL,
	[scan] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Object]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Object](
	[id] [tinyint] NOT NULL,
	[Naimenovanie] [nvarchar](3) NULL,
	[K_N] [nvarchar](20) NULL,
	[K_N_ZU] [nvarchar](20) NULL,
	[Ploshad_KM] [smallint] NULL,
	[Adres] [nvarchar](200) NULL,
	[Document_osnov_Naimenovanie] [nvarchar](50) NULL,
	[Seria_document] [nvarchar](10) NULL,
	[Number_document] [nvarchar](10) NULL,
	[Date_document] [datetime] NULL,
	[Org_vid_document] [nvarchar](100) NULL,
	[Stoimost] [bigint] NULL,
	[Kol_vo_floor] [smallint] NULL,
	[Naznach_zemel] [nvarchar](50) NULL,
	[N_reg_z] [int] NULL,
	[id_zayavl] [tinyint] NULL,
 CONSTRAINT [PK_Zagorod_Nedvig_Object_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Pokupat]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Pokupat](
	[id] [tinyint] NOT NULL,
	[FIO_pokupat] [nvarchar](50) NULL,
	[DB_pokupat] [datetime] NULL,
	[Adres_pokupat] [nvarchar](200) NULL,
	[Seria_Pas_pokupat] [nvarchar](10) NULL,
	[Nomer_Pas_pokupat] [nvarchar](10) NULL,
	[Kod_Pod_pokupat] [nvarchar](7) NULL,
	[Date_Pas_vid] [datetime] NULL,
	[Org_Pas_pokupat] [nvarchar](100) NULL,
	[Contact_phone] [bigint] NULL,
	[id_zayavl] [tinyint] NULL,
 CONSTRAINT [PK_Zagorod_Nedvig_Pokupat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Polzovatel]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Polzovatel](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](10) NULL,
	[Password] [nvarchar](10) NULL,
	[Prava] [nvarchar](1) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zagorod_Nedvig_Zayav]    Script Date: 20.02.2019 9:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zagorod_Nedvig_Zayav](
	[id] [tinyint] NOT NULL,
	[id_pokupat] [tinyint] NULL,
	[id_object] [tinyint] NULL,
	[Date_zayv] [datetime] NULL,
	[Otpravl_Na_Ispolnen] [bit] NULL,
	[Ispolneno] [bit] NULL,
	[Otpravl_Na_Soglosovanie] [bit] NULL,
	[Soglasovano] [bit] NULL,
	[Otpravl_Na_Korrect] [bit] NULL,
	[Prich_Korrect_or_Otkaz] [nvarchar](50) NULL,
	[Otkaz] [bit] NULL,
 CONSTRAINT [PK_Zagorod_Nedvig_Zayav_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Documents]  WITH CHECK ADD  CONSTRAINT [FK_Zagorod_Nedvig_Documents_Zagorod_Nedvig_Zayav] FOREIGN KEY([id_zayavl])
REFERENCES [dbo].[Zagorod_Nedvig_Zayav] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Documents] CHECK CONSTRAINT [FK_Zagorod_Nedvig_Documents_Zagorod_Nedvig_Zayav]
GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Object]  WITH CHECK ADD  CONSTRAINT [FK_Zagorod_Nedvig_Object_Zagorod_Nedvig_Zayav] FOREIGN KEY([id_zayavl])
REFERENCES [dbo].[Zagorod_Nedvig_Zayav] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Object] CHECK CONSTRAINT [FK_Zagorod_Nedvig_Object_Zagorod_Nedvig_Zayav]
GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Pokupat]  WITH CHECK ADD  CONSTRAINT [FK_Zagorod_Nedvig_Pokupat_Zagorod_Nedvig_Zayav1] FOREIGN KEY([id_zayavl])
REFERENCES [dbo].[Zagorod_Nedvig_Zayav] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Zagorod_Nedvig_Pokupat] CHECK CONSTRAINT [FK_Zagorod_Nedvig_Pokupat_Zagorod_Nedvig_Zayav1]
GO
USE [master]
GO
ALTER DATABASE [Zagorod_Nedvig] SET  READ_WRITE 
GO
