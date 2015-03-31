select P.PersonID,LastName,FirstName,E.Ethnicity from Person AS P 
LEFT OUTER JOIN PersontoEthnicity AS P2E on P.PersonID = P2E.PErsonID
LEFT OUTER JOIN Ethnicity AS E on P2E.EthnicityID = E.EthnicityID where P.PersonID = 2