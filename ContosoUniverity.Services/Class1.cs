using System;

namespace ContosoUniverity.Services
{

    private readonly IStudentService service;
    public class StudentService(IStudentService service)
    {
        service= service;
    }
}
