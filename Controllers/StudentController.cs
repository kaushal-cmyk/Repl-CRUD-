using Microsoft.AspNetCore.Mvc;
using Student.Data;
using StudentModel = Student.Models.Student;

namespace Student.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }
        // Show student data.
        [HttpGet]
        public IActionResult AllStudent()
        {
            IEnumerable<StudentModel> studentList = _context.Students;
            return View(studentList);
        }

        // Create Student
        public IActionResult Create()
        {
            return View("CreateStudent");
        }

        [HttpPost]
        public IActionResult Create(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(obj);
                _context.SaveChanges();
                TempData["Success"] = "Data Created Successfully !";
                return RedirectToAction("AllStudent");
            }
            return View(obj);

        }

        //Edit students data.
        [HttpGet]
        public IActionResult EditStudent(Guid Id)
        {
            var student = _context.Students.Find(Id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(StudentModel obj)
        {

            // Retrieve the student from the database
            var studentToUpdate = _context.Students.Find(obj.Id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }

            // Update the student properties
            studentToUpdate.Name = obj.Name;
            studentToUpdate.Email = obj.Email;
            studentToUpdate.DateOfBirth = obj.DateOfBirth;
            studentToUpdate.Department = obj.Department;
            studentToUpdate.Address = obj.Address;
            studentToUpdate.Gender = obj.Gender;
            _context.SaveChanges();
            TempData["Success"] = "Data Updated Successfully !";
            return RedirectToAction("AllStudent");
        }

        // delete student
        [HttpGet]
        public IActionResult DeleteStudent(Guid Id)
        {
            var student = _context.Students.Find(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(StudentModel obj)
        { 
            var student = _context.Students.Find(obj.Id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            TempData["Success"] = "Data Deleted Successfully !";
            return RedirectToAction("AllStudent");
        }

        // Back to student list.
        public IActionResult Back()
        {
            return RedirectToAction("AllStudent");
        }
    }
}
