using Demo.BLL.DTOs.DepartmentDtos;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeesService _employeesService , IWebHostEnvironment _environment) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            var employees = _employeesService.GetAllEmployees();
            return View(employees);
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _employeesService.AddEmployee(employeeDto);
                    if (res > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Cannot be added");
                        return View(employeeDto);
                    }
                }
                catch (Exception ex)
                {
                    // Log Exception
                    if (_environment.IsDevelopment())
                    {
                        //1)Development => log error in Console And Return The Same View with error message 
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(employeeDto);
                    }
                    else
                    {
                        //2)Deployment => log errors In File | Table And Return the same view with error message
                        return View(employeeDto);


                    }
                }

            }
            else return View(employeeDto);
        }

        #endregion

    }
}
