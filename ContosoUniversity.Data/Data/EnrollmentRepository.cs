using ContosoUniversity.InFrastructure;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class EnrollmentRepository : EfRepository<Enrollment>, IEnrollmentRepository
    {

        public EnrollmentRepository(SchoolContext dbContext) : base(dbContext)
            {
            }

        public Task<Enrollment> GetByIdWithItemsAsync(int id)
        {
            return Context.Enrollments
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Enrollment> GetEnrollmentDetailsAsync(int id)
        {
            var enrollment = await Context.Enrollments
            .Include(s => s.Course)
           .Include(e => e.Student)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
            return enrollment;
        }


        public async Task<List<Enrollment>> GetEnrollmentAllAsync()
        {
            var enrollments = await Context.Enrollments
            .Include(s => s.Course)
           .Include(e => e.Student)
            .AsNoTracking()
            .ToListAsync();
            return enrollments;
        }


    }



}
