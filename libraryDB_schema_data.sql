USE [master]
GO

/****** Object:  Database [LibraryDB]    Script Date: 4/26/2022 1:43:07 PM ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [LibraryDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LibraryDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO

ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LibraryDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LibraryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [LibraryDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO

USE [LibraryDB]
GO

/****** Object:  Table [dbo].[Media]    Script Date: 4/26/2022 1:43:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Media](
	[media_id] [int] NOT NULL,
	[media_name] [nvarchar](100) NOT NULL,
	[media_type] [nvarchar](40) NOT NULL,
	[account_id] [int] NULL,
	[author] [nvarchar](200) NULL,
	[Publisher] [nvarchar](200) NULL
 CONSTRAINT [PK_Media] PRIMARY KEY CLUSTERED 
(
	[media_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [LibraryDB]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 4/26/2022 1:43:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[role_id] [int] NOT NULL,
	[role_name] [nvarchar](10) NOT NULL
CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [LibraryDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 4/26/2022 1:43:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[account_id] [int] NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



INSERT [dbo].[Roles] ([role_id], [role_name]) VALUES (1,N'Admin')
INSERT [dbo].[Roles] ([role_id], [role_name]) VALUES (2,N'Librarian')
INSERT [dbo].[Roles] ([role_id], [role_name]) VALUES (3,N'Patron')
INSERT [dbo].[Roles] ([role_id], [role_name]) VALUES (4,N'Guest')



INSERT [dbo].[Users] ([account_id],[username],[password],[role_id]) VALUES (100,N'Admin123',N'password123',1)
INSERT [dbo].[Users] ([account_id],[username],[password],[role_id]) VALUES (101, N'LibKate',N'kateLiberarian',2)

INSERT [dbo].[Media] ([media_id],[media_name],[media_type],[account_id],[author],[Publisher]) VALUES (1,N'The Divine Comedy',N'Book',NULL,N'Dante Alighieri',N'Penguin Publishing Group')
INSERT [dbo].[Media] ([media_id],[media_name],[media_type],[account_id],[author],[Publisher]) VALUES (2,N'The Journey to the West, Revised Edition, Volume 1',N'Book',NULL,N'Chengen Wu',N'University of Chicago Press')
INSERT [dbo].[Media] ([media_id],[media_name],[media_type],[account_id],[author],[Publisher]) VALUES (3,N'The Journey to the West, Revised Edition, Volume 2',N'Book',NULL,N'Chengen Wu',N'University of Chicago Press')
INSERT [dbo].[Media] ([media_id],[media_name],[media_type],[account_id],[author],[Publisher]) VALUES (4,N'The Journey to the West, Revised Edition, Volume 3',N'Book',NULL,N'Chengen Wu',N'University of Chicago Press')
INSERT [dbo].[Media] ([media_id],[media_name],[media_type],[account_id],[author],[Publisher]) VALUES (5,N'The Journey to the West, Revised Edition, Volume 4',N'Book',NULL,N'Chengen Wu',N'University of Chicago Press')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[userCreate](
	@account_id int,
	@username nvarchar(30),
	@password nvarchar(20),
	@role_id int)
	as
	BEGIN
		insert into Users(account_id,username,password,role_id)
			values(@account_id,@username,@password,@role_id)
		SELECT 'NumberRecordsAffected'=@@ROWCOUNT
	END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[deleteUser](
	@account_id int,
	@username nvarchar(30),
	@password nvarchar(20))
	as
	BEGIN
		DELETE FROM [dbo].[Users] WHERE [account_id]=@account_id AND [username] = @username AND [password] = @password
		SELECT 'NumberRecordsAffected'=@@ROWCOUNT
	END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[checkUserValid](
	@username nvarchar(30),
	@password nvarchar(20))
	as
	BEGIN
		select * FROM [dbo].[Users] WHERE [username] = @username AND [password] = @password
	END

/****** Object:  StoredProcedure [dbo].[updateMedia]    Script Date: 4/27/2022 7:42:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[updateMedia](
	@media_name nvarchar(100),
	@media_type nvarchar(40),
	@account_id int)
	as
	BEGIN
	DECLARE @account INT SELECT account_id FROM Media WHERE media_name=@media_name AND media_type=@media_type;
	IF(@account != NULL)
		UPDATE Media
		SET account_id = NULL
		WHERE media_name=@media_name AND media_type=@media_type AND account_id =@account_id
	ELSE
		UPDATE Media
		SET account_id = @account_id
		WHERE media_name=@media_name AND media_type=@media_type

		SELECT 'Number Records Affected' = @@ROWCOUNT
	END
