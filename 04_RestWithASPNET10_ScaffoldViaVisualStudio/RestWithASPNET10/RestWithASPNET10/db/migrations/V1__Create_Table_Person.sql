CREATE TABLE dbo.Person (
	[id] bigint NOT NULL IDENTITY,
	[first_name] NVARCHAR(80) NOT NULL,
	[last_name] NVARCHAR(80) NOT NULL,
	[address] NVARCHAR(100) NOT NULL,
	[gender] NVARCHAR(6) NOT NULL,
	PRIMARY KEY ([id])
	);