using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaEliminar.Models
{
    [Table ("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("Doctor_no")]
        public  int IdDoctor {  get; set; }

        [Column("hospital_cod")]
        public int IdHospital { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; }

        [Column("Salario")]
        public int Salario { get; set; }
    }
}
