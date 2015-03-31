select P.PersonID,LastName,FirstName, L.LanguageName 
from Person AS P 
LEFT OUTER JOIN PersontoLanguage AS P2L on P.PersonID = P2L.PersonID LEFT 
OUTER JOIN Language AS L on P2L.LanguageID = L.LanguageID 
where P.PersonID = 2874