# Plusoft4Sprint - Challenge


## Integrantes
- Raphael Pabst rm98525
- Silvio Junior rm550821
- Pedro Braga rm551061
- Eduardo Reis Braga rm551987
- Vinícius Martins Torres Abdala rm99455


# Tecnologias Utilizadas:

## Implementação da API
- ASP.NET Core Web API: Framework de desenvolvimento.
- Banco de dados Oracle: Para operações CRUD (Create, Read, Update, Delete).
- Swagger/OpenAPI: Documentação interativa dos endpoints.
- Padrão de Criação: Usaremos o JSON para o gerenciador de configurações.
- Autenticação JWT: Token.

## Arquitetura da API


Este repositório contém uma API RESTful construída em ASP.NET Core, que gerencia dados de produtos e oferece uma funcionalidade de previsão baseada em Machine Learning para recomendar o nome de um produto, com base em suas características. A aplicação utiliza o Entity Framework Core para persistência de dados e uma camada de segurança baseada em JWT para autenticação de usuários.

- Models/: Define as classes de modelo do domínio, como Produto e Cliente.
- Controllers/: Contém os controladores responsáveis por gerenciar as requisições HTTP.
- Data/: Contém o contexto do banco de dados (AppDbContext).
- Data/dados_treinamento.csv: Contém os dados para treinar o modelo de previsão.
- Services/: Inclui serviços auxiliares, como TokenService para geração de tokens JWT.
- wwwroot/MLModels/: Armazena o modelo treinado de Machine Learning.


---

## Padrão de Criação

Optamos pelo uso do padrão JSON (JavaScript Object Notation) no desenvolvimento de APIs devido aos inúmeros benefícios que ele proporciona, tanto em termos técnicos quanto de usabilidade. Um dos principais motivos é sua ampla compatibilidade. JSON é suportado por praticamente todas as linguagens de programação modernas, o que facilita a integração das APIs com diferentes sistemas e plataformas. Isso significa que independentemente do ambiente em que estejam trabalhando, podemos consumir e produzir dados de forma consistente em outras APIs.

## Funcionalidades

 1. CRUDs de Produtos,Clientes, Endereço e Email: Permite criar, ler, atualizar e deletar.
 2. Autenticação JWT: Protege a API com autenticação JWT, garantindo acesso apenas a usuários autorizados.
 3. Previsão de Produto com IA Generativa: Implementa uma API para prever o nome de um produto com base nas características inseridas, utilizando Machine Learning.
 4. Treinamento de Modelo ML: Treina um modelo de IA para prever o nome do produto com base em dados históricos.
 5. Dados: Csv de treinamento contendo + de 7 mil linhas de dados (80%) e csv de Testes (20%) para melhor adequação de aprendizagem de máquina.

---

## Funcionalidade de IA Generativa

#Detalhes do Modelo de IA

O projeto utiliza o Microsoft ML.NET para treinar um modelo de classificação multi-classe, que prevê o nome do produto para recomendação de uso com base em características, como categoria, preço, sexo do cliente, tamanho, estação do ano e cor do produto.

JSON para Testes em PrevisaoProdutoController

{
  "nomeProduto": "string",
  "categoria": "Jaquetas",
  "preco": 292,
  "sexoCliente": "F",
  "tamanho": "42",
  "estacaoAno": "Inverno",
  "corProduto": "Marrom"
}

---

## Práticas de Clean Code

O projeto segue princípios de Clean Code para garantir legibilidade, manutenção e qualidade de código. Algumas práticas adotadas incluem:

- Naming Conventions: Todos os métodos, variáveis e classes seguem convenções de nomenclatura claras, que indicam sua funcionalidade.
- Tratamento de Erros: O código captura exceções específicas e retorna respostas apropriadas ao cliente, como NotFound e BadRequest.
- Separação de Preocupações: A funcionalidade de geração de token JWT é isolada em TokenService, respeitando o princípio de separação de responsabilidades.
- Injeção de Dependência: A API utiliza injeção de dependência para o contexto do banco de dados (AppDbContext) e para o serviço de geração de tokens (TokenService), facilitando o teste e a manutenção do código.
- Responsabilidade Única: Cada classe e método possui uma única responsabilidade. Por exemplo, o ProdutosController gerencia operações CRUD e PrevisaoProdutoController cuida das previsões de produtos.
- Os endpoints responsáveis pelas operações CRUD (Create, Read, Update e Delete) serão implementados seguindo essa arquitetura monolítica. Isso implica que todas as operações relativas aos recursos da API, como a criação de novos registros, leitura, atualização e remoção de dados, estarão centralizadas no mesmo núcleo da aplicação, permitindo uma gestão unificada e simplificada dos dados e funcionalidades.


---
## Como executar a API

**Pré-requisitos**
- .NET 6.0 ou superior
- Banco de Dados Oracle
  
