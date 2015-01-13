USE [LeadTrackingTesting-Liam]
GO

DECLARE	@return_value int,
		@NewPropertySampleResultsID int

EXEC	@return_value = [dbo].[usp_InsertPropertySampleResults]
		@isBaseline = NULL,
		@PropertyID = 11308,
		@LabSubmissionDate = '20141211',
		@LabID = 133,
		@SampleTypeID = 3,
		@Notes = NULL,
		@NewPropertySampleResultsID = @NewPropertySampleResultsID OUTPUT

SELECT	@NewPropertySampleResultsID as N'@NewPropertySampleResultsID'

SELECT	'Return Value' = @return_value

GO

select * from PropertySampleResults