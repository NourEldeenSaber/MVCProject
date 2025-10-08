using Demo.BLL.Factories;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Repositories.Interfaces;
using Demo.BLL.DTOs.DepartmentDtos;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        //Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Depts = _departmentRepository.GetAll(false);

            /// var DepartmentsReturn = Depts.Select(D => new DepartmentDto()
            /// {
            ///     DeptId = D.Id,
            ///     Name = D.Name,
            ///     Code = D.Code,
            ///     Description = D.Description,
            ///     DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            /// });

            var DepartmentsReturn = Depts.Select(D => D.ToDepartmentDto());//ExtentionMapping

            return DepartmentsReturn;
        }

        //Get Dept By Id
        public DepartmentDetailsDto? GetById(int id)
        {
            var dept = _departmentRepository.GetById(id);

            /// if(dept is null) 
            ///     return null;
            /// else
            /// {
            ///     var deptToReturn = new DepartmentDetailsDto()
            ///     {
            ///         Id = dept.Id,
            ///         Code = dept.Code,
            ///         Name = dept.Name,
            ///         CreatedBy = dept.CreatedBy,
            ///         LastModifiedBy = dept.LastModifiedBy,
            ///         IsDeleted = dept.IsDeleted,
            ///         DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            ///         LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
            ///         Description = dept.Description,
            ///     };
            ///     return deptToReturn;
            /// }

            //== Manaual Mapping
            //  -Constructor Mapping
            //  -Extention method

            /// return dept == null ? null : new DepartmentDetailsDto()
            /// {
            ///     Id = dept.Id,
            ///     Code = dept.Code,
            ///     Name = dept.Name,
            ///     CreatedBy = dept.CreatedBy,
            ///     LastModifiedBy = dept.LastModifiedBy,
            ///     IsDeleted = dept.IsDeleted,
            ///     DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            ///     LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
            ///     Description = dept.Description,
            /// };


            //return dept == null ? null : new DepartmentDetailsDto(dept);//ConstructorMapping
            return dept == null ? null : dept.ToDepartmentDetailsDto();//ExtentionMapping
        }

        // Add Department
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var Entity = departmentDto.ToEntity();
            return _departmentRepository.Add(Entity);
        }

        // Update Department
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var Entity = departmentDto.ToEntity();
            return _departmentRepository.Add(Entity);
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var dept = _departmentRepository.GetById(id);

            if (dept == null)
                return false;
            else
            {
                var res = _departmentRepository.Remove(dept);

                return res > 0 ? true : false;
            }
        }
    }
}
