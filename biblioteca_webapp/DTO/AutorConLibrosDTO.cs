namespace biblioteca_webapp.DTO;

public class AutorConLibrosDTO : AutorDTO {
    public List<LibroDTO> Libros { get; set; } = new List<LibroDTO>();
}
