using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Domain.Models
{
   public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}
