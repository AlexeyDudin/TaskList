using Domain;
using TaskList.Dto.Models;

namespace TaskList.Converters
{
    public static class TaskToDtoConverter
    {
        public static Domain.Task ConvertToTask(this TaskDto dto)
        {
            return new Domain.Task()
            {
                Text = dto.Text,
                State = (TaskState)dto.State,
                CreationDate = dto.CreationDate,
                EstimateTime = dto.EstimateTime,
                UserIssue = dto.UserIssueName.StringToUser(),
                UserWorker = dto.UserWorkerName.StringToUser()
            };
        }

        public static TaskDto ConvertToTaskDto(this Domain.Task task)
        {
            return new TaskDto()
            {
                Text = task.Text,
                State = (int)task.State,
                CreationDate = task.CreationDate,
                EstimateTime = task.EstimateTime,
                UserIssueName = task.UserIssue.UserToString(),
                UserWorkerName = task.UserWorker.UserToString()
            };
        }
    }
}
