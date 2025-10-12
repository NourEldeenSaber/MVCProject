using Microsoft.AspNetCore.Mvc;
using Demo.PL.ViewModels.DepartmentViewModels;
using Demo.BLL.Services.Interfaces;
using Demo.BLL.DTOs.DepartmentDtos;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService , ILogger<HomeController> _logger,IWebHostEnvironment _environment) : Controller
    {
        // DepartmentService departmentService used Across All Actions
        // EmployeeService --> Assign Manager : this Service Needed Only For One Action
        //public DepartmentController(DepartmentService departmentService) // Call Service Department 
        //{
        //} // Ask Clr To Create Object from [DepartmentService]

        #region Index

        // BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        } 

        #endregion

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

        #region Edit

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();

        //    var department = _departmentService.GetById(id.Value); // DepartmentDetailsDto                                                                   
        //    if(department is null) return NotFound();

        //    var deptViewModel = new DepartmentEditViewModel()
        //    {
        //        Id = id.Value,
        //        Name = department.Name,
        //        Code = department.Code,
        //        DateOfCreation = department.DateOfCreation,
        //        Description = department.Description
        //    }; 

        //    return View(deptViewModel); 
        //}

        [HttpPost]
        public IActionResult Edit([FromRoute] int id , DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updateDeptDto = new UpdateDepartmentDto() { 
                    Id = id,
                    Name = viewModel.Name,
                    Code = viewModel.Code,
                    DateOfCreation = viewModel.DateOfCreation,
                    Description = viewModel.Description
                };
               var res = _departmentService.UpdateDepartment(updateDeptDto);
                if (res > 0) return RedirectToAction(nameof(Index));
                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Log Exception
                if (_environment.IsDevelopment())
                {
                    //1)Development => log error in Console And Return The Same View with error message 
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
                else
                {
                    //2)Deployment => log errors In File | Table And Return the same view with error message
                    //logger.LogError(ex.Message);
                    return View(viewModel);


                }
            }
        
        }

        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var dept = _departmentService.GetById(id.Value);
            if (dept is null) return NotFound();

            return View(dept);
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id == 0 ) return BadRequest();
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);

                if (isDeleted) return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "Department cannot be deleted");
                
                return RedirectToAction(nameof(Delete),new { id });

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
