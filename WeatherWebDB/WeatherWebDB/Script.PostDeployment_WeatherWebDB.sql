/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO CityData AS TARGET
USING (VALUES
        (30901, 'Augusta', 'Georgia', 1),
        (30907, 'Martinez', 'Georgia', 2),
        (30809, 'Evans', 'Georgia', 3)
)
AS SOURCE ([ZipCode], [Name], [State], [WeatherDataID])
ON Target.ZipCode = Source.ZipCode
WHEN NOT MATCHED BY TARGET THEN
INSERT ([ZipCode], [Name], [State], [WeatherDataID])
VALUES ([ZipCode], [Name], [State], [WeatherDataID]);

MERGE INTO WeatherData AS TARGET
USING (VALUES
        (1, 'Sunny', 75, 35, 45, 30.00, 5, 'S', 'sun.png'),
        (2, 'Rain', 68, 68, 60, 29.80, 15, 'NNE', 'rain.png'),
        (3, 'Snow', 20, 85, 23, 29.60, 5, 'WSW', 'snow.png')
)
AS SOURCE ([id], [WeatherType], [Temperature], [Humidity], [DewPoint], [Pressure], [WindSpeed], [WindDirection], [IMG_URL])
ON Target.id = Source.id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([WeatherType], [Temperature], [Humidity], [DewPoint], [Pressure], [WindSpeed], [WindDirection], [IMG_URL])
VALUES ([WeatherType], [Temperature], [Humidity], [DewPoint], [Pressure], [WindSpeed], [WindDirection], [IMG_URL]);