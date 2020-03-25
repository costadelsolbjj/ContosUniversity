
using ContosoUniversity.Infrastructure;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.InFrastructure
{
    public interface IEnrollmentRepository : IAsyncRepository<Enrollment>
    {
        Task<Enrollment> GetEnrollmentDetailsAsync(int id);
    }
}