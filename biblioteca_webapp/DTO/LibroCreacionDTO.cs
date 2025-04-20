using System.ComponentModel.DataAnnotations;

namespace biblioteca_webapp.DTO;

    public class LibroCreacionDTO
    {
        [Required]
        public required string Titulo { get; set; }
        public int AutorId { get; set; }
    }
