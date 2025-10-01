using Microsoft.AspNetCore.Mvc;
using Demo.BLL.Services;
namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService) : Controller
    {
        // DepartmentService departmentService used Across All Actions
        // EmployeeService --> Assign Manager : this Service Needed Only For One Action
        //public DepartmentController(DepartmentService departmentService) // Call Service Department 
        //{
        //} // Ask Clr To Create Object from [DepartmentService]


        // BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments); 
        }
    }
}
