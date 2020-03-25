
using ContosoUniversity.Infrastructure;
using ContosoUniversity.Models;

namespace ContosoUniversity.InFrastructure
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
    }
}