using System.ComponentModel.DataAnnotations;

namespace YazilimTest.Models.Entities
{
    public class Teacher
    {
        [Key]

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int StudentId { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
