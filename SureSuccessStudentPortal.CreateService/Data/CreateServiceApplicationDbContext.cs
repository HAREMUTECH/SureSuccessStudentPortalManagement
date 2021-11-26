using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.CreateService.Entities;
using System;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.CreateService.Data
{
    public class CreateServiceApplicationDbContext : DbContext, ICreateServiceApplicationDbContext
    {
        public CreateServiceApplicationDbContext(DbContextOptions<CreateServiceApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
                FirstName = "Abdulhamiid",
                LastName = "Bankole",
                PhoneNo = "08148738864",
                Email = "ade@gmail.com",
                Country = "Nigeria",
                State = "Lagos"
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
                FirstName = "John",
                LastName = "Tosin",
                PhoneNo = "08145789548",
                Email = "ade@gmail.com",
                Country = "Nigeria",
                State = "Osun"
            });


            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
                FirstName = "Live",
                LastName = "Kunle",
                PhoneNo = "08145788541",
                Email = "oyin@yahoo.com",
                Country = "Nigeria",
                State = "Ogun"
            });
        }
    }
}
