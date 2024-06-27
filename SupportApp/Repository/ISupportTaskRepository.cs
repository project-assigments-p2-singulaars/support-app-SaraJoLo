

namespace SupportTask.Repository;

public interface ISupportTaskRepository
{
    Task<List<SupportApp.SupportTask>> GetAllSupportTasks();
    Task<int> CreateSupportTask( SupportApp.SupportTask supportTask );
}