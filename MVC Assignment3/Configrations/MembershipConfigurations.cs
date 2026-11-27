using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Models;
namespace MVC_Assignment2.Configrations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>

    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(X => X.Id);

            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(Ms => Ms.Plan)
                .WithMany(P => P.PlanSubscriptions)
                .HasForeignKey(Ms => Ms.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(Ms => Ms.Member)
                .WithMany(M => M.MemberSubscriptions)
                .HasForeignKey(Ms => Ms.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(X => X.Status);
        }
    }
}
