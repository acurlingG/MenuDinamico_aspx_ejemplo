USE [CAFETERIA]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 03/11/2024 22:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UsuarioId] [int] NULL,
	[Usuario] [nchar](10) NULL,
	[Clave] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 03/11/2024 22:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] NULL,
	[opcion] [varchar](50) NULL,
	[url] [varchar](50) NULL
) ON [PRIMARY]
GO
