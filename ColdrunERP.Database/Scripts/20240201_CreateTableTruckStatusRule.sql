CREATE TABLE [dbo].[TruckStatusRule] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[StatusFromId] int NOT NULL,
	[StatusToId] int NOT NULL,

	CONSTRAINT [PK_TruckStatusRule] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_TruckStatusRule_TruckStatus_From] FOREIGN KEY ([StatusFromId]) REFERENCES [dbo].[TruckStatus]([Id]),
	CONSTRAINT [FK_TruckStatusRule_TruckStatus_To] FOREIGN KEY ([StatusToId]) REFERENCES [dbo].[TruckStatus]([Id])
);