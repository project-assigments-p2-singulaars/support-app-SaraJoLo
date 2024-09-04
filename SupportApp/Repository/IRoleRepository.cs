namespace SupportApp.Models;

public interface IRoleRepository
{
    Task<List<Roles>> GetAllRoles();
    Task<Roles> CreateProject(Roles roleDto);
    Task<bool> ExistRole(int id);
    Task UpdateProject(Roles role);
}