
using biblioteca_webapp.DTO;
using biblioteca_webapp.Models;
using AutoMapper;

namespace biblioteca_webapp.Utilidades;
public class AutoMapperProfiles : Profile {
    public AutoMapperProfiles() {
        CreateMap<Autor, AutorDTO>()
            .ForMember(dto => dto.NombresCompletos, config => config.MapFrom(src => mappNombreApellido(src)));

        CreateMap<Autor, AutorConLibrosDTO>()
                .ForMember(dto => dto.NombresCompletos, config => config.MapFrom(src => mappNombreApellido(src)));
        CreateMap<AutorCreacionDTO, Autor>();

        CreateMap<Autor, AutorCreacionDTO>();

        CreateMap<Libro, LibroDTO>();
        CreateMap<LibroCreacionDTO, Libro>();

        CreateMap<Libro, LibroConAutorDTO>()
            .ForMember(dto => dto.AutorNombre, config => config.MapFrom(src => mappNombreApellido(src.Autor!)));
    }
    string mappNombreApellido(Autor autor) => $"{autor!.Nombres} {autor.Apellidos}";
}
