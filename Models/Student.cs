using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
	public class Student
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Department { get; set; }
	}
}
