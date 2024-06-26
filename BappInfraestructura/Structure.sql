USE [master]
GO
/****** Object:  Database [BarberyApp]    Script Date: 19/3/2024 5:49:34 p. m. ******/
CREATE DATABASE [BarberyApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BarberyApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BarberyApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BarberyApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BarberyApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BarberyApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BarberyApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BarberyApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BarberyApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BarberyApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BarberyApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BarberyApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BarberyApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BarberyApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BarberyApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BarberyApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BarberyApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BarberyApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BarberyApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BarberyApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BarberyApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BarberyApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BarberyApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BarberyApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BarberyApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BarberyApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BarberyApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BarberyApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BarberyApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BarberyApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BarberyApp] SET  MULTI_USER 
GO
ALTER DATABASE [BarberyApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BarberyApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BarberyApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BarberyApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BarberyApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BarberyApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BarberyApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [BarberyApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BarberyApp]
GO
/****** Object:  Table [dbo].[Barberos]    Script Date: 19/3/2024 5:49:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barberos](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Contraseña] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Barberos_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 19/3/2024 5:49:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[id] [uniqueidentifier] NOT NULL,
	[localbarbero_id] [uniqueidentifier] NOT NULL,
	[cliente_id] [uniqueidentifier] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[comentarios] [text] NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_actualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 19/3/2024 5:49:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Contraseña] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstiloCorte]    Script Date: 19/3/2024 5:49:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstiloCorte](
	[Id] [uniqueidentifier] NOT NULL,
	[LocalId] [uniqueidentifier] NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[GaleriaFotos] [nvarchar](max) NULL,
	[Precio] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalBarbero]    Script Date: 19/3/2024 5:49:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalBarbero](
	[Id] [uniqueidentifier] NOT NULL,
	[BarberoId] [uniqueidentifier] NULL,
	[NombreBarberia] [varchar](100) NULL,
	[Descripcion] [varchar](max) NULL,
	[Ubicacion] [varchar](255) NULL,
	[NumeroContacto] [varchar](20) NULL,
	[Horario] [varchar](255) NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_LocalBarbero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Barberos] ([Id], [Nombre], [Apellido], [Email], [Contraseña]) VALUES (N'791a7e9b-1155-4ac2-aea6-59b6915ca47e', N'Salvaje', N'Fernand', N'sf@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Apellido], [Email], [Contraseña]) VALUES (N'016be152-b7a2-45a7-8d24-1790ac7e91b7', N'Carlos', N'Guzman', N'cg@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
INSERT [dbo].[Clientes] ([Id], [Nombre], [Apellido], [Email], [Contraseña]) VALUES (N'ac6baedf-4b4e-4a61-95c9-5231d659c9bc', N'Jesus', N'Miercoles', N'jm@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT (getdate()) FOR [fecha_actualizacion]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [fk_Cliente] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [fk_Cliente]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [fk_LocalBarbero] FOREIGN KEY([localbarbero_id])
REFERENCES [dbo].[LocalBarbero] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [fk_LocalBarbero]
GO
ALTER TABLE [dbo].[EstiloCorte]  WITH CHECK ADD  CONSTRAINT [FK_EstiloCorte_LocalBarbero_ID] FOREIGN KEY([LocalId])
REFERENCES [dbo].[LocalBarbero] ([Id])
GO
ALTER TABLE [dbo].[EstiloCorte] CHECK CONSTRAINT [FK_EstiloCorte_LocalBarbero_ID]
GO
ALTER TABLE [dbo].[LocalBarbero]  WITH CHECK ADD  CONSTRAINT [FK__LocalBarb__Barbe__18EBB532] FOREIGN KEY([BarberoId])
REFERENCES [dbo].[Barberos] ([Id])
GO
ALTER TABLE [dbo].[LocalBarbero] CHECK CONSTRAINT [FK__LocalBarb__Barbe__18EBB532]
GO
USE [master]
GO
ALTER DATABASE [BarberyApp] SET  READ_WRITE 
GO
