USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 4/4/2017 5:15:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Street] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Zipcode] [int] NULL,
	[Phone] [int] NULL
) ON [PRIMARY]

GO

