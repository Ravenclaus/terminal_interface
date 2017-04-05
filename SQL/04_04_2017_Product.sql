USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/4/2017 5:17:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](50) NULL,
	[ProductPrice] [money] NULL
) ON [PRIMARY]

GO

