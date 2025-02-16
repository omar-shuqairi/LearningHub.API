using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningHub.Core.data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Stdcourse> Stdcourses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("DATA SOURCE=localhost:1521;USER ID=c##omarshuqairi4;PASSWORD=Test321;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##OMARSHUQAIRI4")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CATEGORY_ID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Stdcourse>(entity =>
            {
                entity.ToTable("STDCOURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Dateofregister)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFREGISTER");

                entity.Property(e => e.Markofstd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARKOFSTD");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_COURSE_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_STD_ID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Loginid)
                    .HasName("SYS_C008708");

                entity.ToTable("USER_LOGIN");

                entity.HasIndex(e => e.Username, "SYS_C008709")
                    .IsUnique();

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORDD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ROLE_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_STUDENT_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
