using System.ComponentModel.DataAnnotations;

namespace YazilimTest.Models.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int TeacherId { get; set; }
    }
}
