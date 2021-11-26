using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.DeleteService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.DeleteService.Data
{
    public interface IDeleteServiceApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChanges();
    }
}
