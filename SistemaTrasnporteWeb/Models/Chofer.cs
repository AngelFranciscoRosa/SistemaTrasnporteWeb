using System.ComponentModel.DataAnnotations;

namespace SistemaTransporteWeb.Models
{
    public class Chofer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(13)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Licencia { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}