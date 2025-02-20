using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace S14L3.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        public string Nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        public string Cognome { get; set; }

        public bool TipoBiglietto { get; set; }

        [Display(Name = "Sala")]
        public string Sala { get; set; }

        public List<SelectListItem> Sale { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem{Value = "N", Text = "SALA NORD"},
            new SelectListItem{Value = "S", Text = "SALA SUD"},
            new SelectListItem{Value = "E", Text = "SALA EST"}
        };

        public List<Cliente>? SalaNORD {  get; set; }
        public List<Cliente>? SalaSUD {  get; set; }
        public List<Cliente>? SalaEST { get; set; }
    }
}

