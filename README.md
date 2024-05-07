GET /api/User/GetAllUsers
Beskrivning: Hämtar lista av alla användare
Response: Lista av användare
Statuskoder: 
  200 Ok Lyckades hämta listan, 
  500 Internal Server Error
  
GET /api/User/GetAllInterests
Beskrivning: Hämtar lista av alla intressen
Response: Lista av intressen
Statuskoder: 
  200 Ok Lyckades hämta listan, 
  500 Internal Server Error
  
GET /api/User/GetInterests/{userId}
Beskrivning: Hämtar alla intressen kopplade till userID
Response: Lista av intressen för användaren
Statuskoder: 
  200 Ok lyckades hämta intressen,
  404 Not found angivet userId matchade ingen användare i databas
  500 Internal Server Error

GET /api/User/GetLinks/{userId}
Beskrivning: Hämtar alla länkar kopplade till userID
Response: Lista av Användarens länkar
Statuskoder: 
  200 Ok lyckades hämta länkar,
  404 Not Found, angivet userId matchade ingen användare i databas
  500 Internal Server Error

POST /api/User/AddInterest/{userId}
Beskrivning: Kopplar nytt intresse till användare
Response: Bekräftar att nytt intresse lagts till för användaren
Statuskoder:
  200 Ok Intresset kopplades,
  400 Bad Request Id för användare eller intresse matchades ej
  500 Internal Server Error

POST /api/User/AddLinkToInterest/{userId}
Beskrivning: Lägger till ny länk för en användares intresse
Response: Bekräftar att nytt url lagts till för användarens intresse
Statuskoder:
  200 Ok Länk kopplade för användarens intresse,
  400 Bad Request Id för användare eller intresse matchades ej eller url fält tomt
  500 Internal Server Error

