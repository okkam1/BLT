/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [PropertyID]
      ,[ContactDate]
      ,[ContactTypeCode]
      ,[ContactNotes]
      ,[YoungKids]
      ,[ReviewStatusCode]
      ,[UpdateDate]
  FROM [TESTAccessImport].[dbo].[PropertyContact]

