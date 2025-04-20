using System.ComponentModel.DataAnnotations;

namespace biblioteca_webapp.Models {
    public class Libro {
        public int Id { get; set; }
        [Required]
        public required string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

    }
}
