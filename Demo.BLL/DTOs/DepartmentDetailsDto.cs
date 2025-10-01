using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs
{
    public class DepartmentDetailsDto
    {
        //public DepartmentDetailsDto(Department dept)
        //{
        //    Id = dept.Id;
        //    Code = dept.Code;
        //    Name = dept.Name;
        //    CreatedBy = dept.CreatedBy;
        //    LastModifiedBy = dept.LastModifiedBy;
        //    IsDeleted = dept.IsDeleted;
        //    DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn);
        //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn);
        //    Description = dept.Description;
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
