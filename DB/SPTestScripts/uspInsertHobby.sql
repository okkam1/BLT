USE [LCCHPDev]
GO

DECLARE	@return_value int,
		@NewHobbyID int

EXEC	@return_value = [dbo].[usp_InsertHobby]
		@HobbyName = N'LeadMining',
		@HobbyDescription = N'Digging for lead in local areas',
		@LeadExposure = 1,
		@NewHobbyID = @NewHobbyID OUTPUT

SELECT	@NewHobbyID as N'@NewHobbyID'

SELECT	'Return Value' = @return_value

GO

select * from Hobby