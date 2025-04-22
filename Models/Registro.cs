using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace microprojeto_aspnet_PersonalBudget.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o valor")]
        public float Valor { get; set; }
        [Required(ErrorMessage = "Preencha o nome")]
        public string Nome { get; set; }
        public DateTime? DataVencimento { get; set; }
        [Required(ErrorMessage = "Preencha a etiqueta")]
        public string EtiquetaId { get; set; }
        [ValidateNever]
        public Etiqueta Etiqueta { get; set; }
        [Required(ErrorMessage = "Preencha o status")]
        public string StatusId { get; set; }
        [ValidateNever]
        public Status Status { get; set; }

        public bool Atrasado => StatusId == "nao-pago" && DataVencimento < DateTime.Today;
    }
}
