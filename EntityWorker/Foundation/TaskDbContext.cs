using Domain;
using EntityWorker.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EntityWorker.Foundation
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
