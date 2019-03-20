using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreelenceProjectDemo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CoordinatorTrainingCourse> CoordinatorTrainingCourses { get; set; }
        public DbSet<CoordinatorTrainingCourseDetail> CoordinatorTrainingCourseDetails { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}