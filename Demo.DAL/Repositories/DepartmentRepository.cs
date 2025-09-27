
using Demo.DAL.Data.Contexts;

namespace Demo.DAL.Repositories
{
    //Primary Constructor .Net 8 Feature
    internal class DepartmentRepository(ApplicationDbContext context) // High Lever Model
    {


        // == CRUD
        //ApplicationDbContext _context = new ApplicationDbContext(); // Low Level Model
        readonly ApplicationDbContext _context = context;
        // public DepartmentRepository(ApplicationDbContext context)
        // {//Ask clr to inject Object From ApplicationDbContext
        //     _context = context;
        // }
        // Get Department by Id
        public Department? GetById(int id )
        {
            var department = _context.Departments.Find(id);
            return department;
        }
        // Get All Departments
        // Add Department
        // Update Department
        // Delete Department

        public DepartmentRepository()
        {
            ApplicationDbContext context = new ApplicationDbContext();  // Error
        }
    }
}
