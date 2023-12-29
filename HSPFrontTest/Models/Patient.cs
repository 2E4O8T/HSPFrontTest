using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSPFrontTest.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public ICollection<Rendezvous>? Rendezvous { get; set; }
    }
}
