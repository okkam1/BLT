USE [LCCHPDev]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_SLListNursingMothers]
		@PersonID = NULL,
		@Count = 0,
		@DEBUG = 1

SELECT	'Return Value' = @return_value

GO
