using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalFinal.Models
{
    public class StudentInfo
    {
        [Key]
        public int AdminId { get; set; }
        public string courseName { get; set; }
        public string proffessorName { get; set; }
        public Student student { get; set; }
    }
}
