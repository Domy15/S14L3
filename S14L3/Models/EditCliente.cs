using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace S14L3.Models
{
    public class EditCliente
    {
        public Guid _id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        public string _nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        public string _cognome { get; set; }

        public bool _tipoBiglietto { get; set; }

        public string _sala { get; set; }
        public List<SelectListItem> Sale { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem{Value = "N", Text = "SALA NORD"},
            new SelectListItem{Value = "S", Text = "SALA SUD"},
            new SelectListItem{Value = "E", Text = "SALA EST"}
        };
    }
}
