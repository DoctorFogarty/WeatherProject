CREATE PROCEDURE [dbo].[GetWeatherDataByZipCode]
	@ZipCode int 
AS
		SELECT TOP 1 C.[Name] as [City], C.[State] as [State], W.[WeatherType], W.[Temperature], W.[Humidity], W.[DewPoint], W.[Pressure], W.[WindSpeed], W.[WindDirection], W.[IMG_URL]
		
		FROM dbo.WeatherData W

		JOIN dbo.CityData C on WeatherDataID = W.id

		WHERE C.ZipCode = @ZipCode
RETURN 0