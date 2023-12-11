using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; } = "";
        public string FullName { get; set; } = "";
        public UserRole Role { get; set; } = UserRole.User;
        public List<Task> IssueTasks { get; set; } = new List<Task>();
        public List<Task> WoredTasks { get; set; } = new List<Task>();
    }
}
