using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.InFrastructure;

namespace ContosoUniversity.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentsController(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository =courseRepository;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentAllAsync();
            return View(enrollments);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int id)
        {
          

            var enrollment = await _enrollmentRepository.GetEnrollmentDetailsAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {

            var students =  _studentRepository.GetAll().Result;
            var courses = _courseRepository.GetAll().Result;

            ViewData["CourseID"] = new SelectList(courses, "Id", "Id");
            ViewData["StudentID"] = new SelectList(students, "Id", "Id");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentRepository.Add(enrollment);
                return RedirectToAction(nameof(Index));
            }
            var students = _studentRepository.GetAll().Result;
            var courses = _courseRepository.GetAll().Result;

            ViewData["CourseID"] = new SelectList(courses, "Id", "Id");
            ViewData["StudentID"] = new SelectList(students, "Id", "Id");
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentRepository.GetEnrollmentDetailsAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            var students = _studentRepository.GetAll().Result;
            var courses = _courseRepository.GetAll().Result;

            ViewData["CourseID"] = new SelectList(courses, "Id", "Id");
            ViewData["StudentID"] = new SelectList(students, "Id", "Id");
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _enrollmentRepository.Update(enrollment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var students = _studentRepository.GetAll().Result;
            var courses = _courseRepository.GetAll().Result;

            ViewData["CourseID"] = new SelectList(courses, "Id", "Id");
            ViewData["StudentID"] = new SelectList(students, "Id", "Id");
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var enrollment = await _enrollmentRepository.GetEnrollmentDetailsAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentDetailsAsync(id);
            await _enrollmentRepository.Remove(enrollment);
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
             var enrollment=_enrollmentRepository.GetEnrollmentDetailsAsync(id);
             return enrollment == null ? true : false;
        }
    }
}
