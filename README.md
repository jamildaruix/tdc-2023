# **TDC 2023**

Construção de uma aplicação Back-End para revisão do módulo de .Net

# **Objetivo**

Efetuar o passo a passo para construção de um projeto que vai receber POST, PUT, DELETE e GET.
O projeto vai conter uma comunicação com o banco de dados utilizando o SQL Server utilizando o Entity Framework Core.
Vamos utilizar o AutoMapper para efetuar o mapeamento do DTO para MODEL e vice versa.
Vamos utilizar o System.Linq e Lambda.

# **Visual Studio**

Abra o visual studio e selecione a opção Criar um novo Projeto

![Alt text](/images/image3.png)

selecione o template API chamada ASP.NET CORE WEB API

![Alt text](/images/image4.png)

Seleciona o diretório, mude o nome da solucão e mude o nome do projeto

Ex.
1. Diretório  `C:\<SeuRepo>`
2. Nome da solução `FichaCadastroSln` 
3. Nome do projeto `FichaCadastroAPI` 

![Alt text](/images/image5.png)

Configuração do projeto

![Alt text](/images/image6.png)

Criar o projeto

![Alt text](/images/image7.png)

# **VS Code**

Criar uma `solução` e um `projeto` tipo api pelo VS CODE

## Passo 1: Criando uma pasta chamada `FichaCadastroSln` e acessar o diretório

Abra o terminal (ou prompt de comando) no local que fica seus repositórios e execute os comandos.

```bash
mkdir FichaCadastroSln
cd FichaCadastroSln
```

## Passo 2: Criando a `Solução` e o `Projeto`

Dentro do terminal aberto execute os comandos

Comando                                             | Detalhe
| :---                                              | :---
dotnet new sln -n [NomeSln]                         | Cria um arquivo .sln para referenciar os projetos 
dotnet new webapi -n [NomeApi]                      | Cria uma pasta (folder) e adiciona os arquivos do projeto web api
dotnet sln [NomeSln] add [FolderNomeApi]/[NomeApi]  | Referencia (coloca o caminho da pasta do projeto) o projeto (.csproj) dentro da solução (.sln)

```bash
dotnet new sln -n FichaCadastroSln
dotnet new webapi -n FichaCadastroAPI
dotnet sln FichaCadastroSln.sln add FichaCadastroAPI/FichaCadastroAPI.csproj
```

# **Pacote nugets usados no projeto**

<details>
    <summary>AutoMapper</summary>
    <p>Link <a href="https://www.nuget.org/packages/automapper/">Link</a></p>
    <p>dotnet add package AutoMapper --version 12.0.1</p>
</details>

<details>
    <summary>AutoMapper.Extensions.Microsoft.DependencyInjection</summary>
    <p><a href="https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/12.0.1">Link</a></p>
    <p>dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1</p>
</details>

<details>
    <summary>Microsoft.EntityFrameworkCore</summary>
    <p><a href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.9">Link</a></p>
    <p>dotnet add package Microsoft.EntityFrameworkCore --version 7.0.9</p>
</details>

<details>
    <summary>Microsoft.EntityFrameworkCore.Design</summary>
    <p><a href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.9">Link</a></p>
    <p>dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.9</p>
</details>

<details>
    <summary>Microsoft.EntityFrameworkCore.SqlServer</summary>
    <p><a href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.9">Link</a></p>
    <p>dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.9</p>
</details>

<details>
    <summary>Microsoft.EntityFrameworkCore.Tools</summary>
    <p><a href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.9">Link</a></p>
    <p>dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.9</p>
</details>


<br/>


# **Comandos git** 

## Branches

Comando                                     | Detalhe
| :---                                      | :---
git branch                                  | Lista as branches locais
git branch `feature\nome-da-branch`         | Cria uma nova branch
git checkout `feature\nome-da-branch`       | Muda para a branch especificada
git checkout -b `feature\nome-da-branch`    | Cria e muda para uma nova branch

## Commits

Comando                               | Detalhe
| :---                                | :---
git status                            | Mostra o estado atual das mudanças no diretório de trabalho
git add `exemplo.pdf`                 | Adiciona um arquivo específico para a área
git add . ou git add -A               | Adiciona todos os arquivos modificados para a área 
git commit -m "Mensagem do commit"    | Cria um novo commit com as mudanças na área
git commit -a -m "Mensagem do commit" | Adiciona automaticamente todas as alterações conhecidas ao índice e cria um commit

## Atualização e Sincronização

Comando     | Detalhe
| :---      | :---
git fetch   | Obtém informações atualizadas do repositório remoto sem incorporar as alterações no diretório de trabalho local
git pull    | Atualiza o repositório local com as alterações do repositório remoto
git push    | Envie os commits locais para o repositório remoto

## Merge e Rebase

Comando                                 | Detalhe
| :---                                  | :---
git merge  `origin/branch` ou `branch`  | Faz a fusão de uma branch na branch atual
git rebase `origin/branch` ou `branch`  | Reaplica commits em cima de outra branch

# **O projeto**

Após baixar o projeto, você pode abrir com o `Visual Studio` ou `VS Code`.

As tecnologias utilizadas:

* .Net com C#
* SQL Server

# **Comandos utilizados**

## Visual Studio

* Selecion o Tools (Ferramenta) 

![Alt text](/images/image8.png)

* Depois entre na opção Package Manager Console

![Alt text](/images/image1.png)

* Será aberto um terminal para executar os comandos

![Alt text](/images/image2.png)

```
Add-Migration InitialCreate
Update-Database
```

## VS Code

### No `VS Code` pode ser necessário instalar o EF 

Comando caso precisei instalar `dotnet tool install --global dotnet-ef`

```
dotnet ef migrations add InitialCreate 
dotnet ef database update
```

## Imagem SQL Server

Imagem criada no docker-compose.yaml do SQL Server


## Instruções para configurar o SQL Server usando Docker Compose

1. Certifique-se de ter o Docker instalado no seu sistema.

2. Navegue até o diretório onde o arquivo `docker-compose.yml` está localizado.

3. Abra o terminal na pasta e execute o seguinte comando para iniciar o SQL Server:

Comando                 | Detalhe
| :---                  | :---
docker-compose up       | Inicia o contanier e os serviços ficaram em execução no terminal
docker-compose up -d    | Inicia o contanier e os serviços ficaram em backgraoud (segundo plano) em execução
ocker-compose stop      | Para a execução do container do docker
docker-compose down     | Para e remove o container do docker
docker-compose ps       | Lista todos container's em execução
docker-compose ps -a    | Lista todos container's parados ou em execução


## Acessando

Abrir o SQL Manager para acessar o SQL Server configurado da imagem

![Alt text](/images/image9.png)


- Server name: `localhost,1433`
    - Válido se você estiver executando o Docker Desktop diretamente no macOS, onde o contêiner é acessível como localhost.
- Server name: `host.docker.internal,1433`
    - Quando estiver usando um ambiente de máquina virtual ou WSL (Windows Subsystem for Linux) para executar o Docker no macOS.
 

## Comandos para executar os teste com cobertura e gerar o relatórios em html

1. Acess o projeto de test chamado FichaCadastroTest, dentro vai existir duas pastas lcov e coverange-report

2. Abra o terminal na pasta e execute os comandos:

``` CSharp
dotnet test -v q
reportgenerator -reports:.\lcov\coverage.opencover.xml -targetdir:..\..\coverage-report\ -reporttypes:Html
```
