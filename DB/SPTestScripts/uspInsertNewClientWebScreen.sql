USE [LeadTrackingTesting-Liam]
GO

DECLARE	@return_value int,
		@ClientID int

EXEC	@return_value = [dbo].[usp_InsertNewClientWebScreen]
		@Family_ID = 928,
		@First_Name = N'John',
		@Middle_Name = N'J.',
		@Last_Name = N'Wayne',
		@Birth_Date = '19320915',
		@Gender_ = N'M',
		@Language_ID = 1,
		@Moved_ = NULL,
		@Travel = NULL,
		@Travel_Notes = NULL,
		@Out_of_Site = NULL,
		@Hobby_ID = 17,
		@Hobby_Notes = N'he pretty much defined this hobby',
		@Child_Notes = N'i wouldn''t call him a child.',
		@is_Smoker = 1,
		@Occupation_ID = 14,
		@Occupation_Start_Date = '19520101',
		@ClientID = @ClientID OUTPUT

SELECT	@ClientID as N'@ClientID'

SELECT	'Return Value' = @return_value

GO
