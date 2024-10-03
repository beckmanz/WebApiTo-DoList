# To-Do List API

## Descrição do Projeto

Este projeto é uma API para gerenciar usuários e tarefas em uma to-do list. Ele permite criar, ler, atualizar e excluir usuários e tarefas, além de oferecer funcionalidades adicionais como a marcação de status.

## Funcionalidades

- Criação de novos usuários e tarefas
- Leitura de usuários e tarefas existentes
- Atualização de informações de um usuários e uma tarefa
- Exclusão de usuários e tarefas
- Marcação de tarefas como concluídas

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server** (ou SQLite, dependendo da configuração)
- **BCrypt.Net-Next**
- **Swagger** (para teste da API)

## Configuração do Ambiente

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) ou [SQLite](https://www.sqlite.org/download.html)

### Passo a Passo

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/todolist-api.git

2. Entre no diretório do projeto:

```bash
cd todolist-api
```
3. Restaure as dependências
```bash
dotnet restore
```
4. Configure o banco de dados no arquivo appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaConnectionString"
  }
}
```
5. Execute as migrações e update do Entity Framework:

```bash
dotnet ef migrations add
dotnet ef database update
```
6. Inicie o projeto:

```bash
dotnet run
```

## Rotas
**Usuário**

| Método | URL             |  Descrição                        | 
| -------| ----------------|-----------------------------------|
| POST   | /Usuario/Criar  | Criar um novo Usuário             |
| PUT    | /Usuario/Editar | Editar um usuário existente       |
| GET    | /Usuario/Buscar | Buscar usuario                    |
| GET    | /Usuario/Login  | Fazer login na conta de um usuário|
| DELETE | /Usuario/Excluir| Excluir a conta de um usuário     |

**Tarefas**
| Método | URL             |  Descrição                        | 
| -------| ----------------|-----------------------------------|
| POST   | /Tarefa/Criar  | Criar uma nova tarefa              |
| PUT    | /Tarefa/Editar | Editar uma tarefa existente        |
| GET    | /Tarefa/Buscar | Buscar tarefa                      |
| DELETE | /Tarefa/Excluir| Excluir a tarefa de um usuário     |

## Estrutura das entidades

**Usuário**
- Id
- Name
- Email
- Password
- Tarefas

**Tarefas**
- Id
- Name
- Description
- Status
- Usuario
##
