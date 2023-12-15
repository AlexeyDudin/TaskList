using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace EntityWorker.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UserList");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Login);
        }
    }
}
