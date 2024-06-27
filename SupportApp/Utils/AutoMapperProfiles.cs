using AutoMapper;
using SupportApp.Proyects;

namespace SupportApp.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
            CreateMap<Proyects.Proyects, ProyectDto>();
            CreateMap<CreateProyectDto, Proyects.Proyects>();
            
            CreateMap<SupportTask, SupportTaskDto>();
            CreateMap<CreateSupportTaskDto, SupportTask>();
    }
}