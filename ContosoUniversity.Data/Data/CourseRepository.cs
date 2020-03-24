using ContosoUniversity.InFrastructure;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class CourseRepository : EfRepository<Course>, ICourseRepository
    {
        private readonly SchoolContext _dbContext;

        public CourseRepository(SchoolContext dbContext) : base(dbContext)
            {
            _dbContext = dbContext;
            }

        
    }



    }
