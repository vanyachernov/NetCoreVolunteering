using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Models.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        
        builder
            .HasKey(v => v.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Id,
                value => VolunteerId.Create(value));
        
        builder.ComplexProperty(p => p.FullName, da =>
        {
            da.Property(d => d.LastName)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("last_name")
                .IsRequired();
            
            da.Property(d => d.MiddleName)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("middle_name")
                .IsRequired();
            
            da.Property(d => d.FirstName)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("first_name")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Email, de =>
        {
            de.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("email")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("general_description")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Ages, de =>
        {
            de.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("last_name")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Phone, de =>
        {
            de.Property(d => d.Value)
                .HasColumnName("phone")
                .IsRequired();
        });

        // So far.
        builder
            .OwnsMany(v => v.SocialNetworks, sb =>
            {
                sb.ToJson();
                
                sb
                    .Property(s => s.Link)
                    .IsRequired();
                
                sb
                    .Property(s => s.Title)
                    .IsRequired();
            });
        
        builder
            .OwnsMany(v => v.PaymentDetails, pb =>
            {
                pb.ToJson();
                
                pb
                    .Property(p => p.Title)
                    .IsRequired();
                
                pb
                    .Property(p => p.Description)
                    .IsRequired();
            });
    }
}