using SupportApp.Proyects;
using AutoMapper;
namespace SupportApp.AutoMapperProfile;

public class AutoMappProfile : Profile
{
    public AutoMappProfile()
    {
        CreateMap<Proyects.Proyects, ProyectDto>();
        CreateMap<CreateProyectDto, Proyects.Proyects>();
    }
}