using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.UpdateService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.UpdateService.Data
{
    public interface IUpdateServiceApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChanges();
    }
}
