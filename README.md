# Arquitetura Hexagonal com .NET 7

FIAP Pos Tech - SOFTWARE ARCHITECTURE
SOAP2 - Grupo 7

## O projeto

![Projeto](https://github.com/belloniz/group-7/blob/main/docs/DDD.png)

Miro: https://miro.com/app/board/uXjVMI-wOLc=/?share_link_id=8789531868

## Requisitos

- SDK do .NET 7.0: Baixe em https://dotnet.microsoft.com/pt-br/download/dotnet/7.0.
- Docker: https://docs.docker.com/engine/install/

- IDE de sua preferência: pode ser executado com o Visual Studio Code (Windows, Linux or MacOS).


## Subindo todo sistema

1. Crie a imagem da aplicação Fastfood:

   `docker build -t fastfoodapi:latest -f Dockerfile .`

2. Suba os containers (aplicação e banco de dados) utilizando o docker compose

   `docker-compose up -d`

3. Teste o sistema através do swagger:

   `http://localhost:8000/swagger/index.html`


## Tecnologias

- Runtime do .NET 7.0.5
    - Suporte para o Visual Studio
        - Visual Studio 2022 (v17.6)
        - Visual Studio 2022 for Mac (v17.6)
    - C# 11.0
    - ASP.NET WebApi
    - Entity Framework
    - AutoMapper
    - Swagger UI
- PostgreSQL 
- Docker

## Arquitetura e Padrões

![Arquitetura](https://github.com/belloniz/group-7/blob/main/docs/ArquiteturaHexagonal.png)

- Arquitetura Hexagonal
- Domain Driven Design
- Unit of Work
- Repository

## Estrutura da solução

![Projeto](https://github.com/belloniz/group-7/blob/main/docs/Projeto.png)
