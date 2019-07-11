using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Models.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMS.DAL.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext() : base("name=AppConnStr")
        {
        }
        public DbSet<Day> Days { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamScore> ExamScores { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonTeacher> LessonTeachers { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
