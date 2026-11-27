using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment2.Entities;
using MVC_Assignment2.Models;
namespace MVC_Assignment2.Configrations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(X => X.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(X => X.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.HasIndex(X => X.Email).IsUnique();
            builder.HasIndex(X => X.Phone).IsUnique();

            builder.ComplexProperty(X => X.Address);

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("Email_FormatCheck", "Email like '_%@_%._%'");
                T.HasCheckConstraint("Phone_FormatCheck", "Len(Phone)=11 And (Phone like '010%' or Phone like '011%' or Phone like '012%' or Phone like '015%')");
            });
        }
    }
}
