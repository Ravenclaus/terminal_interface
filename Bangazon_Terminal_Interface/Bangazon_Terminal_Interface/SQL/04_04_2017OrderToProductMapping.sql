USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[OrderToProductMappingTable]    Script Date: 4/4/2017 5:18:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderToProductMappingTable](
	[OrderToProductMappingId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]

GO

