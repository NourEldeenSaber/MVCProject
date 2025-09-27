using Microsoft.AspNetCore.Mvc;
using Demo.BLL;
namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        // DepartmentService departmentService used Across All Actions
        // EmployeeService --> Assign Manager : this Service Needed Only For One Action
        public DepartmentController(DepartmentService departmentService) // Call Service Department 
        {
        } // Ask Clr To Create Object from [DepartmentService]
    }
}
