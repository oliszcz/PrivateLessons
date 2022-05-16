using Microsoft.EntityFrameworkCore;
using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.EF
{
    public class PrivateLessonsContext : DbContext
    {
        public PrivateLessonsContext(DbContextOptions<PrivateLessonsContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeachersSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<User>()
                .HasOne(x => x.Teacher)
                .WithOne(x => x.User)
                .HasForeignKey<Teacher>(x => x.UserId);

            modelBuilder
                .Entity<Teacher>()
                .HasKey(x => x.UserId);

            modelBuilder
                .Entity<Teacher>()
                .HasOne(x => x.User)
                .WithOne(x => x.Teacher);

            modelBuilder
                .Entity<TeacherSubject>()
                .HasKey(x => new { x.UserId, x.SubjectId });

            modelBuilder
                .Entity<Teacher>()
                .HasMany(x => x.TeacherSubjects)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.UserId);

            modelBuilder
                .Entity<Subject>()
                .HasMany(x => x.TeacherSubjects)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
