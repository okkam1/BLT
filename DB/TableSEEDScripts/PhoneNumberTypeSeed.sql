USE [LeadTrackingTesting-Liam]
GO

DECLARE	@return_value int,
		@PhoneNumberTypeID_OUTPUT int

EXEC	@return_value = [dbo].[usp_InsertPhoneNumberType]
		@PhoneNumberTypeName = 'Home Phone',
		@PhoneNumberTypeID_OUTPUT = @PhoneNumberTypeID_OUTPUT OUTPUT

SELECT	@PhoneNumberTypeID_OUTPUT as N'@PhoneNumberTypeID_OUTPUT'

SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[usp_InsertPhoneNumberType]
		@PhoneNumberTypeName = 'Work Phone',
		@PhoneNumberTypeID_OUTPUT = @PhoneNumberTypeID_OUTPUT OUTPUT

SELECT	@PhoneNumberTypeID_OUTPUT as N'@PhoneNumberTypeID_OUTPUT'

SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[usp_InsertPhoneNumberType]
		@PhoneNumberTypeName = 'Mobile Phone',
		@PhoneNumberTypeID_OUTPUT = @PhoneNumberTypeID_OUTPUT OUTPUT

SELECT	@PhoneNumberTypeID_OUTPUT as N'@PhoneNumberTypeID_OUTPUT'

SELECT	'Return Value' = @return_value
GO
