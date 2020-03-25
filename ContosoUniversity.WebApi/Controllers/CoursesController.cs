using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Infrastructure;
using ContosoUniversity.Models;
using ContosoUniversity.InFrastructure;

namespace ContosoUniversity.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            var courses= await _courseRepository.GetAll();
            return courses;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseRepository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }


            try
            {
               await  _courseRepository.Update(course);
            }
            catch (Exception e)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            try
            {
                await _courseRepository.Add(course);
            }
            catch (Exception ex)
            {
                if (CourseExists(course.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseRepository.Remove(course);

            return course;
        }

        private bool CourseExists(int id)
        {
            var course = _courseRepository.GetById(id);
            return course == null ? true : false;
        }
    }
}
