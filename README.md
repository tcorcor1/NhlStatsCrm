# NhlStatsCrm

- [Summary](#summary)
- [Technologies](#technologies)
- [Network](#network)
- [Local Development](#local-development)
- [OpenAPI](./docs/OpenAPI.md)
- [NHL REST API Docs](#nhl-rest-api-docs)

### Summary

The purpose of this project is to take all players and stats from the NHL REST endpoint and load into Dynamics 365 on a daily basis.

There are scheduled Azure functions that will run overnight and upsert players/stats using the NHL API's id's as an alternate/foreign key.

The API supports some GET requests although this API isn't intended for use by end-users since data should be observed in Dynamics 365.

### Technologies

- .NET 6
- Mediatr
- Automapper
- Microsoft Identity Platform
- CD with Github Actions
- Power Platform Dataverse Client
- Azure
  - App Service
  - Functions

### Network

<div>
  <img align="center" src="./docs/img/NhlStatsCrmAzure.png" />
</div>

### Local Development

### NHL REST API Docs

Big thanks to the legends below. Without you all paving the way, starting projects like this would be much harder. Thank you! 🙏

- [Kevin Sidwar](https://www.kevinsidwar.com/) | Got the ball rolling

- [Jon Ursenbach](https://github.com/erunion) | Built out an [OpenAPI 3 spec](https://github.com/erunion/sport-api-specifications)

- [Drew Hynes](https://github.com/dword4) | Created and maintains the repo used in this project: [NHL REST API Repo](https://gitlab.com/dword4/nhlapi)
