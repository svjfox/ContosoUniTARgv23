using Microsoft.AspNetCore.Mvc;

namespace ContosoUniTARgv23.Models
{
    public class InstructorIndexData 
    {
        public IEnumerable<Instructor> Instructor { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
