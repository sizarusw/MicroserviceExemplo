# AspNetCoreApiGateway

API Gateway with Ocelot in ASP.NET Core.

## API Gateway Pattern

[Microsoft Documentation](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern)

## Nuget Package

[Ocelot](https://github.com/ThreeMammals/Ocelot)

## Features

* Routing
* Request Aggregation
* Service Discovery with Consul & Eureka
* Service Fabric
* WebSockets
* Authentication
* Authorisation
* Rate Limiting
* Caching
* Retry policies / QoS
* Load Balancing
* Logging / Tracing / Correlation
* Headers / Query String / Claims Transformation
* Custom Middleware / Delegating Handlers
* Configuration / Administration REST API
* Platform / Cloud Agnostic

## Microservices

### Customers

[https://**localhost:9030**/api/customers](https://localhost:9030/api/customers)

[https://**localhost:9030**/api/customers/1](https://localhost:9030/api/customers/1)

### Products

[https://**localhost:9050**/api/products](https://localhost:9050/api/products)

[https://**localhost:9050**/api/products/1](https://localhost:9050/api/products/1)

## API Gateway

[https://**localhost:9010**/customers](https://localhost:9010/customers)

[https://**localhost:9010**/customers/1](https://localhost:9010/customers/1)

[https://**localhost:9010**/products](https://localhost:9010/products)

[https://**localhost:9010**/products/1](https://localhost:9010/products/1)
