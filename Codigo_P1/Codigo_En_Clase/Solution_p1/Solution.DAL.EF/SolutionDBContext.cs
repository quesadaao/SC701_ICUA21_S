using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DAL.EF
{
    public partial class SolutionDBContext: DbContext
    {

        public SolutionDBContext(DbContextOptions<SolutionDBContext> options): base(options)
        {
        }

        public DbSet<Foci> Foci { get; set; }
        public DbSet<GroupRequests> GroupRequests { get; set; }
        public DbSet<GroupInvitations> GroupInvitations { get; set; }
        public DbSet<Groups> Groups { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=SCIIV2;Database=SocialGoal;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Foci>(entity =>
            {
                entity.HasKey(e => e.FocusId)
                    .HasName("PK_dbo.Foci");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FocusName).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Foci)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Foci_dbo.Groups_GroupId");
            });


            modelBuilder.Entity<GroupInvitations>(entity =>
            {
                entity.HasKey(e => e.GroupInvitationId)
                    .HasName("PK_dbo.GroupInvitations");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupInvitations)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupInvitations_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<GroupRequests>(entity =>
            {
                entity.HasKey(e => e.GroupRequestId)
                    .HasName("PK_dbo.GroupRequests");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.Groups_GroupId");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.GroupRequests)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_dbo.GroupRequests_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK_dbo.Groups");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
