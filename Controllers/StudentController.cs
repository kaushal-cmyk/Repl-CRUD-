using Microsoft.AspNetCore.Mvc;
using Student.Data;
using StudentModel = Student.Models.Student;

namespace Student.Controllers
{
	public class StudentController : Controller
	{

		private readonly StudentContext _context;

		public StudentController (StudentContext context)
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
                return RedirectToAction("AllStudent");
            }
			return View(obj);
			
		}

		// Back 
		public IActionResult Back()
		{
			return RedirectToAction("AllStudent");
		}
	}
}	
