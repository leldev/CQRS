# CQRS pattern

CQRS stand for Command Query Responsability Segregation.  It s just a small pattern. This pattern was first introduced by Greg Young and Udi Dahan. They took inspiration from a pattern called Command Query Separation which was defined by Bertrand Meyer in his book “Object Oriented Software Construction”. The main idea behind CQS is: “A method should either change state of an object, or return a result, but not both. In other words, asking the question should not change the answer. More formally, methods should return a value only if they are referentially transparent and hence possess no side effects.” (Wikipedia) Because of this we can divide a methods into two sets:

- **Commands**: change the state of an object or entire system (sometimes called as modifiers or mutators).
- **Queries**: return results and do not change the state of an object.

![](https://sookocheff.com/post/architecture/what-is-cqrs/reads-and-writes.png)

# Todo Item Project

This is a simple project to explain CQRS with a CRUD of Todo Items.

- [API with ASP.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)
- [AutoMapper](https://automapper.org/)
- [Swagger](https://swagger.io/)
- [Azure Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/introduction)

## Projects & Dependencies

- **SV.CQRS.Domain** containing all the domain logic of the solution (for both read and write models). (has no dependency)
- **SV.CQRS.Api** API with ASP.NET Core project that hosting the web infrastructure code. 
    - Use Swagger (/swagger) to expose endpoins
    - `appsetting.json` has the [Azure Cosmos Emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator) information.
    - `ServiceCosmosDbExtension.cs` adds dependencies and create de database a collection.
    - `CosmosDbRepository.cs` implements Repository pattern to manipulate the data.
