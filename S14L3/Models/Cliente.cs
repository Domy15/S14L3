using System.ComponentModel.DataAnnotations;

namespace S14L3.Models
{
    public class Cliente
    {
        public Guid _id { get; set; }

        public string _nome { get; set; }

        public string _cognome { get; set; }

        public bool _tipoBiglietto { get; set; }
    }
}
