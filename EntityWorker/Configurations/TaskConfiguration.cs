using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace EntityWorker.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Task> builder)
        {
            builder.ToTable("TaskList");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.UserIssue).WithMany(u => u.IssueTasks).HasForeignKey(t => t.UserIssueId);
            builder.HasOne(t => t.UserWorker).WithMany(u => u.WoredTasks).HasForeignKey(t => t.UserWorkerId);
        }
    }
}
