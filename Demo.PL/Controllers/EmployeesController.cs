using Microsoft.AspNetCore.Mvc;
using Demo.BLL.Services.Interfaces;
namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeesService _employeesService) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeesService.GetAllEmployees();
            return View(employees);
        }
    }
}
