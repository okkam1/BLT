USE [LCCHPDev]
GO

DECLARE	@return_value int,
		@InsertedNotesID int

EXEC	@return_value = [dbo].[usp_InsertBloodTestResultsNotes]
		@BloodTestResults_ID = 18289,
		@Notes = NULL,
		@InsertedNotesID = @InsertedNotesID OUTPUT

SELECT	@InsertedNotesID as N'@InsertedNotesID'

SELECT	'Return Value' = @return_value

GO

Select * from BloodTestResultsNotes order by BloodTestResultsNotesID desc