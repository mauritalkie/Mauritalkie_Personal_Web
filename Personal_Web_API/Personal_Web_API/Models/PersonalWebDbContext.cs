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

    public virtual DbSet<Project> Projects { get; set; }

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
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3213E83F3DC677DE");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
