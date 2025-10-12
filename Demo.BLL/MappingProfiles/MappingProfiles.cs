using AutoMapper;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<EmployeeDto, Employee>(); // from employeeDto to employee

            CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.EmpGender, option => option.MapFrom(s => s.Gender))
                .ForMember(d => d.EmpType, option => option.MapFrom(s => s.EmployeeType))
                .ReverseMap(); // from employee to employeeDto

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender))
                .ForMember(d => d.EmployeeType, o => o.MapFrom(s => s.EmployeeType))
                .ForMember(d => d.HiringDate, o => o.MapFrom(s => DateOnly.FromDateTime(s.HiringDate)))
                .ReverseMap();

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(d => d.HiringDate, o => o.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())))
                .ReverseMap();
            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(d => d.HiringDate, o => o.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())))
                .ReverseMap();
        }
    }
}
