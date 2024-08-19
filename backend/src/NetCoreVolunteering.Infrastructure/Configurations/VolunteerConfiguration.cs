using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Models;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        
        builder
            .HasKey(v => v.Id);
        
        builder
            .Property(v => v.FullName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder
            .Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        
        builder
            .Property(v => v.ExperienceYears)
            .HasDefaultValue(0)
            .IsRequired();
        
        builder
            .Property(v => v.Phone)
            .IsRequired();
        
        builder
            .HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("pet_id");
        
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