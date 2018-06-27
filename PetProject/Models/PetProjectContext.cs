using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetProject.Models
{
    public partial class PetProjectContext : DbContext
    {
        public PetProjectContext()
        {
        }

        public PetProjectContext(DbContextOptions<PetProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pets> Pets { get; set; }
        public virtual DbSet<Shelters> Shelters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-7BEERKL\\SQLEXPRESS;Database=PetProject;user=root;password=a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pets>(entity =>
            {
                entity.ToTable("pets");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PetBreed1)
                    .HasColumnName("pet_breed1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetBreed2)
                    .HasColumnName("pet_breed2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetDescription)
                    .HasColumnName("pet_description")
                    .IsUnicode(false);

                entity.Property(e => e.PetDetails)
                    .HasColumnName("pet_details")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetGender)
                    .HasColumnName("pet_gender")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetId)
                    .HasColumnName("pet_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetLastUpdated)
                    .HasColumnName("pet_lastUpdated")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetName)
                    .HasColumnName("pet_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetPhotosLink)
                    .HasColumnName("pet_photosLink")
                    .IsUnicode(false);

                entity.Property(e => e.PetType)
                    .HasColumnName("pet_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterId)
                    .IsRequired()
                    .HasColumnName("shelter_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.Pets)
                    .HasPrincipalKey(p => p.ShelterId)
                    .HasForeignKey(d => d.ShelterId)
                    .HasConstraintName("FK_Pets_ShelterID");
            });

            modelBuilder.Entity<Shelters>(entity =>
            {
                entity.ToTable("shelters");

                entity.HasIndex(e => e.ShelterId)
                    .HasName("Shelter_sID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShelterAddress)
                    .HasColumnName("shelter_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterCity)
                    .HasColumnName("shelter_city")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterEmail)
                    .HasColumnName("shelter_email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterId)
                    .IsRequired()
                    .HasColumnName("shelter_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterLatitude).HasColumnName("shelter_latitude");

                entity.Property(e => e.ShelterLongitude).HasColumnName("shelter_longitude");

                entity.Property(e => e.ShelterName)
                    .HasColumnName("shelter_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterPhoneNumber)
                    .HasColumnName("shelter_phone_number")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterZip)
                    .HasColumnName("shelter_zip")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}
