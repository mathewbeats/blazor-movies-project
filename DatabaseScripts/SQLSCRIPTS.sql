USE [master]
GO
/****** Object:  Database [ApiMoviesNet8]    Script Date: 07/05/2024 13:03:03 ******/
CREATE DATABASE [ApiMoviesNet8]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApiMoviesNet8', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ApiMoviesNet8.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApiMoviesNet8_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ApiMoviesNet8_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApiMoviesNet8] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiMoviesNet8].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiMoviesNet8] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiMoviesNet8] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiMoviesNet8] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ApiMoviesNet8] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiMoviesNet8] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ApiMoviesNet8] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApiMoviesNet8] SET  MULTI_USER 
GO
ALTER DATABASE [ApiMoviesNet8] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiMoviesNet8] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiMoviesNet8] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiMoviesNet8] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiMoviesNet8] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiMoviesNet8] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApiMoviesNet8', N'ON'
GO
ALTER DATABASE [ApiMoviesNet8] SET QUERY_STORE = OFF
GO
USE [ApiMoviesNet8]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/05/2024 13:03:04 ******/
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
/****** Object:  Table [dbo].[Genres]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MovieDetailsId] [int] NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviesDetails]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adult] [bit] NOT NULL,
	[BackdropPath] [nvarchar](max) NULL,
	[Budget] [int] NOT NULL,
	[Homepage] [nvarchar](max) NULL,
	[ImdbId] [nvarchar](max) NULL,
	[OriginalLanguage] [nvarchar](max) NULL,
	[OriginalTitle] [nvarchar](max) NULL,
	[Overview] [nvarchar](max) NULL,
	[Popularity] [real] NOT NULL,
	[PosterPath] [nvarchar](max) NULL,
	[ReleaseDate] [nvarchar](max) NULL,
	[Revenue] [int] NOT NULL,
	[Runtime] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Tagline] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Video] [bit] NOT NULL,
	[VoteAverage] [real] NOT NULL,
	[VoteCount] [int] NOT NULL,
 CONSTRAINT [PK_MoviesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionCompanies]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionCompanies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogoPath] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OriginCountry] [nvarchar](max) NULL,
	[MovieDetailsId] [int] NULL,
 CONSTRAINT [PK_ProductionCompanies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionCountries]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionCountries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MovieDetailsId] [int] NULL,
 CONSTRAINT [PK_ProductionCountries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpokenLanguages]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpokenLanguages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnglishName] [nvarchar](max) NULL,
	[LanguageCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MovieDetailsId] [int] NULL,
 CONSTRAINT [PK_SpokenLanguages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/05/2024 13:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreDeUsuario] [nvarchar](100) NULL,
	[Nombre] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Genres_MovieDetailsId]    Script Date: 07/05/2024 13:03:04 ******/
CREATE NONCLUSTERED INDEX [IX_Genres_MovieDetailsId] ON [dbo].[Genres]
(
	[MovieDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductionCompanies_MovieDetailsId]    Script Date: 07/05/2024 13:03:04 ******/
CREATE NONCLUSTERED INDEX [IX_ProductionCompanies_MovieDetailsId] ON [dbo].[ProductionCompanies]
(
	[MovieDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductionCountries_MovieDetailsId]    Script Date: 07/05/2024 13:03:04 ******/
CREATE NONCLUSTERED INDEX [IX_ProductionCountries_MovieDetailsId] ON [dbo].[ProductionCountries]
(
	[MovieDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpokenLanguages_MovieDetailsId]    Script Date: 07/05/2024 13:03:04 ******/
CREATE NONCLUSTERED INDEX [IX_SpokenLanguages_MovieDetailsId] ON [dbo].[SpokenLanguages]
(
	[MovieDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Genres]  WITH CHECK ADD  CONSTRAINT [FK_Genres_MoviesDetails_MovieDetailsId] FOREIGN KEY([MovieDetailsId])
REFERENCES [dbo].[MoviesDetails] ([Id])
GO
ALTER TABLE [dbo].[Genres] CHECK CONSTRAINT [FK_Genres_MoviesDetails_MovieDetailsId]
GO
ALTER TABLE [dbo].[ProductionCompanies]  WITH CHECK ADD  CONSTRAINT [FK_ProductionCompanies_MoviesDetails_MovieDetailsId] FOREIGN KEY([MovieDetailsId])
REFERENCES [dbo].[MoviesDetails] ([Id])
GO
ALTER TABLE [dbo].[ProductionCompanies] CHECK CONSTRAINT [FK_ProductionCompanies_MoviesDetails_MovieDetailsId]
GO
ALTER TABLE [dbo].[ProductionCountries]  WITH CHECK ADD  CONSTRAINT [FK_ProductionCountries_MoviesDetails_MovieDetailsId] FOREIGN KEY([MovieDetailsId])
REFERENCES [dbo].[MoviesDetails] ([Id])
GO
ALTER TABLE [dbo].[ProductionCountries] CHECK CONSTRAINT [FK_ProductionCountries_MoviesDetails_MovieDetailsId]
GO
ALTER TABLE [dbo].[SpokenLanguages]  WITH CHECK ADD  CONSTRAINT [FK_SpokenLanguages_MoviesDetails_MovieDetailsId] FOREIGN KEY([MovieDetailsId])
REFERENCES [dbo].[MoviesDetails] ([Id])
GO
ALTER TABLE [dbo].[SpokenLanguages] CHECK CONSTRAINT [FK_SpokenLanguages_MoviesDetails_MovieDetailsId]
GO
USE [master]
GO
ALTER DATABASE [ApiMoviesNet8] SET  READ_WRITE 
GO
