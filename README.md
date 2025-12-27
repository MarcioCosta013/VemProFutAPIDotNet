# VemProFutAPIDotNet

Uma API REST do Projeto VemProFutFullstack só que feita em .NET usando o C# como linguagem
e aplicando estrutura Clean Architecture/DDD o padrão mais adotado em projetos
médios/grandes no mercado .NET atual.

## Estrutura do Projeto
```
	VemProFutApi/
	 ├── VemProFutApi.Api            → Controllers, DTOs, Swagger
	 ├── VemProFutApi.Application    → Services, UseCases, Interfaces
	 ├── VemProFutApi.Domain         → Entities, ValueObjects, Regras de negócio
	 ├── VemProFutApi.Infrastructure → Repositories, EF Core, Configuração DB
	 └── VemProFutApi.Tests          → Testes unitários e integração

```
