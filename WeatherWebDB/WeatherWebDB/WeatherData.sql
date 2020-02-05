CREATE TABLE dbo.WeatherData (
	[id] INT IDENTITY (1, 1) NOT NULL,
	[WeatherType] NVARCHAR(200),
	[Temperature] INT,
	[Humidity] INT,
	[DewPoint] INT,
	[Pressure] DECIMAL,
	[WindSpeed] INT,
	[WindDirection] NVARCHAR(3),
	[IMG_URL] NVARCHAR(200) NULL,
	CONSTRAINT [PK_dbo.WeatherData] PRIMARY KEY CLUSTERED ([id] ASC)
);
