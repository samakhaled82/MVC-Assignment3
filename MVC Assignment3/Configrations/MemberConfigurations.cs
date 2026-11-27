using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Models;
namespace MVC_Assignment2.Configrations
{
    public class MemberConfigurations : GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()")
                .HasColumnName("JoinDate");

            base.Configure(builder);
        }

    }
}
