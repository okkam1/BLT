USE [LeadTrackingTesting-Liam]
GO

DECLARE	@return_value int,
		@NewHobbyID int

EXEC	@return_value = [dbo].[usp_InsertHobby]
		@HobbyName = N'Hackey Sack',
		@HobbyDescription = N'keeping a bean filled ball from touching the ground without using yoru feet',
		@NewHobbyID = @NewHobbyID OUTPUT

SELECT	@NewHobbyID as N'@NewHobbyID'

SELECT	'Return Value' = @return_value

GO

Select * from Hobby