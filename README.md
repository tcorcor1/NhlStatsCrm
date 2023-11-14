# E5NhlCrm

- [Summary](#summary)
- [Technologies](#technologies)
- [Network](#network)
- [Local Development](#local-development)
- [OpenAPI](./docs/OpenAPI.md)

🚧 🚧 DISCLAIMER 🚧 🚧

11/14/2023 - Unfortunately as of November 2023 the NHL API has moved to https://api-web.nhle.com/. It has also undergone a lot of changes so this project will no longer work in it's current state. This is a pretty new development so documentation is catching up but if you would like to learn more about the new API please see this: https://api-web.nhle.com/application.wadl

### Summary

The goal of this project is to take all players, player stats and game logs from the NHL REST endpoint on a daily basis and load those into a Dynamics 365 instance. There will be multiple scheduled Azure functions that will run overnight and patch players, player stats and game logs in that order. The API supports a variety of GET requests although this API isn't intended for use by end-users. Automapper is used primarily on those GET requests to simplify the responses to the clients coming from CRM. Organically, the Dynamics REST endpoint will return more information about the entity we want the client to know about and in a less consumable format.

### Technologies

- .NET 6
- CQRS/Mediatr
- Automapper
- Node/TypeScript
- CD with Github Actions
- Power Platform Dataverse Client
- Azure
  - App Service (F1 tier)
  - Functions (consumption)
  - API Management (consumption)
  - Key Vault
  - Application Insights

### Network

<div>
  <img align="center" src="./docs/img/E5NhlCrmProd.png" />
</div>

### Local Development

Project contains a proxy Node/TypeScript project that is serving as a surrogate API management gateway. Although Microsoft offers some local API management solution I prefer this for simple use cases.

One of the API management gateway's responsibilities will be to add a secret to the request header in order to communicate with the app service environment.

Since this is a $0 spent project we are using all free/consumption tiers and do not have static IPs. Validation of the request header will be done by custom middleware in the app service environment. JWT validation will be added in the future to the API management gateway.

The node proxy uses the http-proxy-middleware, dotenv and express in addition to the other dev depenencies (TypeScript, ts-node, nodemon). It simply takes all incoming requests and adds a header from your .env file.

```javascript
app.use(
  "/",
  createProxyMiddleware({
    target: process.env.E5_NHL_CRM_ASE as string,
    changeOrigin: true,
    onProxyReq: (proxyReq, req, res) => {
      proxyReq.setHeader(
        "E5_NHL_CRM_ASE_KEY",
        process.env.E5_NHL_CRM_ASE_KEY as string
      );
    },
  })
);
```
