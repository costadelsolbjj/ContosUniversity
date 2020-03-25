using ContosoUniversity.InFrastructure;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class CourseRepository : EfRepository<Course>, ICourseRepository
    {

        public CourseRepository(SchoolContext dbContext) : base(dbContext)
            {
            }

        
    }



    }
