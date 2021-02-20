# [GAMA ACADEMY] Sistema de Locação de Veículos de Passeio
Desafio Gama Academy - Back-end .NET

- Grupo Back-end: [Érica Viana](https://github.com/vianaerica "Érica Viana") e [Patrik Oliveira](https://github.com/patrikoliveira "Patrik Oliveira")

- Grupo Front-end: Erick Santos e Icaro Lettieri

------------


### Tecnologias e Frameworks
- .NET Core 5.0
- PostgreSQL
- Git/Github
- Clean Architecture
- REST API
- Entity Framework
- Request-Response Pattern
- Unit of Work Pattern

------------


#### Futuras Melhorias
- Reestruturação para microserviços
- Utilização de comunicação por mensageria
- Realização de testes e atingir o máximo de cobertura possível
- Utilização de cache para listagens/pesquisas
- Melhorar validação de campos e requisições
- Melhorar tratamento de erros/respostas das requisições
	#####Melhorias Situacionais:
	- **API para 1000 usuários:** 1- utilização de tecnologias e ferramentas open source; 2- manter estrutura monolítica para evitar custos; 3- levantamento e testes para identificar gargalos; 4- manter o sistema com o minímo de custo possível, gerando economia para o negócio.
	- **API para 1000 usuários:** 1- levantamento de conexões simultâneas no sistema; 2- migração do core do sistema para microserviço e, futuramente, transformar o sistema todo com essa arquitetura; 3- utilizar comunicação por mensageria; 4- utilização de cache para otimizar pesquisas e listagens.

------------

##Estrura do Projeto
Seguimos uma linha Clean Architecture, para facilitar a mudança de sistema monolítico para microserviços no futuro.


📂 Domain
	L📂 Authentication
	L📂 Entities
		L📂 Enums
		L📂 Exceptions
	L📂 Repositories
	L📂 Services
		L📂 Communication
📂 Infrastructure
	L📂 Authentication
	L📂 Database
	L📂 Pdfservice
	L📂 Repositories
📂 Migrations *(gerado automaticamente pelo Entity Framework)*
📂 Presentation
	L📂 Controllers
	L📂 Viewmodel
📂 Services

------------
###Projeto: 
####1. Entidades
- Agendamento
- Categoria
- Checklist
- Cliente
- Combustivel
- Endereco
- Marca
- Modelo
- Operador
- Usuario
- Veiculo
- TipoUsuario *(Enum)*

####2. Autenticação
- Token *(utilizando Jwt Bearer)*

####3. Banco de Dados
- EntityContext *(DbSets conforme as entidades)*

####4. Repositórios
- EntityRepository *(CRUD básico e genérico para atender todas as entidades)*
- VeiculoRepository  *(Listagem específica para a entidade Veiculos - para retornar veículos disponível para aluguel)*

####5. Serviços
- AgendamentoService* (regra de negócio referente ao agendamento/aluguel do carro)*
- LoginService *(serviço que verifica login e senha, e gera token de acesso)*
- VeiculoService *(serviço que lista veículos disponíveis para aluguel)*
- EntityService* (implementação genérica do CRUD utilizado pela maioria das entidades)*
- PdfService *(serviço que gera o contrato de aluguel no formato PDF)*

####6. Controllers
Classes de Requisições (GET/POST/PUT/DELETE) conforme Entidade

- AgendamentoController
- CategoriasController
- ClienteController
- MarcaController
- ModelosController
- OperadorController
- LoginController
- VeiculosController

------------


