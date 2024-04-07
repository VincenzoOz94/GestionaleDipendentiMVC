using System.ComponentModel.DataAnnotations;

namespace GestionaleDipendentiMVC.Models
{
    public class Ruolo
    {
        public int Id { get; set; }
        [Display(Name ="ruolo aziendale")]
        public string NomeRuolo { get; set; }
    }
}
