using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Data
{
	public class StudentContext : DbContext
	{
		public DbSet<Student.Models.Student> Students { get; set; }

		public StudentContext(DbContextOptions<StudentContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Create a unique index on the Email column
			modelBuilder.Entity<Student.Models.Student>()
				.HasIndex(s => s.Email)
				.IsUnique();

		}
	}

}
