using Demo.BLL.DTOs.DepartmentDtos;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;
using Demo.PL.ViewModels.DepartmentViewModels;
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

        #region Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); //400

            var Employee = _employeesService.GetEmployeeById(id.Value);
            if (Employee is null) return NotFound();//404

            return View(Employee);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeesService.GetEmployeeById(id.Value);

            if (emp is null) return NotFound();
            var dto = new UpdatedEmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Address = emp.Address,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary,
                HiringDate = emp.HiringDate,
                IsActive = emp.IsActive,
                Email = emp.Email,
                EmployeeType = Enum.Parse<EmployeeType>(emp.EmployeeType),
                Gender = Enum.Parse<Gender>(emp.Gender),

            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdatedEmployeeDto dto)
        {
            if(id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);
            try
            {
                
                var res = _employeesService.UpdateEmployee(dto);
                if (res > 0) return RedirectToAction(nameof(Index));
                return View(dto);
            }
            catch (Exception ex)
            {
                // Log Exception
                if (_environment.IsDevelopment())
                {
                    //1)Development => log error in Console And Return The Same View with error message 
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(dto);
                }
                else
                {
                    //2)Deployment => log errors In File | Table And Return the same view with error message
                    //logger.LogError(ex.Message);
                    return View(dto);
                }
            }
        }


        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = _employeesService.DeleteEmployee(id);

                if (isDeleted) return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "Employee cannot be deleted");

                return RedirectToAction(nameof(Delete), new { id });

            }
            catch (Exception ex)
            {
                // Log Exception
                if (_environment.IsDevelopment())
                {
                    //1)Development => log error in Console And Return The Same View with error message 
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //2)Deployment => log errors In File | Table And Return the same view with error message
                    //logger.LogError(ex.Message);
                    return View("ErrorView");
                }
            }
        }


        #endregion
    }
}
