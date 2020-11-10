# Roulette

# ENDPOINTS

# POST ROULETTE
/game/roulette
```
Body:
{}

Response: 
{
    "id": 1,
    "isOpen": false,
    "betResult": 0
}
```
# GET ROULETTES
/game/roulettes
```
Response:
[
    {
        "id": 1,
        "isOpen": true,
        "betResult": 7
    },
    {
        "id": 2,
        "isOpen": false,
        "betResult": 0
    },
    {
        "id": 3,
        "isOpen": false,
        "betResult": 0
    },
    {
        "id": 4,
        "isOpen": false,
        "betResult": 0
    }
]
```

# PUT ROULETTE - OPEN Roulette.
/game/openbet/roulette/id
```
Response: Roulette with Id: 4 has been opened.
```

# PUT ROULETTE - Play Roulette.
/game/openbet/roulette/id/play
```
Response: Roulette with Id: 1 has been played. Winner number is: 28
```

# GET Users
/game/users
```
response:
[
    {
        "id": 1,
        "idRoulette": 4,
        "credit": "1000",
        "bet": "500",
        "rouletteNumber": 6,
        "rouletteColor": "Red"
    },
    {
        "id": 2,
        "idRoulette": 4,
        "credit": "5000",
        "bet": "2000",
        "rouletteNumber": 30,
        "rouletteColor": "Red"
    }
]
```

# POST User
/game/user

```
Body:
{
    "IdRoulette": 4,
    "Credit" : "1000",
    "Bet": "500",
    "RouletteNumber": 6,
    "RouletteColor": "Red"
}

response: 
{
    "id": 1,
    "idRoulette": 4,
    "credit": "1000",
    "bet": "500",
    "rouletteNumber": 6,
    "rouletteColor": "Red"
}
```
