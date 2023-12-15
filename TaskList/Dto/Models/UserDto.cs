namespace TaskList.Dto.Models
{
    public class UserDto
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public int Role { get; set; } = 0;
    }
}
