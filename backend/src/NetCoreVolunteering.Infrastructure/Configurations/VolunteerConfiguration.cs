using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.PetManagement;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

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
                id => id.Value,
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
        
        builder.ComplexProperty(p => p.Ages, db =>
        {
            db.Property(d => d.Value)
                .HasColumnName("experience_years")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Phone, de =>
        {
            de.Property(d => d.Value)
                .HasColumnName("phone")
                .IsRequired();
        });

        builder
            .OwnsOne(v => v.RequisiteList, rb =>
            {
                rb.ToJson("requisite_list");

                rb.OwnsMany(r => r.Requisites, rbb =>
                {
                    rbb.Property(p => p.Title).IsRequired();
                    
                    rbb.Property(p => p.Description).IsRequired();
                });
            });
        
        builder
            .OwnsOne(v => v.SocialsList, sb =>
            {
                sb.ToJson("socials_list");

                sb.OwnsMany(r => r.Socials, rbb =>
                {
                    rbb.Property(s => s.Link).IsRequired();
                
                    rbb.Property(s => s.Title).IsRequired();
                });
            });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}