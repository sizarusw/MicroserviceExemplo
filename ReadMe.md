# Exemplo de Microservices

Exemplo simples de microservice com CRUD utilizando ORM NHibernate com .NetCore.

## Utilizamos

* .NetCore
* NHibernate
* SQLite
* API Gateway Ocelot

## Nuget Packages

* NHibernate
* FluentNhibernate
* Ocelot
* System.Data.SQLite
* Newtonsoft.Json

## Microservices

### Produto

**Porta:** 9030
**Rota:** [api/produto]

**Exemplo da URL:** https://localhost:9030/api/produto

### Cliente

**Porta:** 9050
**Rota:** [api/cliente]

**Exemplo da URL:** https://localhost:9050/api/cliente

### API Gateway - Ocelot

**Porta:** 9010

**Exemplo de URL de acesso através do Gateway:**
https://localhost:9010/produto

**Exemplos de URL de acesso através do Gateway:**
https://localhost:9010/cliente

## Banco de dados do exemplo

Utilizamos o banco **SQLite** por ser leve e ser de simples demonstração.

### Local do banco

O exemplo do banco está localizado na pasta raiz.

**Arquivo:** principal.db

O caminho do banco no projeto está localizado na variável *connectionString* do *NHibernateExtensions.cs* (Função AddNHibernate)

**Default:** C:\sqlite\principal.db;
