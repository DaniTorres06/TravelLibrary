USE [master]
GO
/****** Object:  Database [BDTravel]    Script Date: 30/05/2023 11:06:37 a. m. ******/
CREATE DATABASE [BDTravel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDTravel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDTravel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDTravel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDTravel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDTravel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDTravel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDTravel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDTravel] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDTravel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDTravel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDTravel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDTravel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDTravel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDTravel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDTravel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDTravel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDTravel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDTravel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDTravel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDTravel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDTravel] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BDTravel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDTravel] SET RECOVERY FULL 
GO
ALTER DATABASE [BDTravel] SET  MULTI_USER 
GO
ALTER DATABASE [BDTravel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDTravel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDTravel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDTravel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDTravel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDTravel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDTravel', N'ON'
GO
ALTER DATABASE [BDTravel] SET QUERY_STORE = OFF
GO
USE [BDTravel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/05/2023 11:06:37 a. m. ******/
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
/****** Object:  Table [dbo].[autor_has_libro]    Script Date: 30/05/2023 11:06:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autor_has_libro](
	[autor_id] [int] NOT NULL,
	[libro_ISBN] [bigint] NOT NULL,
 CONSTRAINT [PK_autor_has_libro] PRIMARY KEY CLUSTERED 
(
	[autor_id] ASC,
	[libro_ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 30/05/2023 11:06:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[apellidos] [nvarchar](45) NULL,
 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editorial]    Script Date: 30/05/2023 11:06:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editorial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[sede] [nvarchar](45) NULL,
 CONSTRAINT [PK_editorial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 30/05/2023 11:06:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[Isbn] [bigint] NOT NULL,
	[editorial_id] [int] NOT NULL,
	[titulo] [nvarchar](45) NULL,
	[sipnosis] [nvarchar](max) NULL,
	[n_paginas] [nvarchar](45) NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[Isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230527174105_initia3', N'5.0.17')
GO
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (10, 84293245)
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (4, 842068502)
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (2, 849329148)
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (3, 8420685623)
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (5, 8420690708)
INSERT [dbo].[autor_has_libro] ([autor_id], [libro_ISBN]) VALUES (1, 9788493975074)
GO
SET IDENTITY_INSERT [dbo].[autores] ON 

INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (1, N'José María', N'García López')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (2, N'Esteban', N'Hernández Castelló')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (3, N'Robert', N'Stevenson')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (4, N'Samuel', N'Rubio')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (5, N'Juan Carlos', N'Asensio')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (6, N'Dani', N'Torres')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (9, N'Simon', N'Torino')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (10, N'Dani', N'32')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (13, N'Dani', N'Torres')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (17, N'Dani Mod', N'Torres Mod')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (18, N'Dani', N'Torres')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (19, N'Dani', N'Torres')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (20, N'Dani', N'Torres')
INSERT [dbo].[autores] ([Id], [nombre], [apellidos]) VALUES (1017, N'31', N'31')
SET IDENTITY_INSERT [dbo].[autores] OFF
GO
SET IDENTITY_INSERT [dbo].[editorial] ON 

INSERT [dbo].[editorial] ([Id], [nombre], [sede]) VALUES (1, N'Nocturna', N'Espana')
INSERT [dbo].[editorial] ([Id], [nombre], [sede]) VALUES (2, N'Obra social de Caja de Avila', N'Espana')
INSERT [dbo].[editorial] ([Id], [nombre], [sede]) VALUES (3, N'Alianza Músicas', N'Espana-Madrid')
SET IDENTITY_INSERT [dbo].[editorial] OFF
GO
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (8429324, 2, N'La sirenita', N'Una pelicula mala', N'200')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (84293245, 3, N'Libro de prueba ', N'Libro magico para pruebas', N'687')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (842068502, 3, N'Historia de la música española 2', N'Un libro excelente. Contiene una sección muy extensa sobre Tomás Luis de Victoria y un catálogo de sus obras. Incluye un capítulo interesantísimo sobre cómo era la vida de los maestros de capilla y de los cantores en aquella época.', N'323')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (849329148, 2, N'Salmos de vísperas', N'Esta edición de los salmos de vísperas es una verdadera joya. En 1975 Fischer encontró un manuscrito (el manuscrito musical 130 de la Biblioteca Nazionale Vittorio Emanuele II de Roma) con diez salmos a 4 voces, se trata de una prueba de imprenta con anotaciones del propio Victoria que nunca se llegaron a editar. El libro contiene una interesante introducción con la historia del manuscrito y una estupenda transcripción siguiendo todos los convenios de la musicología actual. El plato fuerte es la reproducción fotográfica a todo color del manuscrito completo, ideal para quien quiera hacer la transcripción por sí mismo. En resumen, una edición muy recomendable, sobre todo teniendo en cuenta su bajo precio.', N'95 + 40 fotografias')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (8420685623, 3, N'La música en las catedrales españolas', N'Se trata de una actualización de un libro de 1961, ampliado con numerosísimas notas por parte del autor y traducido al español (es la primera vez que veo un libro en el que la traducción es mejor que el original). Se divide en tres partes, dedicada cada una respectivamente a Morales, Guerrero y Victoria. Contiene la biografía de Victoria más completa publicada hasta la fecha. Incluye un análisis somero de algunas obras, y un catálogo con todas sus obras. Es un libro muy recomendable.', N'600')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (8420690708, 3, N'El canto gregoriano, historia', N'Este es un libro muy completo sobre canto gregoriano. Aunque no menciona a Tomás Luis de Victoria, lo incluimos aquí porque para entender la polifonía clásica es muy importante conocer cual era la música que se cantaba en la liturgia de la iglesia católica.', N'557')
INSERT [dbo].[Libro] ([Isbn], [editorial_id], [titulo], [sipnosis], [n_paginas]) VALUES (9788493975074, 1, N'El corazón de la piedra', N'Una novela ambientada en la Europa de los siglos XVI y XVII y que tiene a Tomás Luis de Victoria como uno de sus protagonistas.', N'560')
GO
/****** Object:  Index [IX_autor_has_libro_libro_ISBN]    Script Date: 30/05/2023 11:06:38 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_autor_has_libro_libro_ISBN] ON [dbo].[autor_has_libro]
(
	[libro_ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Libro_editorial_id]    Script Date: 30/05/2023 11:06:38 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Libro_editorial_id] ON [dbo].[Libro]
(
	[editorial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[autor_has_libro]  WITH CHECK ADD  CONSTRAINT [FK_autor_has_libro_autor_autor_id] FOREIGN KEY([autor_id])
REFERENCES [dbo].[autores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[autor_has_libro] CHECK CONSTRAINT [FK_autor_has_libro_autor_autor_id]
GO
ALTER TABLE [dbo].[autor_has_libro]  WITH CHECK ADD  CONSTRAINT [FK_autor_has_libro_Libro_libro_ISBN] FOREIGN KEY([libro_ISBN])
REFERENCES [dbo].[Libro] ([Isbn])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[autor_has_libro] CHECK CONSTRAINT [FK_autor_has_libro_Libro_libro_ISBN]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_editorial_editorial_id] FOREIGN KEY([editorial_id])
REFERENCES [dbo].[editorial] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_editorial_editorial_id]
GO
USE [master]
GO
ALTER DATABASE [BDTravel] SET  READ_WRITE 
GO
