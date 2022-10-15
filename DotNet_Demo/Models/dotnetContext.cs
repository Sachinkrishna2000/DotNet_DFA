using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNet_Demo.Models
{
    public partial class dotnetContext : DbContext
    {
        public dotnetContext()
        {
        }

        public dotnetContext(DbContextOptions<dotnetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainee> Trainees { get; set; } = null!;

        

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ELW5136\\SQLEXPRESS;Database=dotnet;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__Trainees__C456D7293F188D7B");

                entity.Property(e => e.Tid)
                    .ValueGeneratedNever()
                    .HasColumnName("TID");

                entity.Property(e => e.Tage).HasColumnName("TAge");

                entity.Property(e => e.Tname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
