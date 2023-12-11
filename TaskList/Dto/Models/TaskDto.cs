namespace TaskList.Dto.Models
{
    public class TaskDto
    {
        public string Text { get; set; } = "";
        public int State { get; set; } = 0; 
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? EstimateTime { get; set; }
        public string UserIssueName { get; set; } = "";
        public string UserWorkerName { get; set; } = "";
    }
}
