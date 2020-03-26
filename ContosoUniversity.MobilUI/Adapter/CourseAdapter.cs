using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ContosoUniversity.MobilUI.Service;
using ContosoUniversity.MobilUI.ViewHolders;
using ContosoUniversityMobile.API.Repository;

namespace ContosoUniversity.MobilUI.Adapters
{
    public class CourseAdapter : RecyclerView.Adapter
    {
        private List<Course> _courses;
        public CourseAdapter()
        {
            //var coursesRepository = new CourseRepository();
            //_courses = coursesRepository.GetAllCourses();

           
        }

       public async Task LoadData()
        {

            var service = new CourseService();
            _courses =await  service.GetAllCourses();
        }

        public override int ItemCount => _courses.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CourseViewHolder courseViewHolder)
            {
                courseViewHolder.CourseNameTextView.Text = _courses[position].Title;

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.course_viewholder, parent, false);
            CourseViewHolder courseViewHolder = new CourseViewHolder(itemView);
            return courseViewHolder;


        }


    }
}