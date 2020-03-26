using ContosoUniversityMobile.API.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ContosoUniversity.MobilUI.Service
{
    public class CourseService
    {
        public async Task<List<ContosoUniversityMobile.API.Repository.Course>> GetAllCourses()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uri = "http://192.168.1.130:5000/courses";
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var courses = JsonConvert.DeserializeObject<IEnumerable<ContosoUniversityMobile.API.Repository.Course>>(jsonResult);
                    return courses.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = (string)ex.Message + " :: " + ex.InnerException.Message;
                return null;
            }


            

        }

    }
}
