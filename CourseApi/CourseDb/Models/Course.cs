﻿using Microsoft.VisualBasic;

namespace CourseDb.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public DateTime StartDate { get; set; }
        
    }
}
    