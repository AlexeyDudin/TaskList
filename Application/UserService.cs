using Domain;
using Domain.Foundation;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public User AddUser(User user)
        {
            var nullUser = _unitOfWork.UserRepository.FirstOrDefault(u => u.Login == user.Login);
            if (nullUser != null)
            {
                throw new Exception($"Невозможно добавить пользователя с ником {user.Login}. Пользователь уже существует");
            }
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
            return user;
        }

        public User DeleteUser(User user)
        {
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Commit();
            return user;
        }

        public User GetUserByLogin(string login)
        {
            var user = _unitOfWork.UserRepository.FirstOrDefault(u => u.Login == login);
            if (user == null) 
            {
                throw new ArgumentException($"User {login} not found");
            }
            //_unitOfWork.Commit();
            return user;
        }

        public User GetUserInfo(string login, string password)
        {
            var user = _unitOfWork.UserRepository.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if (user == null)
                throw new Exception($"Пользователь с логином {login} не найден");
            return user; 
        }

        public User UpdateUser(User user)
        {
            var userInDb = _unitOfWork.UserRepository.FirstOrDefault(u => u.Login == user.Login);
            if (user == null)
            {
                throw new ArgumentException($"User {user.Login} not found");
            }
            userInDb.FullName = user.FullName;
            _unitOfWork.Commit();
            return userInDb;
        }
    }
}
