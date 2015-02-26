USE [LCCHPDev]
GO

DECLARE	@return_value int,
		@ClientID int

EXEC	@return_value = [dbo].[usp_InsertNewClientWebScreen]
		@Family_ID = 1337,
		@First_Name = N'Diane',
		@Last_Name = N'Fujikawa',
		@Birth_Date = '19880606',
		@Gender_ = NULL,
		@Language_ID = NULL,
		@Ethnicity_ID = NULL,
		@Moved_ = NULL,
		@Travel = NULL,
		@Travel_Notes = NULL,
		@Out_of_Site = NULL,
		@Hobby_ID = NULL,
		@Hobby_Notes = NULL,
		@Child_Notes = NULL,
		@Release_Notes = NULL,
		@is_Smoker = NULL,
		@Occupation_ID = NULL,
		@Occupation_Start_Date = NULL,
		@ClientID = @ClientID OUTPUT

SELECT	@ClientID as N'@ClientID'

SELECT	'Return Value' = @return_value

GO

-- select * from Person order by personID desc
--select * from ErrorLog order by errorID desc