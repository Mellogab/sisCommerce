use sisCommerce

drop table [Sale]
CREATE TABLE [dbo].[Sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[totalPrice] [float] NOT NULL,
	[method] [varchar] NOT NULL,
	[status] [int] not null default((0)),
	[created_at] [varchar],
	[finished_at][varchar],
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [id_user] FOREIGN KEY([idUser])
REFERENCES [dbo].[Users] ([id])
GO

/* Table SaleItems */

drop table [SaleItems]
CREATE TABLE [dbo].[SaleItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProduct] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[idSale] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SaleItems]  WITH CHECK ADD  CONSTRAINT [id_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Products] ([id])
GO

GO
ALTER TABLE [dbo].[SaleItems]  WITH CHECK ADD  CONSTRAINT [id_sale] FOREIGN KEY([idSale])
REFERENCES [dbo].[Sale] ([id])
GO