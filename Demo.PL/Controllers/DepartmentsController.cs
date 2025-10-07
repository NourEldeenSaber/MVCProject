using Microsoft.AspNetCore.Mvc;
using Demo.BLL.Services;
using Demo.BLL.DTOs;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService , ILogger<HomeController> logger,IWebHostEnvironment _environment) : Controller
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

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.AddDepartment(departmentDto);
                    if(res > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Cannot be added");
                        return View(departmentDto);
                    }
                }
                catch (Exception ex) {
                    // Log Exception
                    if (_environment.IsDevelopment())
                    {
                        //1)Development => log error in Console And Return The Same View with error message 
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(departmentDto);
                    }else
                    {
                        //2)Deployment => log errors In File | Table And Return the same view with error message
                        //logger.LogError(ex.Message);
                        return View(departmentDto);


                    }
                }

            }
            else return View(departmentDto);
        }


        #endregion

        #region Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); //400
            
            var department = _departmentService.GetById(id.Value);
            if (department is null) return NotFound();//404

            return View(department);

        }

        #endregion
    }
}
