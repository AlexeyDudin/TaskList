namespace TaskList.Dto.Models
{
    public class UserDto
    {
        public string login { get; set; } = "";
        public string password { get; set; } = "";
        public string fullName { get; set; } = "";
        public int role { get; set; } = 0;
    }
}
