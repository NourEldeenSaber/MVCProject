
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Repositories
{
    //Primary Constructor .Net 8 Feature
    public class DepartmentRepository(ApplicationDbContext _context) : IDepartmentRepository// High Lever Model
    {


        // == CRUD
        //ApplicationDbContext _context = new ApplicationDbContext(); // Low Level Model
        //readonly ApplicationDbContext _context = context;
        // public DepartmentRepository(ApplicationDbContext context)
        // {//Ask clr to inject Object From ApplicationDbContext
        //     _context = context;
        // }

        // Get Department by Id
        public Department? GetById(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        // Get All Departments
        public IEnumerable<Department> GetAll(bool withTracking = false) 
        {
            if (withTracking) 
                return _context.Departments.ToList();

            return _context.Departments.AsNoTracking().ToList();
        }

        // Add Department
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        // Update Department
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        // Delete Department
        public int Remove(Department department) { 
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        //public DepartmentRepository()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();  // Error
        //}
    }
}
