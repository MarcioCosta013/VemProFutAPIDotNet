# VemProFutAPI - Versão .NET

<a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=dotnet,mysql,docker,git,github,githubactions,md&theme=dark" />
</a>


##### Uma API REST do meu Projeto Pessoal chamado [VemProFutFullstack](https://github.com/MarcioCosta013/VemProFutFullStack) , só que agora com a API feita em .NET usando o C# como linguagem, e aplicando estrutura Clean Architecture/DDD o padrão mais adotado em projetos médios/grandes no mercado .NET atual.

Meu Objetivo Com esse projeto é colocar em prática todo conhecimento que obtive em mais de 5 anos de estudo com uma regra de negocio que eu mesmo inventei
e fiz o levantamento de requisitos e modelagem. (Caso queira ver o a documentação mais detalhada de como é a logica do projeto visite o projeto principal
clicando [aqui](https://github.com/MarcioCosta013/VemProFutFullStack).

## Estrutura do Projeto
```
	VemProFutApi/
	 ├── VemProFutApi.Api            → Controllers, DTOs, Swagger
	 ├── VemProFutApi.Application    → Services, UseCases, Interfaces
	 ├── VemProFutApi.Domain         → Entities, ValueObjects, Regras de negócio
	 ├── VemProFutApi.Infrastructure → Repositories, EF Core, Configuração DB
	 └── VemProFutApi.Tests          → Testes unitários e integração

```
