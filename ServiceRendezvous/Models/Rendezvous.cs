using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceRendezvous.Models
{
    [Table("Rendezvous")]
    public class Rendezvous
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateRendezvous { get; set; }

        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }

        [ForeignKey("MedecinId")]
        public Guid MedecinId { get; set; }
    }
}
