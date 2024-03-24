using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Personal_Web_API.Models;

public partial class PersonalWebDbContext : DbContext
{
    public PersonalWebDbContext()
    {
    }

    public PersonalWebDbContext(DbContextOptions<PersonalWebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutMe> AboutMes { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<FutureProject> FutureProjects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SocialMedium> SocialMedia { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutMe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AboutMe__3213E83FF142E2E4");

            entity.ToTable("AboutMe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AboutMeDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("about_me_description");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3213E83FAEA5C5CD");

            entity.ToTable("Experience");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExperienceDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("experience_description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FutureProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuturePr__3213E83F11FC2B50");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("project_description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3213E83FBAF5FFD0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_name");
            entity.Property(e => e.ProjectUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("project_url");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3213E83F3C657CEE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SkillDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("skill_description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SocialMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SocialMe__3213E83F4DCAACAB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.SocialMediaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("social_media_name");
            entity.Property(e => e.SocialMediaUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("social_media_url");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FFD00D4C8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
