USE LCCHPTEST
GO

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ActionStatusCode]
      ,[ActionStatus]
  FROM [TESTAccessImport].[dbo].[lkActionStatus]


insert into [Status] (StatusName,StatusDescription)
select ActionStatus,ActionStatusCode from TestAccessImport..lkActionStatus

select * from [status]

Select * from TargetStatus

update TS
Set TS.TargetType = 'CleanupStatus'
from TargetStatus as TS
JOIN TESTAccessImport..lkCleanupStatus AS CS 
ON TS.StatusName = CS.CleanupStatus AND TS.StatusDescription = CS.CleanupStatusCode

Truncate Table TargetStatus
select getDate()

-- Restore Point  2015-03-05 22:40:41.757

