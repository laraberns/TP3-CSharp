# CityBreaks.Web 🌍

Sistema de cadastro e consulta de propriedades turísticas baseado em ASP.NET Core Razor Pages, com persistência de dados usando Entity Framework Core e banco de dados SQLite.

## 📚 Objetivo

Simular a construção de um sistema para o portal **CityBreaks**, aplicando conceitos como:
- Mapeamento relacional com EF Core
- Relacionamento entre entidades
- Seed de dados
- Soft delete
- Filtros dinâmicos usando LINQ

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core Razor Pages
- Entity Framework Core
- SQLite

---

## 📋 Funcionalidades

### ✅ Exercício 1: Estrutura Inicial
- Criação do projeto Razor Pages
- Configuração do `DbContext` com SQLite

### ✅ Exercício 2: Entidade Country
- `Country` com `Id`, `CountryCode`, `CountryName`
- Primeira migration `InitialCreate`

### ✅ Exercício 3: Relacionamento 1:N
- `City` associada a `Country`
- Migration `AddCityEntity`

### ✅ Exercício 4: Cadastro de Propriedades
- Entidade `Property` com associação a `City`
- Migration `AddPropertyEntity`

### ✅ Exercício 5: Fluent API
- Configurações de colunas e restrições via Fluent API
- Criação das classes de configuração

### ✅ Exercício 6: Seed Data
- População inicial de países, cidades e propriedades
- Migration `SeedInitialData`

### ✅ Exercício 7: Serviço de Cidades
- Interface `ICityService` e implementação
- Consulta com `Include()`

### ✅ Exercício 8: Página de Detalhes
- Página `CityDetails.cshtml` com busca por nome da cidade
- Uso de `EF.Functions.Collate(..., "NOCASE")`

### ✅ Exercício 9: Criação de Propriedade
- Página `CreateProperty.cshtml` com formulário
- Cadastro vinculado à cidade

### ✅ Exercício 10: Edição Segura
- Página `EditProperty.cshtml`
- Atualização controlada com `TryUpdateModelAsync`

### ✅ Exercício 11: Soft Delete
- Campo `DeletedAt` em `Property`
- Exclusão lógica via `DeleteAsync`

### ✅ Exercício 12: Filtros Dinâmicos
- Página `FilterProperties.cshtml`
- Filtros por preço, cidade e nome da propriedade
