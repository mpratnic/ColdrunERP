CREATE TABLE [dbo].[Truck] (
	[Id] bigint IDENTITY(1,1) NOT NULL,
	[Code] nvarchar(50) NOT NULL,
	[Name] nvarchar(200) NOT NULL,
	[StatusId] int NOT NULL,
	[Description] nvarchar(1000) NULL,

	CONSTRAINT [PK_Truck] PRIMARY KEY ([Id]),
	CONSTRAINT [UQ_Truck_Code] UNIQUE ([Code]),
	CONSTRAINT [FK_Truck_TruckStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[TruckStatus]([Id])
);