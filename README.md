# Sistema de Testes para Breecrows

Este projeto implementa uma API para gestão de vendas com ASP.NET Core 8, utilizando práticas de DDD, SOLID e integração com Envio de Eventos.

---

## Pré-requisitos

Antes de rodar o projeto, você precisará ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (já incluído no .NET SDK)
- [PostgreSQL](https://www.postgresql.org/download/)

---

## Configuração do Banco de Dados

1. **Configurar a string de conexão**:
	No arquivo `appsettings.Development.json`, configure sua string de conexão do PostgreSQL:
	```
	{
	  "ConnectionStrings": {
	    "DefaultConnection": "Host=localhost;Port=5432;Database=123vendas;Username=seu_usuario;Password=sua_senha"
	  }
	}
	```


2. **Você poderá subir o banco de dados postgree via docker**:
	Navegue até a pasta raíz do projeto e execute o docker-compose.yml:
	```
		docker-compose up -d

	```# NewRepo