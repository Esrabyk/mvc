using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YazilimTest.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
