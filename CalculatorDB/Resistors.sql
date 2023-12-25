CREATE TABLE [dbo].[Resistors]
(
  [Id] INT IDENTITY(1,1) NOT NULL,
  [RingCount] INT NULL,
  [TempK] INT NULL,
  [Resistance] FLOAT (53) NULL,
  [Tolerance] FLOAT (53) NULL,
  [Ring1] NVARCHAR (MAX) NULL,
  [Ring2] NVARCHAR (MAX) NULL,
  [Ring3] NVARCHAR (MAX) NULL,
  [Ring4] NVARCHAR (MAX) NULL,
  [Ring5] NVARCHAR (MAX) NULL,
  [Ring6] NVARCHAR (MAX) NULL,
  [deviationFor5] NVARCHAR (MAX) NULL,
  [precisions] NVARCHAR (MAX) NULL,
  [prefixes] NVARCHAR (MAX) NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
)
