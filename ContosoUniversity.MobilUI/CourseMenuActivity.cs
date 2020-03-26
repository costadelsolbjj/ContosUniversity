using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ContosoUniversity.MobilUI.Adapters;

namespace ContosoUniversity.MobilUI
{
    [Activity(Label = "CourseMenuActivity", MainLauncher = true)]
    public class CourseMenuActivity : Activity
    {
        private RecyclerView _courseRecyclerView;
        private RecyclerView.LayoutManager _courseLayoutManager;
        private CourseAdapter _courseAdapter;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.course_menu);
            _courseRecyclerView = FindViewById<RecyclerView>(Resource.Id.courseMenurecyclerView);

            _courseLayoutManager = new LinearLayoutManager(this);
            _courseRecyclerView.SetLayoutManager(_courseLayoutManager);

            _courseAdapter = new CourseAdapter();
            await _courseAdapter.LoadData();
            _courseRecyclerView.SetAdapter(_courseAdapter);

            // Create your application here
        }

        
    }
}