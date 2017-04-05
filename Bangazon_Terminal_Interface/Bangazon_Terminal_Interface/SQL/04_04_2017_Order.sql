USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 4/4/2017 5:17:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderTotalPrice] [money] NOT NULL
) ON [PRIMARY]

GO

