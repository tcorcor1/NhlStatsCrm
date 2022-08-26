```javascript
{
  "openapi": "3.0.1",
  "info": {
    "title": "NhlStatsCrm.WebAPI",
    "version": "1.0"
  },
  "paths": {
    "/Players": {
      "get": {
        "tags": [
          "Players"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Players"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Player"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Player"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Player"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Players/{playerId}": {
      "get": {
        "tags": [
          "Players"
        ],
        "parameters": [
          {
            "name": "playerId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats": {
      "get": {
        "tags": [
          "Stats"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats/{statId}": {
      "get": {
        "tags": [
          "Stats"
        ],
        "parameters": [
          {
            "name": "statId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Stats/player": {
      "patch": {
        "tags": [
          "Stats"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Stat"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Stat"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Stat"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Teams": {
      "get": {
        "tags": [
          "Teams"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Teams"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Team"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Team"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Team"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/Teams/{teamId}": {
      "get": {
        "tags": [
          "Teams"
        ],
        "parameters": [
          {
            "name": "teamId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Conference": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Division": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "nameShort": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          },
          "abbreviation": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Franchise": {
        "type": "object",
        "properties": {
          "franchiseId": {
            "type": "integer",
            "format": "int32"
          },
          "teamName": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Person": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "fullName": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Player": {
        "type": "object",
        "properties": {
          "person": {
            "$ref": "#/components/schemas/Person"
          },
          "jerseyNumber": {
            "type": "string",
            "nullable": true
          },
          "position": {
            "$ref": "#/components/schemas/Position"
          },
          "teamId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Position": {
        "type": "object",
        "properties": {
          "code": {
            "type": "string",
            "nullable": true
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "type": {
            "type": "string",
            "nullable": true
          },
          "abbreviation": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RosterInfo": {
        "type": "object",
        "properties": {
          "playerCollection": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Player"
            },
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Stat": {
        "type": "object",
        "properties": {
          "playerId": {
            "type": "integer",
            "format": "int32"
          },
          "seasonName": {
            "type": "string",
            "nullable": true
          },
          "timeOnIce": {
            "type": "string",
            "nullable": true
          },
          "assists": {
            "type": "integer",
            "format": "int32"
          },
          "goals": {
            "type": "integer",
            "format": "int32"
          },
          "pim": {
            "type": "integer",
            "format": "int32"
          },
          "shots": {
            "type": "integer",
            "format": "int32"
          },
          "games": {
            "type": "integer",
            "format": "int32"
          },
          "hits": {
            "type": "integer",
            "format": "int32"
          },
          "powerPlayGoals": {
            "type": "integer",
            "format": "int32"
          },
          "powerPlayPoints": {
            "type": "integer",
            "format": "int32"
          },
          "powerPlayTimeOnIce": {
            "type": "string",
            "nullable": true
          },
          "evenTimeOnIce": {
            "type": "string",
            "nullable": true
          },
          "penaltyMinutes": {
            "type": "string",
            "nullable": true
          },
          "faceOffPct": {
            "type": "number",
            "format": "float"
          },
          "shotPct": {
            "type": "number",
            "format": "float"
          },
          "gameWinningGoals": {
            "type": "integer",
            "format": "int32"
          },
          "overTimeGoals": {
            "type": "integer",
            "format": "int32"
          },
          "shortHandedGoals": {
            "type": "integer",
            "format": "int32"
          },
          "shortHandedPoints": {
            "type": "integer",
            "format": "int32"
          },
          "shortHandedTimeOnIce": {
            "type": "string",
            "nullable": true
          },
          "blocked": {
            "type": "integer",
            "format": "int32"
          },
          "plusMinus": {
            "type": "integer",
            "format": "int32"
          },
          "points": {
            "type": "integer",
            "format": "int32"
          },
          "shifts": {
            "type": "integer",
            "format": "int32"
          },
          "timeOnIcePerGame": {
            "type": "string",
            "nullable": true
          },
          "evenTimeOnIcePerGame": {
            "type": "string",
            "nullable": true
          },
          "shortHandedTimeOnIcePerGame": {
            "type": "string",
            "nullable": true
          },
          "powerPlayTimeOnIcePerGame": {
            "type": "string",
            "nullable": true
          },
          "gamesStarted": {
            "type": "integer",
            "format": "int32"
          },
          "goalAgainstAverage": {
            "type": "number",
            "format": "double"
          },
          "savePercentage": {
            "type": "number",
            "format": "double"
          },
          "shotsAgainst": {
            "type": "integer",
            "format": "int32"
          },
          "goalsAgainst": {
            "type": "integer",
            "format": "int32"
          },
          "saves": {
            "type": "integer",
            "format": "int32"
          },
          "wins": {
            "type": "integer",
            "format": "int32"
          },
          "losses": {
            "type": "integer",
            "format": "int32"
          },
          "shutouts": {
            "type": "integer",
            "format": "int32"
          },
          "evenStrengthSavePercentage": {
            "type": "number",
            "format": "double"
          },
          "powerPlaySavePercentage": {
            "type": "number",
            "format": "double"
          },
          "shortHandedSavePercentage": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "Team": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          },
          "venue": {
            "$ref": "#/components/schemas/Venue"
          },
          "abbreviation": {
            "type": "string",
            "nullable": true
          },
          "teamName": {
            "type": "string",
            "nullable": true
          },
          "locationName": {
            "type": "string",
            "nullable": true
          },
          "firstYearOfPlay": {
            "type": "string",
            "nullable": true
          },
          "division": {
            "$ref": "#/components/schemas/Division"
          },
          "conference": {
            "$ref": "#/components/schemas/Conference"
          },
          "franchise": {
            "$ref": "#/components/schemas/Franchise"
          },
          "rosterInfo": {
            "$ref": "#/components/schemas/RosterInfo"
          },
          "shortName": {
            "type": "string",
            "nullable": true
          },
          "officialSiteUrl": {
            "type": "string",
            "nullable": true
          },
          "franchiseId": {
            "type": "integer",
            "format": "int32"
          },
          "active": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "Timezone": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "nullable": true
          },
          "offset": {
            "type": "integer",
            "format": "int32"
          },
          "tz": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Venue": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "link": {
            "type": "string",
            "nullable": true
          },
          "city": {
            "type": "string",
            "nullable": true
          },
          "timeZone": {
            "$ref": "#/components/schemas/Timezone"
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```
