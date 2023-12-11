namespace Domain.Foundation
{
    public interface IUnitOfWork
    {
        public IRepository<Task> TaskRepository { get; }

        public IRepository<User> UserRepository { get; }

        public void Commit();
    }
}
