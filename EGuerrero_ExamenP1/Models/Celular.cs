using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EGuerrero_ExamenP1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotNull]
        [StringLength(50)]
        public string Modelo { get; set; }
        [Required]
        [Range(2020, 2024, ErrorMessage = "El celular debe estar entre el año 2020 al 2024")]
        public int Año { get; set; }
        public double Precio { get; set; }
    }
}
