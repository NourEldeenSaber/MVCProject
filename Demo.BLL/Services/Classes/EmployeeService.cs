using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Repositories.Interfaces;


namespace Demo.BLL.Services.Classes
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;   
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTraking = false)
        {
            var employee = _employeeRepository.GetAll();
            var employeesDto = employee.Select(e => new EmployeeDto { 
                
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                IsActive = e.IsActive,

            });
            
            return employeesDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee == null) return null;
            var employeeDetailsDto = new EmployeeDetailsDto()
            {
                Id = id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                Gender = employee.Gender.ToString(),
                IsActive = employee.IsActive,
                EmployeeType = employee.EmployeeType.ToString(),
                Address = employee.Address,
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                PhoneNumber = employee.PhoneNumber,
                LastModifiedBy = employee.LastModifiedBy,
                LastModifiedOn = employee.LastModifiedOn,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate)
            };
            
            return employeeDetailsDto;
        }

        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
