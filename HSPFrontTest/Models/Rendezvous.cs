using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSPFrontTest.Models
{
    [Table("Rendezvous")]
    public class Rendezvous
    {
        [Key]
        public int id { get; set; }
        public DateTime DateRendezvous { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [ForeignKey("Medecin")]
        public int MedecinId { get; set; }
        public Medecin? Medecin { get; set; }
    }
}
