/****** Script for SelectTopNRows command from SSMS  ******/
   use LCCHPTest
   GO

  select * from TESTAccessImport..BloodPbResults

 select distinct(UPPER(LabName)) from TESTAccessImport..BloodPbResults order by UPPER(LabName)


 insert into Lab (LabName)
   select distinct LabName from TESTAccessImport..BloodPbResults where labName is not null

Select * from Lab