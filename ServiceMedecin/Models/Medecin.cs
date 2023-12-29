using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceMedecin.Models
{
    [Table("Medecin")]
    public class Medecin
    {
        [Key]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Specialite { get; set; }
    }
}