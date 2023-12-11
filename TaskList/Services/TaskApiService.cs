using Application;
using TaskList.Converters;
using TaskList.Dto.Models;
using TaskList.Dto.Response;

namespace TaskList.Services
{
    public class TaskApiService : ITaskApiService
    {
        private readonly ITaskService _taskService;
        public TaskApiService(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public Result AddTask(TaskDto dto)
        {
            try
            {
                return new Result(_taskService.AddTask(dto.ConvertToTask()), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result GetActiveTask()
        {
            try
            {
                return new Result(_taskService.GetActiveTask(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result GetAllTask()
        {
            try
            {
                return new Result(_taskService.GetAllTasks(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }
    }
}
