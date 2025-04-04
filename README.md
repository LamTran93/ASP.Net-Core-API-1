<h1>How to run</h1>

Use dotnet CLI to run the project. In ASP.NET Core API #1 run the command <code>dotnet run</code>. Or use the Visual Studio to run the project.

<h1>Structure</h1>

- The app use the Clean Architecture. Project Reference: ASP.NET Core API #1 -> Infrastructure -> Application -> Domain.
- Public contract with these interfaces: IJobRepository, IJobService.
- Using DI and IoC to inject service into controller.

<img src="https://devblogs.microsoft.com/ise/wp-content/uploads/sites/55/2024/06/clean-arch.png" />
