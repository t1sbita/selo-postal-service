# Selo Postal Service

## API para filtragem de dados e criação de QR Code para etiquetas

<br/>

O projeto está dividido em módulos:

| Módulo         | Descrição                                            |
| -------------- | ---------------------------------------------------- |
| selo-postal-api.API  | Ponto de entrada da aplicação (Controllers)          |
| selo-postal-api.Core | Servicos, Entidades, Regras da API                   |
| selo-postal-api.Data | Camada de acesso a dados, conexão com banco de dados |
| selo-postal-api.Tests| Testes Unitários                                     |


**Atenção**

- **Caso esteja utilizando o Visual Studio**

> Neste momento o seu Visual Studio já deve estar configurado com o .NET Core.

1. Clone o projeto para sua máquina local.

2. Abra o arquivo selo-postal-api.sln com o Visual Studio.

3. Execute a aplicação a partir do projeto selo-postal-api.Api.

> No navegador padrão da máquina será aberto uma página com o sistema, Utilize a url `<base_url:port>/swagger` e verifique se o projeto está iniciando normalmente.

- **Caso esteja utilizando o Visual Studio Code**

> Neste momento o seu Visual Studio Code e o .NET Core devem estar devidamente instalados na máquina.

1. Clone o projeto para sua máquina local.

2. Abra a pasta do projeto no editor de código.

3. Aceite todas as sugestões de instalação de extensões que aparecerem assim que a pasta do projeto for aberta.

4. No menu Debug, inicie o debug do projeto

> No navegador padrão da máquina será aberto uma página com o sistema, Utilize a url `<base_url:port>/swagger` e verifique se o projeto está iniciando normalmente.

### Gerar token JWT

* Usuario deve obter o token de autenticação em `/api/usuarios/login`
<br/>
## Construindo e rodando o projeto sem ide.

```shell
$ dotnet restore
$ dotnet build
$ dotnet run --project=.\selo-postal-api.Api\selo-postal-api.Api.csproj
```


#### Filtros disponíveis
* Cidade
* Estado
* Código Postal

#### Paginação
O usuário pode escolher a quantidade por página que será exibida, e a página que quer que seja exibida
_Obs.: A quantidade por página será aproximada para o mais próximo entre 10, 20, 30, 50 ou 100_

*Exemplo:*
Usuário escolhe que quer 10 resultados por página, e quer os dados da terceira página, então serão retornados os itens 21 a 30.

_Obs.: Caso não seja escolhida nenhuma paginação, por padrão, será retornada a página 1 com 10 itens_


### Este README ainda está em construção!
