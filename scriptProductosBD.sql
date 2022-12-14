USE [Informatica]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 16/6/2021 20:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] NOT NULL,
	[nombreMarca] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 16/6/2021 20:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[codigo] [int] NOT NULL,
	[detalle] [varchar](50) NOT NULL,
	[tipo] [int] NOT NULL,
	[marca] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (1, N'HP')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (2, N'EPSON')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (3, N'COMPAQ')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (4, N'DELL')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (5, N'ASUS')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (6, N'BANGHO')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (7, N'SONY')
GO
INSERT [dbo].[Productos] ([codigo], [detalle], [tipo], [marca], [precio], [fecha]) VALUES (1, N'Pavilion', 1, 1, 150000, CAST(N'2022-05-01' AS Date))
INSERT [dbo].[Productos] ([codigo], [detalle], [tipo], [marca], [precio], [fecha]) VALUES (2, N'Studio', 2, 4, 170000, CAST(N'2022-05-31' AS Date))
GO
