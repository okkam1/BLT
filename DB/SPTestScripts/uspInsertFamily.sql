USE [LeadTrackingTesting-Liam]
GO

DECLARE	@Family_ID int

EXEC	[dbo].[usp_InsertFamily]
		@LastName = N'Quan',
		@NumberofSmokers = NULL,
		@PrimaryLanguageID = 2,
		@Pets = 0,
		@inandout = 0,
		@PrimaryPropertyID = 5697,
		@FID = @Family_ID OUTPUT

SELECT	@Family_ID as N'@FID'


GO
