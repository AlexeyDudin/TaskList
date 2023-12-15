namespace Application
{
    public interface IUserService
    {
        public Domain.User AddUser(Domain.User user);
        public Domain.User UpdateUser(Domain.User user);
        public Domain.User DeleteUser(Domain.User user);
        public Domain.User GetUserByLogin(string login);
        public Domain.User GetUserInfo(string login, string password);
    }
}
