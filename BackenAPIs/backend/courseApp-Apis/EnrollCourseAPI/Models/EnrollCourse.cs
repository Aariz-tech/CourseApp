using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EnrollCourseAPI.Models
{
    public class EnrollCourse
    {  [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public string DocumentUrl { get; set; }


    }
}
