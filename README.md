# microprojeto-aspnet-PersonalBudget

<img src="wwwroot/img/videoprojetoPersonalBudget.gif" width=700px>

## Visão Geral
O **microprojeto-aspnet-PersonalBudget** é uma aplicação web desenvolvida com ASP.NET Core e Blazor, projetada para gerenciar orçamentos pessoais. Ele permite que os usuários acompanhem registros financeiros, categorizem despesas, filtrem registros por status, etiquetas e vencimento, e realizem ações como marcar pagamentos e excluir registros pagos.

## Funcionalidades Principais
- **Gerenciamento de Registros**: Adicionar, visualizar e excluir registros financeiros.
- **Filtragem Avançada**: Filtrar registros por etiquetas, status e vencimento (passado, presente ou futuro).
- **Marcar Pagamentos**: Alterar o status de um registro para "pago".
- **Exclusão de Registros Pagos**: Remover registros que já foram pagos.
- **Interface Intuitiva**: Interface baseada em tabelas para exibição e manipulação de registros.

## Tecnologias Utilizadas
- **ASP.NET Core**: Framework principal para o backend.
- **Blazor**: Para a construção de componentes interativos e reutilizáveis.
- **Entity Framework Core**: Para acesso e manipulação do banco de dados.
- **Bootstrap**: Para estilização e layout responsivo.

## Estrutura do Projeto
- **Controllers**: Contém os controladores responsáveis por gerenciar as requisições HTTP.
  - `HomeController.cs`: Controlador principal que gerencia as ações relacionadas aos registros financeiros.
- **Views**: Contém as páginas da interface do usuário.
  - `Index.cshtml`: Página principal para exibição e manipulação de registros.
  - `Adicionar.cshtml`: Página para adicionar novos registros.
- **Models**: Contém as classes que representam os dados do domínio.
  - `Registro`: Representa um registro financeiro.
  - `Etiqueta`: Representa uma categoria ou etiqueta associada a um registro.
  - `Status`: Representa o status de um registro (ex.: "pago", "não-pago").
- **Data**: Contém o contexto do banco de dados.
  - `AppDbContext`: Gerencia o acesso ao banco de dados e a configuração inicial.

## Configuração do Projeto

### Pré-requisitos
- **.NET 9 SDK**: Certifique-se de que o SDK do .NET 9 está instalado.
- **Banco de Dados**: O projeto utiliza o Entity Framework Core. Configure o banco de dados no arquivo `appsettings.json`.

## Uso

### Página Principal (Index)
- Exibe uma tabela com todos os registros financeiros.
- Permite filtrar registros por:
  - **Etiqueta**: Categoria associada ao registro.
  - **Data de Vencimento**: Passado, presente ou futuro.
  - **Status**: Pago ou não-pago.
- Ações disponíveis:
  - **Marcar como Pago**: Altera o status de um registro para "pago".
  - **Excluir Registros Pagos**: Remove todos os registros com status "pago".

### Adicionar Registro
- Permite criar um novo registro financeiro.
- Campos obrigatórios:
  - Nome
  - Valor
  - Etiqueta
  - Status
   