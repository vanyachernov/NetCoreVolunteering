﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreVolunteering.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetCoreVolunteering.Infrastructure.Migrations
{
    [DbContext(typeof(PetDbContext))]
    partial class PetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Pets.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_at");

                    b.Property<Guid>("BreedId")
                        .HasColumnType("uuid")
                        .HasColumnName("breed_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsNeutered")
                        .HasColumnType("boolean")
                        .HasColumnName("is_neutered");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "NetCoreVolunteering.Domain.Models.Pets.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("city");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("zip_code");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Color", "NetCoreVolunteering.Domain.Models.Pets.Pet.Color#Color", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("color");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Description", "NetCoreVolunteering.Domain.Models.Pets.Pet.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("general_description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("HealthInfo", "NetCoreVolunteering.Domain.Models.Pets.Pet.HealthInfo#HealthInfo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("health_info");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PetAttributes", "NetCoreVolunteering.Domain.Models.Pets.Pet.PetAttributes#PetAttributes", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Height")
                                .HasColumnType("double precision")
                                .HasColumnName("pet_height");

                            b1.Property<double>("Weight")
                                .HasColumnType("double precision")
                                .HasColumnName("pet_weight");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Phone", "NetCoreVolunteering.Domain.Models.Pets.Pet.Phone#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("spokesman_phone");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("SpeciesId", "NetCoreVolunteering.Domain.Models.Pets.Pet.SpeciesId#SpeciesId", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Species.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Breeds")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("breeds");

                    b.Property<Guid?>("breed_id")
                        .HasColumnType("uuid")
                        .HasColumnName("breed_id");

                    b.HasKey("Id")
                        .HasName("pk_breeds");

                    b.HasIndex("breed_id")
                        .HasDatabaseName("ix_breeds_breed_id");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Species.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.ComplexProperty<Dictionary<string, object>>("Ages", "NetCoreVolunteering.Domain.Models.Volunteers.Volunteer.Ages#ExperienceYears", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Value")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(100)
                                .HasColumnType("integer")
                                .HasColumnName("last_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Description", "NetCoreVolunteering.Domain.Models.Volunteers.Volunteer.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("general_description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Email", "NetCoreVolunteering.Domain.Models.Volunteers.Volunteer.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "NetCoreVolunteering.Domain.Models.Volunteers.Volunteer.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("last_name");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("middle_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Phone", "NetCoreVolunteering.Domain.Models.Volunteers.Volunteer.Phone#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("phone");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Pets.Pet", b =>
                {
                    b.HasOne("NetCoreVolunteering.Domain.Models.Volunteers.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("NetCoreVolunteering.Domain.Models.Pets.Lists.PetPhotoList", "Images", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("images");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("NetCoreVolunteering.Domain.Models.Pets.ValueObjects.PetPhoto", "PetPhotos", b2 =>
                                {
                                    b2.Property<Guid>("PetPhotoListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("IsMainPhoto")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Path")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("PetPhotoListPetId", "Id");

                                    b2.ToTable("pets");

                                    b2.ToJson("images");

                                    b2.WithOwner()
                                        .HasForeignKey("PetPhotoListPetId")
                                        .HasConstraintName("fk_pets_pets_pet_photo_list_pet_id");
                                });

                            b1.Navigation("PetPhotos");
                        });

                    b.OwnsOne("NetCoreVolunteering.Domain.Models.Pets.Lists.RequisiteList", "PaymentDetails", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("payment_details");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("NetCoreVolunteering.Domain.Shared.ValueObjects.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisiteListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("RequisiteListPetId", "Id");

                                    b2.ToTable("pets");

                                    b2.ToJson("payment_details");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisiteListPetId")
                                        .HasConstraintName("fk_pets_pets_requisite_list_pet_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.Navigation("Images");

                    b.Navigation("PaymentDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Species.Breed", b =>
                {
                    b.HasOne("NetCoreVolunteering.Domain.Models.Species.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("breed_id")
                        .HasConstraintName("fk_breeds_species_breed_id");
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.OwnsMany("NetCoreVolunteering.Domain.Models.Volunteers.SocialNetwork", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Link")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VolunteerId", "Id");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_networks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.OwnsMany("NetCoreVolunteering.Domain.Shared.ValueObjects.Requisite", "PaymentDetails", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VolunteerId", "Id");

                            b1.ToTable("volunteers");

                            b1.ToJson("payment_details");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.Navigation("PaymentDetails");

                    b.Navigation("SocialNetworks");
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Species.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("NetCoreVolunteering.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
