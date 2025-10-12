using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Interfaces;

namespace Demo.DAL.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext _dbContext) 
                : GenericRepository<Employee>(_dbContext),IEmployeeRepository
    {
            
    }
}
