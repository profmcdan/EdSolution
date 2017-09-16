using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdSolution.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string MatricNumber { get; set; }
        [StringLength(30, ErrorMessage = "Surname canot be longer than 30 characters!")]
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
