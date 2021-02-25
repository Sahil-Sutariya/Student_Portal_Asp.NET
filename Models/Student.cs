using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalFinal.Models
{
    public class Student
    {
        // [Key]
        public int StudentId { get; set; } //Primary Key      
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public int studentGrade { get; set; }
        public List<StudentInfo> Students { get; set; }
        public List<Fees> fees { get; set; }
    }
}
