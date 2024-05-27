# Crud-WindowsForms-WebAPI

## Descrição

O projeto **Crud-WindowsForms-WebAPI** é uma aplicação que consiste em duas partes principais:

1. **Windows Forms Application**: Uma interface gráfica que interage com o usuário final, permitindo operações CRUD (Create, Read, Update, Delete).
2. **Web API**: Uma API RESTful que serve como intermediária entre a aplicação Windows Forms e o banco de dados MySQL, realizando as operações necessárias e retornando os dados requisitados.

## Estrutura do Projeto

O projeto é dividido em três componentes principais:

1. **Windows Forms Application**:
    - Interface gráfica amigável para interação do usuário.
    - Consome os endpoints da Web API para realizar operações CRUD.
  
2. **Web API**:
    - API desenvolvida em ASP.NET Core.
    - Contém endpoints para operações CRUD.
    - Realiza a comunicação com o banco de dados MySQL.

3. **Banco de Dados MySQL**:
    - Armazena os dados manipulados pela aplicação.
    - Estrutura de tabelas adequada para suportar operações CRUD.

## Funcionalidades

### Windows Forms Application

- **Create**: Adicionar novos registros.
- **Read**: Listar registros existentes.
- **Update**: Atualizar informações de registros existentes.
- **Delete**: Remover registros existentes.

### Web API

- **GET**: Recuperar dados do banco de dados.
- **POST**: Adicionar novos dados ao banco de dados.
- **PUT**: Atualizar dados existentes no banco de dados.
- **DELETE**: Remover dados do banco de dados.

## Requisitos

- **.NET Framework** para a aplicação Windows Forms.
- **ASP.NET Core** para a Web API.
- **MySQL** para o banco de dados.

## Configuração e Execução

### Banco de Dados MySQL

1. Instale o MySQL Server.
2. Crie um banco de dados e configure as tabelas necessárias.
3. Atualize a string de conexão no arquivo de configuração da Web API para se conectar ao banco de dados MySQL.

### Web API

1. Clone o repositório do projeto.
2. Navegue até o diretório da Web API.
3. Configure a string de conexão para o banco de dados MySQL no arquivo `appsettings.json`.
4. Execute o comando `dotnet run` para iniciar a API.

### Windows Forms Application

1. Clone o repositório do projeto.
2. Navegue até o diretório da aplicação Windows Forms.
3. Abra o projeto no Visual Studio.
4. Atualize o endpoint da API no código da aplicação para apontar para o endereço correto da Web API.
5. Compile e execute a aplicação.

## Como Contribuir

1. Faça um fork do projeto.
2. Crie uma nova branch
3. Faça as modificações necessárias.
4. Commit suas mudanças
5. Push para a branch 
6. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
