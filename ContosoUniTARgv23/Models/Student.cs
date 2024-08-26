using Microsoft.EntityFrameworkCore;

namespace ContosoUniTARgv23.Models
{
    public class Student
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
