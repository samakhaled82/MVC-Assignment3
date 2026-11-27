using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Models;
namespace MVC_Assignment2.Configrations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("DurationDays_Check", "DurationDays Between 1 AND 365");
            });
        }
    
    }
}
