Invoke-WebRequest `
    -Uri http://localhost:7071/api/addguesttrigger `
    -ContentType application/json `
    -Method Post `
    -Body ('{"firstname": "Daniele", "lastname": "Tulli", "age": 0, "address": "", "participation": true, "hasBeenDelivered": true, "participationResponse": 0, "table": "", "dietNotes": "", "menu": 0, "notes": "" }') 