using Demo.BLL.DTOs;
using Demo.DAL.Models.DepartmentModel;
using System.Runtime.CompilerServices;

namespace Demo.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto() { 
                DeptId = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description ,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department dept)
        {
            return new DepartmentDetailsDto()
            {
                Id = dept.Id,
                Code = dept.Code,
                Name = dept.Name,
                CreatedBy = dept.CreatedBy,
                LastModifiedBy = dept.LastModifiedBy,
                IsDeleted = dept.IsDeleted,
                DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
                Description = dept.Description,
            };
        }    
        public static Department ToEntity (this CreatedDepartmentDto departmentDto)
        {
            return new Department() { 
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description,
            };
        }
        public static Department ToEntity(this UpdateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description,
            };
        }
    }
}
