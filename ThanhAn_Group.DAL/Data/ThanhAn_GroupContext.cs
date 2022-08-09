using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;
using ThanhAn_Group.DAL.Models;

#nullable disable

namespace ThanhAn_Group.DAL.Data
{
    public partial class ThanhAn_GroupContext : DbContext
    {
        DbContextOptions<ThanhAn_GroupContext> options;
        public ThanhAn_GroupContext()
        {
        }

        public ThanhAn_GroupContext(DbContextOptions<ThanhAn_GroupContext> options)
            : base(options)
        {
            this.options = options;
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Baiviet> Baiviets { get; set; }
        public virtual DbSet<DoiTac> DoiTacs { get; set; }
        public virtual DbSet<GalleriesImage> GalleriesImages { get; set; }
        public virtual DbSet<GalleriesVideo> GalleriesVideos { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=112.78.2.32;database=tha37423_tag;uid=tha37423_sa;pwd=00sq$J1o;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Baiviet>(entity =>
            {
                entity.HasKey(e => e.PkbaivietId)
                    .HasName("PK__Baiviet__6A6BB8E08B073F22");

                entity.ToTable("Baiviet");

                entity.Property(e => e.PkbaivietId).HasColumnName("PKBaiviet_Id");

                entity.Property(e => e.Contents).IsRequired();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Images).IsRequired();

                entity.Property(e => e.ShortContent)
                    .IsRequired()
                    .HasMaxLength(525);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(225);
            });

            modelBuilder.Entity<DoiTac>(entity =>
            {
                entity.ToTable("Doi_Tac");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdressDoiTac)
                    .HasMaxLength(255)
                    .HasColumnName("Adress_DoiTac");

                entity.Property(e => e.Mst)
                    .HasMaxLength(255)
                    .HasColumnName("MST");

                entity.Property(e => e.NameDoiTac)
                    .HasMaxLength(255)
                    .HasColumnName("Name_DoiTac");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tel).HasMaxLength(255);
            });

            modelBuilder.Entity<GalleriesImage>(entity =>
            {
                entity.ToTable("GalleriesImage");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(125);
            });

            modelBuilder.Entity<GalleriesVideo>(entity =>
            {
                entity.ToTable("GalleriesVideo");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(125);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.SlideId).HasColumnName("Slide_Id");

                entity.Property(e => e.DisplayOrder).HasColumnName("Display_Order");

                entity.Property(e => e.SlideName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
