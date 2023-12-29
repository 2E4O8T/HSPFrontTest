using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSPFrontTest.Models
{
    [Table("Medecin")]
    public class Medecin
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Specialite { get; set; }

        public ICollection<Rendezvous>? Rendezvous { get; set; }
    }
}
