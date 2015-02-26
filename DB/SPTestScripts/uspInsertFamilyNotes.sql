USE [LCCHPDev]
GO

DECLARE	@return_value int,
		@InsertedNotesID int

EXEC	@return_value = [dbo].[usp_InsertFamilyNotes]
		@Family_ID = 2763,
		@Notes = N'more information',
		@InsertedNotesID = @InsertedNotesID OUTPUT

SELECT	@InsertedNotesID as N'@InsertedNotesID'

SELECT	'Return Value' = @return_value

GO

Select * from FamilyNotes AS FN
LEFT OUTER JOIN FAMILY AS F ON FN.FamilyID = F.FamilyID