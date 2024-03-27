using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;

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

    public virtual DbSet<DisplayUserInfo> DisplayUsers { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__AboutMe__3213E83F58475094");

            entity.ToTable("AboutMe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AboutMeDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("about_me_description");
            entity.Property(e => e.AboutMeUserId).HasColumnName("about_me_user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AboutMeUser).WithMany(p => p.AboutMes)
                .HasForeignKey(d => d.AboutMeUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AboutMe__about_m__46E78A0C");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3213E83F66A05F1F");

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
            entity.Property(e => e.ExperienceUserId).HasColumnName("experience_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ExperienceUser).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.ExperienceUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Experienc__exper__5070F446");
        });

        modelBuilder.Entity<FutureProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuturePr__3213E83FC75AF8AB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("project_description");
            entity.Property(e => e.ProjectUserId).HasColumnName("project_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProjectUser).WithMany(p => p.FutureProjects)
                .HasForeignKey(d => d.ProjectUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuturePro__proje__5535A963");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3213E83FCDA86AD4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("project_description");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_name");
            entity.Property(e => e.ProjectUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("project_url");
            entity.Property(e => e.ProjectUserId).HasColumnName("project_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProjectUser).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__projec__3D5E1FD2");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3213E83F44668C71");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SkillDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("skill_description");
            entity.Property(e => e.SkillUserId).HasColumnName("skill_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SkillUser).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skills__skill_us__4BAC3F29");
        });

        modelBuilder.Entity<SocialMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SocialMe__3213E83F285F3B30");

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
            entity.Property(e => e.SocialMediaUserId).HasColumnName("social_media_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SocialMediaUser).WithMany(p => p.SocialMedia)
                .HasForeignKey(d => d.SocialMediaUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SocialMed__socia__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F9218057F");

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
            entity.Property(e => e.UserPictureUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_picture_url");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<DisplayUserInfo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Username)
			.HasMaxLength(50)
			.IsUnicode(false)
			.HasColumnName("username");

            entity.Property(e => e.UserPictureUrl)
			.HasMaxLength(255)
			.IsUnicode(false)
			.HasColumnName("user_picture_url");

            entity.Property(e => e.AboutMeDescription)
			.HasMaxLength(255)
			.IsUnicode(false)
			.HasColumnName("about_me_description");
		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
