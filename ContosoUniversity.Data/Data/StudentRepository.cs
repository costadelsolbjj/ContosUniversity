using ContosoUniversity.InFrastructure;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {

        public StudentRepository(SchoolContext dbContext) : base(dbContext)
            {
            }

        public Task<Student> GetByIdWithItemsAsync(int id)
        {
            return Context.Students
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> GetStudentDetailsAsync(int id)
        {
            var student = await Context.Students
            .Include(s => s.Enrollments)
           .ThenInclude(e => e.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
            return student;
        }



    }



}
