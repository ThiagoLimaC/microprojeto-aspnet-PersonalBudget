namespace microprojeto_aspnet_PersonalBudget.Models
{
    public class Filtros
    {
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

        public bool TemEtiqueta => EtiquetaId.ToLower() != "todos";
        public bool TemVencimento => Vencimento.ToLower() != "todos";
        public bool TemStatus => StatusId.ToLower() != "todos";

        public static Dictionary<string, string> VencimentoValoresFiltro =>
            new Dictionary<string, string>
            {
                {"futuro", "Futuro" },
                {"passado", "Passado" },
                {"hoje", "Hoje" },
            };

        public bool EPassado => Vencimento.ToLower() == "passado";
        public bool EFuturo => Vencimento.ToLower() == "futuro";
        public bool EHoje => Vencimento.ToLower() == "passado";
    }
}
