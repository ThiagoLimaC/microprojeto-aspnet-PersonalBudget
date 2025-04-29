# microprojeto-aspnet-PersonalBudget

<img src="wwwroot/img/videoprojetoPersonalBudget.gif" width=700px>

## Vis�o Geral
O **microprojeto-aspnet-PersonalBudget** � uma aplica��o web desenvolvida com ASP.NET Core e Blazor, projetada para gerenciar or�amentos pessoais. Ele permite que os usu�rios acompanhem registros financeiros, categorizem despesas, filtrem registros por status, etiquetas e vencimento, e realizem a��es como marcar pagamentos e excluir registros pagos.

## Funcionalidades Principais
- **Gerenciamento de Registros**: Adicionar, visualizar e excluir registros financeiros.
- **Filtragem Avan�ada**: Filtrar registros por etiquetas, status e vencimento (passado, presente ou futuro).
- **Marcar Pagamentos**: Alterar o status de um registro para "pago".
- **Exclus�o de Registros Pagos**: Remover registros que j� foram pagos.
- **Interface Intuitiva**: Interface baseada em tabelas para exibi��o e manipula��o de registros.

## Tecnologias Utilizadas
- **ASP.NET Core**: Framework principal para o backend.
- **Blazor**: Para a constru��o de componentes interativos e reutiliz�veis.
- **Entity Framework Core**: Para acesso e manipula��o do banco de dados.
- **Bootstrap**: Para estiliza��o e layout responsivo.

## Estrutura do Projeto
- **Controllers**: Cont�m os controladores respons�veis por gerenciar as requisi��es HTTP.
  - `HomeController.cs`: Controlador principal que gerencia as a��es relacionadas aos registros financeiros.
- **Views**: Cont�m as p�ginas da interface do usu�rio.
  - `Index.cshtml`: P�gina principal para exibi��o e manipula��o de registros.
  - `Adicionar.cshtml`: P�gina para adicionar novos registros.
- **Models**: Cont�m as classes que representam os dados do dom�nio.
  - `Registro`: Representa um registro financeiro.
  - `Etiqueta`: Representa uma categoria ou etiqueta associada a um registro.
  - `Status`: Representa o status de um registro (ex.: "pago", "n�o-pago").
- **Data**: Cont�m o contexto do banco de dados.
  - `AppDbContext`: Gerencia o acesso ao banco de dados e a configura��o inicial.

## Configura��o do Projeto

### Pr�-requisitos
- **.NET 9 SDK**: Certifique-se de que o SDK do .NET 9 est� instalado.
- **Banco de Dados**: O projeto utiliza o Entity Framework Core. Configure o banco de dados no arquivo `appsettings.json`.

## Uso

### P�gina Principal (Index)
- Exibe uma tabela com todos os registros financeiros.
- Permite filtrar registros por:
  - **Etiqueta**: Categoria associada ao registro.
  - **Data de Vencimento**: Passado, presente ou futuro.
  - **Status**: Pago ou n�o-pago.
- A��es dispon�veis:
  - **Marcar como Pago**: Altera o status de um registro para "pago".
  - **Excluir Registros Pagos**: Remove todos os registros com status "pago".

### Adicionar Registro
- Permite criar um novo registro financeiro.
- Campos obrigat�rios:
  - Nome
  - Valor
  - Etiqueta
  - Status
   