# Selo Postal Service

## Sistema básico para filtragem de dados e criação de QR Code para etiquetas

<br/>

### Fluxo do sistema

1. A partir de uma lista, que serve de base de dados
1. O usuário pode escolher por quais parâmetros quer filtrar os dados (podendo escolher nenhum, ou todos disponíveis) e como pagina-los
1. O sistema retornará um TSV contendo os dados filtrados
1. Para cada dado filtrado, existirá um qrcodeRef, que indicará aonde está armazenado o QR Code equivalente ao dado filtrado

<br/>

#### Filtros disponíveis
* Cidade
* Estado
* Código Postal

#### Paginação
O usuário pode escolher a quantidade por página que será exibida, e a página que quer que seja exibida

*Exemplo:*
Usuário escolhe que quer 10 resultados por página, e quer os dados da terceira página, então serão retornados os itens 21 a 30.

_Obs.: Caso não seja escolhida nenhuma paginação, por padrão, será retornada a página 1 com 10 itens_


### Este README ainda está em construção!
