using MAC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MAC.Data
{
    public class MacContext : IdentityDbContext
    {
        public MacContext(DbContextOptions<MacContext> options) : base(options) { }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasOne<Student>(d => d.Student)
                .WithOne(sa => sa.Badge)
                .HasForeignKey<Badge>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentId_StudentBadge");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne<Group>(g => g.Group)
                .WithMany(si => si.Students)
                .HasForeignKey(k => k.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupId_Student");
            });

            modelBuilder.Entity<ClassGroup>().HasKey(sc => new { sc.ClassId, sc.GroupId });

            modelBuilder.Entity<ClassGroup>()
            .HasOne<Class>(sc => sc.Class)
            .WithMany(s => s.ClassGroups)
            .HasForeignKey(sc => sc.ClassId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ClassId_ClassGroup");

            modelBuilder.Entity<ClassGroup>()
                .HasOne<Group>(sc => sc.Group)
                .WithMany(s => s.ClassGroups)
                .HasForeignKey(sc => sc.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupId_ClassGroup");
        }
    }
}
