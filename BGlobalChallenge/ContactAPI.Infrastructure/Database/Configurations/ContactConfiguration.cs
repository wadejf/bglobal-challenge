using ContactAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactAPI.Infrastructure.Database.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Company)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.ProfileImage)
            .IsRequired();

        builder.Property(c => c.BirthDate)
            .IsRequired();

        builder.Property(c => c.PersonalPhone)
            .IsRequired();

        builder
            .OwnsOne(b => b.Address);
    }
}