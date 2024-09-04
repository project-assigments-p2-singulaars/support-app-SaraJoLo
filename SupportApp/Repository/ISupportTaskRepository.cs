namespace SupportTask.Repository;

public interface ISupportTaskRepository
{
    Task<List<SupportApp.SupportTask>> GetAllSupportTasks();
    Task<int> CreateSupportTask(SupportApp.SupportTask supportTaskDto);
    Task UpdateTask(SupportApp.SupportTask updateSupportTask);
    Task<bool> ExistTask(int id);
    Task DeleteTask(int id);
}