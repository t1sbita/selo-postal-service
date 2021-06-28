# Selo Postal Service

## API para filtragem de dados e criação de QR Code para etiquetas

<br/>

O projeto Recognize está dividido em módulos:

| Módulo         | Descrição                                            |
| -------------- | ---------------------------------------------------- |
| selo-postal-api.API  | Ponto de entrada da aplicação (Controllers)          |
| selo-postal-api.Core | Servicos, Entidades, Regras da API                   |
| selo-postal-api.Data | Camada de acesso a dados, conexão com banco de dados |
| selo-postal-api.Tests| Testes Unitários                                     |


### Fluxo do sistema

1. Usuario deve obter primeiramente o token de autenticação em `/api/usuarios/login`
1. O usuário pode escolher por quais parâmetros quer filtrar os dados (podendo escolher nenhum, ou todos disponíveis) e como pagina-los
1. O sistema retornará uma lista com os itens da pesquisa
1. Para cada dado filtrado, existirá um qrcodeRef, que indicará a URI do QrCode

<br/>
#### Filtros disponíveis

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
