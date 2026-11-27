using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Models;
namespace MVC_Assignment2.Configrations
{
    public class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("Session_CapacityCheck", "Capacity between 1 AND 25");
                T.HasCheckConstraint("Session_StartEndCheck", "EndDate>StartDate");
            });

            builder.HasOne(S => S.Trainer)
                .WithMany(T => T.Sessions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
