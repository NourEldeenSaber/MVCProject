using AutoMapper;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Interfaces;


namespace Demo.BLL.Services.Classes
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository , IMapper mapper) {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTraking = false)
        {
            var employee = _employeeRepository.GetAll();
            /// var employeesDto = employee.Select(e => new EmployeeDto { 
            ///     Id = e.Id,
            ///     Name = e.Name,
            ///     Age = e.Age,
            ///     Salary = e.Salary,
            ///     Email = e.Email,
            ///     EmployeeType = e.EmployeeType.ToString(),
            ///     Gender = e.Gender.ToString(),
            ///     IsActive = e.IsActive,
            /// });

            //                       Destination         source
            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
            //var employeeDto = _mapper.Map<IEnumerable<Employee> , IEnumerable<EmployeeDto>>(employee);

        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            
            return employee is null ? null : _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false; 
            }
        }
    }
}
