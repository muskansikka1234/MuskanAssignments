using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentInquiryAPI.Models;

namespace StudentInquiryAPI.Data
{
    // ✅ Use your custom User with Identity
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ❌ REMOVE DbSet<User> (Identity handles it)

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Seed Roles
            SeedRoles(modelBuilder);

            // 🔹 User ↔ Student (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId);

            // 🔹 Student ↔ Course (Many-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // 🔹 Enquiry
            modelBuilder.Entity<Enquiry>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enquiries)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enquiry>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enquiries)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Admission
            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Admissions)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Admissions)
                .HasForeignKey(a => a.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔥 FIXED: Payment (NO CASCADE CONFLICT)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.NoAction); // ✅ IMPORTANT FIX

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Admission)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.AdmissionID)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = "2"
                },
                new IdentityRole
                {
                    Name = "OfficeStaff",
                    NormalizedName = "OFFICESTAFF",
                    ConcurrencyStamp = "3"
                }
            );
        }
    }
}