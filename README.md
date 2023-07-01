# [FIAP - Pos Tech] Fast Food

FIAP Pos Tech - SOFTWARE ARCHITECTURE

SOAP2 - Grupo 7

#### Sumário
   * [O projeto](#o-projeto)
   * [Documentações](#documentações)
   * [Pré-requisitos](#pré-requisitos)
   * [Como rodar a aplicação <g-emoji class="g-emoji" alias="arrow_forward" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/25b6.png">▶️</g-emoji>](#como-rodar-a-aplicação-️)
   * [Tecnologias](#tecnologias)
   * [Arquitetura e Padrões](#arquitetura-e-padrões)
   * [Estrutura da solução](#estrutura-da-solução)
   * [Desenvolvedores <img class="emoji" title=":octocat:" alt=":octocat:" src="https://github.githubassets.com/images/icons/emoji/octocat.png" height="20" width="20" align="absmiddle">](#desenvolvedores-octocat)

## O projeto

O projeto consiste em um sistema de autoatendimento de fast food, que é composto por uma série de dispositivos e interfaces que permitem aos clientes selecionar e fazer pedidos sem precisar interagir com um atendente. 

No projeto atual temos as seguintes funcionalidades:
- Cadastro do Cliente
- Identificação do Cliente via CPF
- Criar, editar e remover de produto
- Buscar produtos por categoria
- Fake checkout, apenas enviar os produtos escolhidos para a fila
- Listar os pedidos

## Documentações

A imagem a seguir documenta o sistema utilizando a linguagem ubíqua, dos seguintes fluxos:
- Realização do pedido e pagamento
- Preparação e entrega do pedido

![Projeto](https://github.com/belloniz/group-7/blob/main/docs/DDD.png)


- Miro do DDD: https://miro.com/app/board/uXjVMI-wOLc=/?share_link_id=8789531868
- Diagrama de Classes (necessita ser aberto no [Draw.io](https://www.drawio.com/)): https://github.com/belloniz/group-7/blob/main/docs/ProjetoGrupo7_v2.drawio

## Pré-requisitos

- SDK do .NET 7.0: Baixe em https://dotnet.microsoft.com/pt-br/download/dotnet/7.0.
- Docker: https://docs.docker.com/engine/install/

- IDE de sua preferência: pode ser executado com o Visual Studio Code (Windows, Linux or MacOS).


## Como rodar a aplicação ▶️

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

## Desenvolvedores :octocat:

| [<img src="https://avatars.githubusercontent.com/u/62022498?v=4" width=115><br><sub>Wellerson Willon Reis</sub>](https://github.com/brwillon) | [<img src="https://avatars.githubusercontent.com/u/15663232?v=4" width=115><br><sub>Ana Luisa Bavati</sub>](https://github.com/analuisabavati) |  [<img src="https://avatars.githubusercontent.com/u/67171626?v=4" width=115><br><sub>Luis Fernando</sub>](https://github.com/luisfernandodass) | [<img src="https://avatars.githubusercontent.com/u/26546830?v=4" width=115><br><sub>Gabriel Belloni</sub>](https://github.com/belloniz) |
| :---: | :---: | :---: | :---:
