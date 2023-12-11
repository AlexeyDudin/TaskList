using Domain;
using Domain.Foundation;
using EntityWorker.Foundation;

namespace Application
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Task AddTask(Domain.Task task)
        {
            var issueUser = _unitOfWork.UserRepository.FirstOrDefault(u => u.FullName == task.UserIssue.FullName);
            if (issueUser == null)
                throw new ArgumentException($"Пользователь {task.UserIssue.FullName} не найден!");
            var workerUser = _unitOfWork.UserRepository.FirstOrDefault(u => u.FullName == task.UserWorker.FullName);
            if (workerUser == null)
                throw new ArgumentException($"Пользователь {task.UserWorker.FullName} не найден!");
            task.UserIssue = issueUser;
            task.UserWorker = workerUser;
            _unitOfWork.TaskRepository.Add(task);
            return task;
        }

        public List<Domain.Task> GetActiveTask()
        {
            return _unitOfWork.TaskRepository.Where(t => t.State != TaskState.Archive);
        }

        public List<Domain.Task> GetAllTasks()
        {
            return _unitOfWork.TaskRepository.GetAll();
        }

        public List<Domain.Task> GetArchiveTask()
        {
            return _unitOfWork.TaskRepository.Where(t => t.State == TaskState.Archive);
        }
    }
}
