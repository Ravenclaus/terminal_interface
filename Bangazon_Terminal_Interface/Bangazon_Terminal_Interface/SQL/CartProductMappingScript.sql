USE [RavenClausBangazon]
GO

/****** Object:  Table [dbo].[CartProductMapping]    Script Date: 4/8/2017 12:18:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CartProductMapping](
	[CartProductId] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_CartProductMapping] PRIMARY KEY CLUSTERED 
(
	[CartProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CartProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_CartProductMapping_Cart] FOREIGN KEY([CartId])
REFERENCES [dbo].[Cart] ([CartId])
GO

ALTER TABLE [dbo].[CartProductMapping] CHECK CONSTRAINT [FK_CartProductMapping_Cart]
GO

ALTER TABLE [dbo].[CartProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_CartProductMapping_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[CartProductMapping] CHECK CONSTRAINT [FK_CartProductMapping_Product]
GO

