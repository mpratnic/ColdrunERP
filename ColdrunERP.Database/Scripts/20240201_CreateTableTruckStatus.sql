CREATE TABLE [dbo].[TruckStatus] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,

	CONSTRAINT [PK_TruckStatus] PRIMARY KEY ([Id])
);