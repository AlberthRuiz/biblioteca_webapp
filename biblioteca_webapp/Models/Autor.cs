using System.ComponentModel.DataAnnotations;
using biblioteca_webapp.Models;
namespace biblioteca_webapp.Models {
    public class Autor {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public required string Apellidos { get; set; }
        [StringLength(20, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public string? Identificacion { get; set; }

        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
