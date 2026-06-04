# 🚀 Projeto GS - Nova Economia Espacial

## 📖 Sobre o Projeto

O Projeto da Global Solution para a disciplina **C# Development** foi desenvolvido com o objetivo de catalogar e analisar tecnologias derivadas da exploração espacial e seus impactos em diferentes setores da sociedade.

A aplicação permite o gerenciamento de tecnologias espaciais, categorização por área de impacto, autenticação de usuários e visualização de indicadores por meio de um dashboard administrativo.

---

# 🛠 Tecnologias Utilizadas

## Backend

* ASP.NET Core 9 Web API
* Entity Framework Core
* Repository Pattern
* BCrypt.Net
* MySQL

## Frontend

* ASP.NET Core MVC
* Bootstrap 5
* Razor Pages

## Arquitetura

* .NET Aspire
* Web API
* MVC
* MySQL

---

# 📂 Estrutura da Solução

```text
ProjetoGS.AppHost
ProjetoGS.ApiService
ProjetoGS.Web
ProjetoGS.ServiceDefaults
scripts.sql
README.md
```

---

# ⚙️ Pré-Requisitos

Antes de executar o projeto, é necessário possuir instalado:

* .NET 9 SDK
* Visual Studio 2022 (ou superior)
* MySQL Server 8+ ou superior
* Git (opcional)

---

# 🗄 Configuração do Banco de Dados

## 1. Criar o banco

Execute o script:

```text
scripts.sql
```

O script irá:

* Criar o banco de dados
* Criar as tabelas
* Inserir categorias iniciais
* Inserir usuários padrão

---

## 2. Configurar a Connection String

No arquivo:

```text
ProjetoGS.ApiService/appsettings.json
```

Configure os dados de acesso ao MySQL:

```json
{
  "ConnectionStrings": {
    "projetogsdb": "Server=localhost;Port=3306;Database=projetogsdb;User=root;Password=SUA_SENHA;"
  }
}
```

Substitua:

```text
SUA_SENHA
```

pela senha configurada no seu MySQL.

---

# ▶️ Como Executar

1. Abrir a solução no Visual Studio
2. Restaurar os pacotes NuGet
3. Executar o script SQL
4. Configurar a Connection String
5. Definir o projeto:

```text
ProjetoGS.AppHost
```

como projeto de inicialização

6. Executar a aplicação

O Aspire iniciará automaticamente:

* API
* Aplicação MVC

---

# 📡 Documentação da API

A API possui documentação interativa através do Swagger.

Após executar o projeto, acesse:

```text
https://localhost:7368/swagger
```

No Swagger é possível:

* Consultar os endpoints disponíveis
* Visualizar os modelos de dados
* Realizar testes das operações da API
* Validar as respostas retornadas pelo sistema

Principais endpoints:

```text
GET    /api/Tecnologias
GET    /api/Tecnologias/{id}
GET    /api/Tecnologias/stats
POST   /api/Tecnologias
PUT    /api/Tecnologias/{id}
DELETE /api/Tecnologias/{id}
```

---

# 🏗 Arquitetura da Solução

A aplicação foi desenvolvida utilizando arquitetura em camadas:

```text
MVC (Frontend)
↓
Web API
↓
Repository Pattern
↓
Entity Framework Core
↓
MySQL
```

O .NET Aspire é utilizado para orquestrar a execução dos projetos da solução, permitindo a inicialização integrada da API e da aplicação MVC.


---

# 🔐 Usuários Disponíveis

## Administrador

Permissões:

* Visualizar tecnologias
* Cadastrar tecnologias
* Editar tecnologias
* Excluir tecnologias
* Visualizar dashboard

Login:

```text
admin@fiap.com
```

Senha:

```text
admin123
```

---

## Pesquisador

Permissões:

* Visualizar tecnologias
* Visualizar dashboard

Login:

```text
pesquisador@fiap.com
```

Senha:

```text
pesquisa123
```

---

# 📊 Funcionalidades

* Login e Logout
* Controle de acesso por perfil
* Dashboard com indicadores
* Cadastro de Tecnologias
* Edição de Tecnologias
* Exclusão de Tecnologias
* Consulta de Tecnologias
* Estatísticas por categoria
* Integração MVC + API
* Persistência em MySQL

---

# 👥 Integrantes

| Nome         | RM       |
| ------------ | -------- |
| Enzo Rodrigues | RM553377 |
| Gabriel Mediotti | RM552632 |
| Hugo Santos | RM553266 |
| Maria Júlia | RM553384 |
| Rafael Cristofali | RM553521 |

---

# 🎓 Projeto Acadêmico

Projeto desenvolvido para a Global Solution da FIAP utilizando .NET Aspire, ASP.NET Core MVC, ASP.NET Core Web API e MySQL.
