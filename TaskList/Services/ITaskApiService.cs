using TaskList.Dto.Models;
using TaskList.Dto.Response;

namespace TaskList.Services
{
    public interface ITaskApiService
    {
        Result GetAllTask();
        Result GetActiveTask();
        Result AddTask(TaskDto dto);
        Result GetStatuses();
        Result GetTasksByStatus(StatusDto status);
    }
}
