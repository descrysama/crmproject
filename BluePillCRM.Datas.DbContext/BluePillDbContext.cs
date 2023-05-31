using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Datas.BluePillDbContext;

public partial class BluePillDbContext : DbContext
{
    public BluePillDbContext()
    {
    }

    public BluePillDbContext(DbContextOptions<BluePillDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=bluepillcrm;Port=3306;User Id=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(256)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(256)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
