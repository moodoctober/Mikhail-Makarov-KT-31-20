using Makarov_Mikhail_Kt_31_20_Lab1.Database;
using Makarov_Mikhail_Kt_31_20_Lab1.Filters.StudentFilters;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Makarov_Mikhail_Kt_31_20_Lab1.interfaces.StudentInterfaces
{
   
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentFilterService : IStudentService
    {
        private readonly MakarovDbContext _dbContext;

        public StudentFilterService(MakarovDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
           return students;

        }
    }
}