**Passos para Execução**
  1. Clone o repositório:

    git clone https://github.com/RaphaPab/Plusoft3Sprint
     
  3. Configure as variáveis de ambiente com as credenciais de acesso ao banco Oracle.

  4. Execute as migrações do banco de dados:

    dotnet ef database update

  4.Inicie a aplicação:
  
      Clique em https.
      
  ![image](https://github.com/user-attachments/assets/266cf312-9dbc-41ac-9c08-203886ca308b)



---

## Endpoints CRUD

- **PrevisaoProdutoController**
  Controller responsável por prever o nome de um produto com base nas características informadas.

  - **POST**
 
    ![image](https://github.com/user-attachments/assets/d8334c81-6794-4efd-8569-1b92e5663c2a)




- **TokenService**
  AuthController e AuthService para implementação de serviço de autenticação.

    Acesso: Username == "usuario".
    Login.Password == "senha123".


    ![image](https://github.com/user-attachments/assets/872eede0-6860-44ce-ba16-935a03e1728f)

    ![image](https://github.com/user-attachments/assets/d563b39b-c06d-44f0-8c21-7bf5d0dd1ae9)

    ![image](https://github.com/user-attachments/assets/58d0e0dd-fc97-4841-91c5-d6b1080e1f2f)



    

  
Os endpoints da API seguem o padrão **CRUD** (Create, Read, Update, Delete) para os recursos:

- **Clientes**
- **Emails**
- **Endereços**
- **Produtos**

Cada recurso interage com o banco de dados **Oracle** utilizando o **Entity Framework Core**, garantindo a integração e manipulação de dados de forma eficiente. Os seguintes métodos RESTful são implementados:

- **GET**: Recupera recursos.
- **POST**: Cria novos recursos.
- **PUT**: Atualiza recursos existentes.
- **DELETE**: Exclui recursos.

Esses métodos estão disponíveis para todos os recursos mencionados, garantindo conformidade com as práticas recomendadas de APIs RESTful.

- **GET**


- endpoint
- exemplo corpo de resposta


- **POST**

- endpoint
- exemplo corpo de request
- exemplo corpo


- **PUT**
- endpoint
- exemplo corpo de request
- exemplo corpo de resposta


DELETE

- endpoint
- exemplo de request
- não há corpo de resposta


**HTTP responses**
| Código | Descrição |
|---|---|
| 200 | Requisição executada com sucesso (success)|
| 400 | Bad request|
| 404 | Registro pesquisado não encontrado (Not found)|
| 500 | Internal server error|

---

- [Listagem de Clientes](#Buscar_Lista_de_Clientes)
- [Enviar dados](#Enviar_dados)
- [Listar Cliente por ID](#Listar_Cliente_por_ID)
- [Alterar dados no sistema](#Alterar_dados_no_sistema)
- [Deletar dados no sistema](#Deletar_dados_no_sistema)

Alterar dados no sistema
---

### Buscar_Lista_de_Clientes

#### Endpoint

- **Método**: GET  
- **URL**: 'localhost:7146/api/Clientes'

- #### Descrição
Este endpoint retorna uma Lista de clientes cadastrados no sistema.

Exemplo Corpo de resposta

![image](https://github.com/user-attachments/assets/bbc1234a-6ce5-40dd-882b-1006424f0e71)


Exemplo Corpo do request

![image](https://github.com/user-attachments/assets/1a6d7c4c-7a7b-4db6-87b0-e85c43fa4ab1)



### Enviar_dados

#### Endpoint

- **Método**: POST  
- **URL**: 'localhost:7146/api/Clientes'

#### Descrição
Este endpoint envia dados do cliente para o banco de dados.

Exemplo Corpo de resposta
![image](https://github.com/user-attachments/assets/38a054da-2e4d-4f56-bf8c-585bb164083a)


Exemplo Corpo do request
{
  "id": 6,
  "nome": "Carlos",
  "dataNascimento": "2000-09-15T22:38:24.922Z",
  "cpf": 654651651,
  "telefone": "6579545"
}



### Listar_Cliente_por_ID



#### Endpoint

- **Método**: GET  
- **URL**: 'localhost:7146/api/Clientes/4'

- #### Descrição
Este endpoint retorna o ID do cliente cadastrado no sistema.

Exemplo Corpo de resposta
![image](https://github.com/user-attachments/assets/e141ccf3-a6a7-46ae-bec2-806384c60b7b)

Exemplo Corpo do request
![image](https://github.com/user-attachments/assets/dfdc39f2-73f8-4d5b-8b25-9b20a43af03a)


### Alterar_dados_no_sistema



#### Endpoint

- **Método**: PUT  
- **URL**: 'localhost:7146/api/Clientes/4'

- #### Descrição
Este endpoint altera os dados do cliente cadastrado no sistema.

Exemplo Corpo de resposta
![image](https://github.com/user-attachments/assets/b4d629c1-10fb-4c4a-9841-14b4841837de)

Exemplo Corpo do request
![image](https://github.com/user-attachments/assets/c2dd6759-e8eb-4ae4-9a9e-a4bc28c789ae)



### Deletar_dados_no_sistema



#### Endpoint

- **Método**: DELETE  
- **URL**: 'localhost:7146/api/Clientes/4'

- #### Descrição
Este endpoint deleta os dados do cliente cadastrado no sistema de acordo com o ID.

Exemplo Corpo de resposta
![image](https://github.com/user-attachments/assets/b15a28cc-f81c-41b6-bb12-ffbb6b962ff4)


















