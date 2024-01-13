using Domain;

namespace Application
{
    public interface ITaskService
    {
        public Domain.Task AddTask(Domain.Task task);
        public List<Domain.Task> GetAllTasks();
        public List<Domain.Task> GetActiveTask();
        public List<Domain.Task> GetArchiveTask();
        public List<string> GetStatuses();
        public List<Domain.Task> GetTasksByStatusId(int id);
    }
}
