# Roulette

# ENDPOINTS

# POST ROULETTE

_/game/roulette
```
Response: 
{
    "id": 1,
    "isOpen": false,
    "betResult": 0
}
```
#GET ROULETTES
/game/roulettes

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


#PUT ROULETTE - OPEN Roulette.

/game/openbet/roulette/1

Response: Roulette with Id: 4 has been opened.

#GET Users
/game/users

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

#POST User
http://localhost:3020/game/user

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
