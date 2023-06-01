## Instalar o SDK
https://dotnet.microsoft.com/pt-br/download/dotnet/7.0


## Estrutura da solução

- FastFoodFIAP                                  ->  sln
    - src: 
        - FastFoodFIAP.Application              ->  classlib
        - FastFoodFIAP.Domain.Core             ->  classlib
        - FastFoodFIAP.Domain                  ->  classlib
        - FastFoodFIAP.Infra.CrossCutting.IoC  ->  classlib
        - FastFoodFIAP.Infra.Data              ->  classlib
        - FastFoodFIAP.Services.Api            ->  webapi
    - tests:
        - FastFoodFIAP.[Camada].test           ->  xunit
    - .gitignore                                ->  gitignore  

Exemplo: `dotnet new classlib -lang "C#" -o NomeProjeto`

### Vincular à solução

Para criar o arquivo da solução, execute:

    `dotnet new sln --name NomeSolução`

Para vincular os projetos à solucução, execute:

    `dotnet sln add src/projeto`


### Referenciar os projetos

No diretório do projeto, execute:
    `dotnet add reference ../[Diretório]/[NomeProjeto].csproj`

Exemplo: `dotnet add reference ../MeuProjeto.Domain/MeuProjeto.Domain.csproj`

- FastFoodFIAP                        
    - src: 
        - FastFoodFIAP.Application
                -> FastFoodFIAP.Domain
                -> FastFoodFIAP.Infra.Data

        - FastFoodFIAP.Domain.Core

        - FastFoodFIAP.Domain                
                -> FastFoodFIAP.Domain.Core

        - FastFoodFIAP.Infra.CrossCutting.IoC

        - FastFoodFIAP.Infra.Data
                -> FastFoodFIAP.Domain

        - FastFoodFIAP.Services.Api
                -> FastFoodFIAP.Application
                -> FastFoodFIAP.Infra.CrossCutting.IoC
    - tests:
        - FastFoodFIAP.Domain.test          

### GitHub


Para criar o arquivo .gitignore para o .NET, execute no local do arquivo da solução:

    `dotnet new gitignore`