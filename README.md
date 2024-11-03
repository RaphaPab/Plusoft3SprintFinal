# Plusoft3Sprint - Challenge


## Integrantes
- Raphael Pabst rm98525
- Silvio Junior rm550821
- Pedro Braga rm551061
- Eduardo Reis Braga rm551987
- Vinícius Martins Torres Abdala rm99455

## Implementação da API
# Tecnologias Utilizadas:
- ASP.NET Core Web API: Framework de desenvolvimento.
- Banco de dados Oracle: Para operações CRUD (Create, Read, Update, Delete).
- Swagger/OpenAPI: Documentação interativa dos endpoints.
- Padrão de Criação: Usaremos o JSON para o gerenciador de configurações.

# Arquitetura da API

## Abordagem Monolítica

A arquitetura adotada para esta API é **monolítica**, onde toda a aplicação é estruturada em um único projeto e executada como uma única unidade. Essa escolha é justificada pela simplicidade do sistema, o que facilita o desenvolvimento e a manutenção, especialmente dado o tamanho atual da aplicação.

Optou-se por essa abordagem devido a fatores como:

- **Simplicidade**: A estrutura monolítica permite que toda a aplicação seja desenvolvida e gerenciada de forma mais simples.
- **Facilidade de manutenção**: Ideal para projetos menores, onde é mais fácil gerenciar dependências e controlar a evolução do código.
- **Desempenho interno**: A comunicação entre componentes é rápida e direta, uma vez que ocorre dentro de um único processo.
- **Eficiência no gerenciamento de times**: Mais adequado para equipes menores e ciclos de entrega mais curtos.

Esse tipo de arquitetura é especialmente vantajoso nas fases iniciais de um projeto, onde a simplicidade de implementação, depuração e testes são essenciais. Para APIs relativamente pequenas, a ausência da sobrecarga de rede presente em uma arquitetura de microserviços traz ganhos de desempenho na comunicação interna.

---

## Padrão de Criação

Optamos pelo uso do padrão JSON (JavaScript Object Notation) no desenvolvimento de APIs devido aos inúmeros benefícios que ele proporciona, tanto em termos técnicos quanto de usabilidade. Um dos principais motivos é sua ampla compatibilidade. JSON é suportado por praticamente todas as linguagens de programação modernas, o que facilita a integração das APIs com diferentes sistemas e plataformas. Isso significa que independentemente do ambiente em que estejam trabalhando, podemos consumir e produzir dados de forma consistente em outras APIs.

Além disso, o JSON se destaca por sua leveza em comparação a outros formatos, como o XML. Sua estrutura mais simples permite que os dados sejam transmitidos mais rapidamente pela rede, o que contribui diretamente para o melhor desempenho das APIs. Esse fator é especialmente importante em cenários onde há limitações de banda, pois o menor volume de dados trafegando reduz a latência e melhora a experiência do usuário final.

Outro ponto relevante é a flexibilidade oferecida pelo JSON. Por ser um formato adaptável, ele permite que campos e propriedades sejam adicionados ou removidos sem que isso comprometa a compatibilidade com versões anteriores de uma API. Essa característica é fundamental para garantir a evolução contínua dos serviços, permitindo ajustes e melhorias de forma ágil, sem causar interrupções ou falhas na comunicação entre diferentes versões da API. Dessa maneira, o uso de JSON contribui para um desenvolvimento mais eficiente e uma manutenção mais simples das soluções de software.

---

## Diferenças entre as arquiteturas

Na arquitetura monolítica, a aplicação é concebida e executada como uma única e coesa unidade de software. Todo o código-fonte, desde os componentes de front-end até o back-end, incluindo a lógica de negócios e a integração com o banco de dados, está unificado em um único projeto ou processo. A implementação de uma API baseada nessa estrutura adota uma abordagem centralizada e direta, onde todas as funcionalidades estão interconectadas e funcionam dentro de um mesmo ambiente de execução, proporcionando uma comunicação mais eficiente entre os diferentes módulos da aplicação.

A Camada de Apresentação, representada pelos Controllers, é a responsável por expor os endpoints da API para que os clientes ou consumidores possam interagir com os recursos oferecidos. Nessa camada, as requisições HTTP são recebidas, processadas e encaminhadas para as camadas responsáveis por tratar a lógica de negócios e manipulação dos dados.

Já a Camada de Domínio, composta pelos Models, define as entidades que a API manipula. Essas entidades representam os objetos de domínio, ou seja, os recursos específicos da aplicação, como produtos, usuários ou qualquer outro elemento relevante para o funcionamento da API.

Os endpoints responsáveis pelas operações CRUD (Create, Read, Update e Delete) serão implementados seguindo essa arquitetura monolítica. Isso implica que todas as operações relativas aos recursos da API, como a criação de novos registros, leitura, atualização e remoção de dados, estarão centralizadas no mesmo núcleo da aplicação, permitindo uma gestão unificada e simplificada dos dados e funcionalidades.

---

## Testes Unitários e Integração
Serão implementados testes para garantir a funcionalidade da API:

- Testes Unitários: Validação das funcionalidades da API, especialmente a lógica dos endpoints CRUD.
- Testes de Integração: Verificação da comunicação com o banco de dados Oracle.

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


















