using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Template.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), nameof(User));

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Ignore(user => user.DomainEvents);

            builder.OwnsOne(user => user.FirstName)
                   .Property(firstName => firstName.Value)
                   .HasColumnName(nameof(FirstName))
                   .HasMaxLength(FirstName.MaxLength)
                   .IsRequired();

            builder.OwnsOne(user => user.LastName)
                   .Property(lastName => lastName.Value)
                   .HasColumnName(nameof(LastName))
                   .HasMaxLength(LastName.MaxLength)
                   .IsRequired();

            builder.OwnsOne(user => user.BirthDate)
                   .Property(birthDate => birthDate.Value)
                   .HasColumnName(nameof(BirthDate))
                   .IsRequired();
        }
    }
}