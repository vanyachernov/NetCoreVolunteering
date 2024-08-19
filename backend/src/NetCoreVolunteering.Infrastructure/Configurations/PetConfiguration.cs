using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        builder
            .HasKey(p => p.Id);
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        builder
            .HasOne(p => p.Species)
            .WithMany()
            .HasForeignKey("species_id");
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        builder
            .HasOne(p => p.Breed)
            .WithMany()
            .HasForeignKey("breed_id");
        builder
            .Property(p => p.Color)
            .IsRequired();
        builder
            .Property(p => p.HealthInfo)
            .IsRequired();
        builder
            .Property(p => p.Address)
            .IsRequired();
        builder
            .Property(p => p.Weight)
            .IsRequired();
        builder
            .Property(p => p.Height)
            .IsRequired();
        builder
            .Property(p => p.PhoneNumber)
            .IsRequired();
        builder
            .Property(p => p.IsNeutered)
            .IsRequired();
        builder
            .Property(p => p.BirthAt)
            .IsRequired();
        builder
            .Property(p => p.Status)
            .IsRequired();
        
        // So far.
        builder.OwnsMany(p => p.PaymentDetails, db =>
        {
            db.ToJson();
            db
                .Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            db
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        });
        
        builder.OwnsMany(p => p.Images, pb =>
        {
            pb.ToJson();
            pb
                .Property(i => i.Path)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            pb
                .Property(i => i.IsMainPhoto)
                .IsRequired();
        });
    }
}