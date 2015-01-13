USE [LeadTrackingTesting-Liam]
GO

DECLARE	@return_value int,
		@NewSampleTypeID int

EXEC	@return_value = [dbo].[usp_InsertSampleType]
		@SampleTypeName = N'Cheek swab',
		@SampleTypeDescription = N'swab from inside of cheek',
		@NewSampleTypeID = @NewSampleTypeID OUTPUT

SELECT	@NewSampleTypeID as N'@NewSampleTypeID'

SELECT	'Return Value' = @return_value

GO
