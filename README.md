# BuberDinner API

## English

### Overview
BuberDinner is a sample REST API built with ASP.NET (now targeting .NET 10). It provides basic authentication endpoints and a health check endpoint. It also exposes Swagger/OpenAPI for quick testing.

### Features
- REST API with `auth/register` and `auth/login`
- Swagger UI at `/swagger`
- Health check at `/health`
- In-memory user repository (data is not persisted)

### Tech Stack
- .NET 10
- ASP.NET Core Web API
- Docker / Docker Compose

### Run with Docker Compose
Prerequisites: Docker and Docker Compose.

```bash
docker compose -f docker-compose.yml up -d --build buberdinner
```

Then open:
- API base URL: `http://localhost:8080`
- Swagger UI: `http://localhost:8080/swagger`
- Health check: `http://localhost:8080/health`

To stop:
```bash
docker compose -f docker-compose.yml down
```

Note: the app currently listens on HTTP only inside Docker. If you keep `UseHttpsRedirection()` enabled, the warning about HTTPS port is expected unless you configure HTTPS.

### Example Requests
Register:
```bash
curl -X POST "http://localhost:8080/auth/register" \
  -H "Content-Type: application/json" \
  -d '{"firstName":"John","lastName":"Doe","email":"john@doe.com","password":"P@ssw0rd"}'
```

Login:
```bash
curl -X POST "http://localhost:8080/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email":"john@doe.com","password":"P@ssw0rd"}'
```

---

## Portugues (PT-BR)

### Visao geral
BuberDinner e uma API REST de exemplo feita com ASP.NET (agora mirando .NET 10). Ela expone endpoints basicos de autenticacao e um endpoint de health check. Tambem disponibiliza Swagger/OpenAPI para testes rapidos.

### Funcionalidades
- API REST com `auth/register` e `auth/login`
- Swagger UI em `/swagger`
- Health check em `/health`
- Repositorio de usuarios em memoria (nao persiste dados)

### Tecnologias
- .NET 10
- ASP.NET Core Web API
- Docker / Docker Compose

### Rodar com Docker Compose
Requisitos: Docker e Docker Compose.

```bash
docker compose -f docker-compose.yml up -d --build buberdinner
```

Depois acesse:
- API base: `http://localhost:8080`
- Swagger UI: `http://localhost:8080/swagger`
- Health check: `http://localhost:8080/health`

Para parar:
```bash
docker compose -f docker-compose.yml down
```

Observacao: no Docker a aplicacao esta em HTTP apenas. Se `UseHttpsRedirection()` estiver ativo, o warning sobre porta HTTPS e esperado ate configurar HTTPS.
