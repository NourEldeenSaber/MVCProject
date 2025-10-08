using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs.DepartmentDtos
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
        [Display(Name = "Date Of Creation")]
        public DateOnly DateOfCreation { get; set; }
        [Display(Name = "Last Modified On")]
        public DateOnly LastModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
