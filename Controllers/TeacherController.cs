using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YazilimTest.Models;
using YazilimTest.Models.Context;
using YazilimTest.Models.Entities;

namespace YazilimTest.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DbContexts _context;

        public TeacherController(DbContexts context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
    
            var orderViewModel = from Teacher in _context.Teachers
                                   join student in _context.Students on Teacher.StudentId equals student.StudentId
                                 join product in _context.Lessons on Teacher.TeacherId equals product.TeacherId
                                 select new TeachersViewModel { teacher = Teacher, student = student, lesson = Lesson };
            return View(orderViewModel);
      
        }
        public IActionResult Create()
        {
      
            ViewBag.Customers = _context.Students.Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.StudentName }).ToList();
            return View();

        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        
            ViewBag.Students = _context.Students.Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.StudentName }).ToList();
            return View();

        }
        public IActionResult Detail(int teacherId)
        {
            // 
            var orderViewModel = from teacher in _context.Teachers
                                 join Student in _context.Students on teacher.StudentId equals Student.StudentId into st1
                                 from Student in st1.DefaultIfEmpty()
                                 join lesson in _context.Lessons on teacher.TeacherId equals lesson.TeacherId into st2
                                 from Lesson in st2.DefaultIfEmpty()
                                 where teacher.TeacherId == teacherId
                                 select new TeachersViewModel { teacher = teacher, student = Student, lesson = Lesson };
            return View(orderViewModel);
        }
        public IActionResult Delete(int teacherId)
        {
            var teacher = _context.Teachers.Find(teacherId);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int teacherId)
        {
            ViewBag.Students = _context.Students.Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.StudentName }).ToList();
            var teacher = _context.Teachers.Find(teacherId);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

    }
}
