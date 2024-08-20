using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models;
using NetCoreVolunteering.Domain.Models.Pets;
using NetCoreVolunteering.Domain.Models.Pets.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder
            .HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));
        
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.ComplexProperty(p => p.SpeciesId, pb =>
        {
            pb.Property(p => p.Value)
                .HasColumnName("species_id");
        });
        
        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("general_description")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.BreedId, pb =>
        {
            pb.Property(p => p.Value)
                .HasColumnName("breed_id");
        });

        builder.ComplexProperty(p => p.Color, dс =>
        {
            dс.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("color")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.HealthInfo, dс =>
        {
            dс.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("health_info")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Address, da =>
        {
            da.Property(d => d.City)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("city")
                .IsRequired();
            
            da.Property(d => d.State)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("state")
                .IsRequired();
            
            da.Property(d => d.ZipCode)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("zip_code")
                .IsRequired();
            
            da.Property(d => d.Street)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("street")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.PetAttributes, dp =>
        {
            dp.Property(d => d.Weight)
                .HasColumnName("pet_weight")
                .IsRequired();
            
            dp.Property(d => d.Height)
                .HasColumnName("pet_height")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Phone, dp =>
        {
            dp.Property(d => d.Value)
                .HasColumnName("spokesman_phone")
                .IsRequired();
        });
        
        builder.Property(p => p.IsNeutered).IsRequired();
        
        builder.Property(p => p.BirthAt).IsRequired();
        
        builder.Property(p => p.IsVaccinated).IsRequired();
        
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