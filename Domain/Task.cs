using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Task
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; } = "";
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? EstimateTime { get; set; } = DateTime.Now.AddDays(14);
        public TaskState State { get; set; } = TaskState.New;
        public int? UserIssueId { get; set; }
        public int? UserWorkerId { get; set; }

        [ForeignKey(nameof(UserIssueId))]
        public User? UserIssue { get; set; }
        [ForeignKey(nameof(UserWorkerId))]
        public User? UserWorker { get; set; }
    }
}
