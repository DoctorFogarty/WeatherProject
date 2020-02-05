CREATE PROCEDURE [dbo].[ValidateZipCode]
	@ZipCode int
AS
	SELECT 1 AS [VALID] FROM dbo.CityData WHERE ZipCode = @ZipCode
RETURN 0
