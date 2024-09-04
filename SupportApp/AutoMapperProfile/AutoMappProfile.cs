using SupportApp.Proyects;
using AutoMapper;
using SupportApp.DTOs;
using SupportApp.Models;

namespace SupportApp.AutoMapperProfile;

public class AutoMappProfile : Profile
{
    public AutoMappProfile()
    {
        CreateMap<Proyects.Proyects, ProyectDto>();
        CreateMap<CreateProyectDto, Proyects.Proyects>();
        CreateMap<CreateProyectDto, ProyectDto>();
        CreateMap<Proyects.Proyects, CreateProyectDto>();
        
        CreateMap<SupportTask, SupportTaskDto>();
        CreateMap<CreateSupportTaskDto, SupportTask>();
        CreateMap<CreateSupportTaskDto, SupportTaskDto>();
        CreateMap<SupportTask, CreateSupportTaskDto>();
        
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<CreateUserDto, UserDto>();
        CreateMap<User, CreateProyectDto>();
        
        CreateMap<Roles, RoleDto>();
        CreateMap<CreateRoleDto, Roles>();
        CreateMap<CreateRoleDto, RoleDto>();
        CreateMap<Roles, CreateRoleDto>();
    }
}