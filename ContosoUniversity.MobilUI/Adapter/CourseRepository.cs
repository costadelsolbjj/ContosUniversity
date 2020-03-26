using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContosoUniversityMobile.API.Repository;

namespace ContosoUniversity.MobilUI
{
    public class CourseRepository
    {

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>()
        {
            new Course { Id = 1, Title = "Apple Pie"},
            new Course { Id = 2, Title = "Blueberry Cheese Cake"},
            new Course { Id = 3, Title = "Cheese Cake"},
            new Course { Id = 4, Title = "Cherry Pie"},
            new Course { Id = 5, Title = "Christmas Apple Pie"}
        };
            return courses;
        }
    }
}