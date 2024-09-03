using System.ComponentModel.DataAnnotations;

namespace ContosoUniTARgv23.Models.SkhoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
