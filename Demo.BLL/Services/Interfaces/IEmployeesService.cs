using Demo.BLL.DTOs.EmployeeDtos;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTraking = false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int AddEmployee(CreatedEmployeeDto employeeDto);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
