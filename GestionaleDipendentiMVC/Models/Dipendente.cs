namespace GestionaleDipendentiMVC.Models
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Cognome { get; set; }
        public double Stipendio { get; set; }
        public int RuoloId { get; set; }
        public Ruolo Ruolo { get; set; }
    }
}
