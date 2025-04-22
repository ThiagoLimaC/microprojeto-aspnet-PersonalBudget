namespace microprojeto_aspnet_PersonalBudget.Models
{
    public class Filtros
    {
        // recebe o filtro na forma de string e separa os valores inserindo-os nas propriedades
        public Filtros(string filtroString)
        {
            FiltroString = filtroString ?? "todos-todos-todos";
            string[] filtros = FiltroString.Split('-');

            EtiquetaId = filtros[0];
            Vencimento = filtros[1];
            StatusId = filtros[2];
        }

        public string FiltroString { get; set; }
        public string EtiquetaId { get; set; }
        public string StatusId { get; set; }
        public string Vencimento { get; set; }


        // / Propriedades para verificar se o filtro foi aplicado
        public bool TemEtiqueta => EtiquetaId.ToLower() != "todos";
        public bool TemVencimento => Vencimento.ToLower() != "todos";
        public bool TemStatus => StatusId.ToLower() != "todos";

        // Dictionário para os filtros de vencimento
        public static Dictionary<string, string> VencimentoValoresFiltro =>
            new Dictionary<string, string>
            {
                {"futuro", "Futuro" },
                {"passado", "Passado" },
                {"hoje", "Hoje" },
            };

        // Propriedades para verificar o tipo de vencimento
        public bool EPassado => Vencimento.ToLower() == "passado";
        public bool EFuturo => Vencimento.ToLower() == "futuro";
        public bool EHoje => Vencimento.ToLower() == "passado";
    }
}
