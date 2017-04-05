USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[PaymentType]    Script Date: 4/4/2017 5:16:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentType](
	[PaymentTypeId] [int] NOT NULL,
	[PaymentType] [varchar](50) NULL,
	[AccountNumber] [int] NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]

GO

