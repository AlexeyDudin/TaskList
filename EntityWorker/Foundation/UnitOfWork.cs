using Domain;
using Domain.Foundation;

namespace EntityWorker.Foundation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TaskDbContext _dbContext;
        private IRepository<Domain.Task> _taskRepo;
        private IRepository<Domain.User> _userRepo;

        public UnitOfWork(TaskDbContext context)
        {
            _dbContext = context;
            _taskRepo = new Repository<Domain.Task>(_dbContext);
            _userRepo = new Repository<Domain.User>(_dbContext);
        }

        public IRepository<Domain.Task> TaskRepository
        {
            get => _taskRepo;
        }

        public IRepository<User> UserRepository
        {
            get => _userRepo;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
