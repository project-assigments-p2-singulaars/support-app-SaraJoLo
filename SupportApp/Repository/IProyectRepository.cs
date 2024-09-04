namespace SupportApp.Proyects;

public interface IProyectRepository
{
    Task<List<Proyects>> GetAllProyects();
    Task<int> CreateProyects(Proyects createProyectDto);
    Task UpdateProyect(Proyects proyect);
    Task<bool> ExistProyects(int id);
    Task Delete(int id);
}