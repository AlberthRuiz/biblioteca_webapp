namespace biblioteca_webapp.DTO;

public class LibroConAutorDTO : LibroDTO {
    public int AutorId { get; set; }
    public required string AutorNombre { get; set; }
}
