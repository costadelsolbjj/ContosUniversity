using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ContosoUniversity.MobilUI.ViewHolders
{
    public class CourseViewHolder : RecyclerView.ViewHolder
    {
        public TextView CourseNameTextView { get; set; }

        public CourseViewHolder(View itemView) : base(itemView)
        {
            CourseNameTextView = itemView.FindViewById<TextView>(Resource.Id.courseNameTextView);


        }
    }
}