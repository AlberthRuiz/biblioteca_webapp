using System.ComponentModel.DataAnnotations;
using biblioteca_webapp.Models;
namespace biblioteca_webapp.DTO {
    public class AutorCreacionDTO {
        public required string Nombres { get; set; }

        public required string Apellidos { get; set; }

        public string? Identificacion { get; set; }
    }
}
