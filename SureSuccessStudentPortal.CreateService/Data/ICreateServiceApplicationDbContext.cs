using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.CreateService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.CreateService.Data
{
    public interface ICreateServiceApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChanges();
    }
}
