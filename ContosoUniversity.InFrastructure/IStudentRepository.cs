
using ContosoUniversity.Infrastructure;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.InFrastructure
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<Student> GetStudentDetailsAsync(int id);
    }
}