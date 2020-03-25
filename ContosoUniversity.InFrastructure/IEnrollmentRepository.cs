
using ContosoUniversity.Infrastructure;
using ContosoUniversity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.InFrastructure
{
    public interface IEnrollmentRepository : IAsyncRepository<Enrollment>
    {
        Task<Enrollment> GetEnrollmentDetailsAsync(int id);
        Task<List<Enrollment>> GetEnrollmentAllAsync();
    }
}