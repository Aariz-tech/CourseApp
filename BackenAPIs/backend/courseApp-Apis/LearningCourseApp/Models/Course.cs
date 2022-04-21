using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningCourseApp.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CoursePrice { get; set; }
        public string CourseDescription { get; set; }
        public bool IsAvailable { get; set; } 
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public string DocumentUrl { get; set; }
        


    }
}
