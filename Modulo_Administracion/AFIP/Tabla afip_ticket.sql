USE [CarritoCompras]
GO
/****** Object:  Table [dbo].[ticket_autenticacion]    Script Date: 09/05/2021 22:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].afip_ticket(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] [nvarchar](max) NOT NULL,
	[sign] [nvarchar](max) NOT NULL,
	[expiration_time] [datetime] NOT NULL,
	[generation_time] [datetime] NOT NULL,
	[x_doc_request] [nvarchar](max) NOT NULL,
	[x_doc_response] [nvarchar](max) NOT NULL,
	ambiente [nvarchar] (50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
