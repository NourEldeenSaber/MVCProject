using System.ComponentModel.DataAnnotations;


namespace Demo.BLL.DTOs.DepartmentDtos
{
    public class CreatedDepartmentDto
    {
        [MaxLength(10)]
        public string Name { get; set; }
        public string Code { get; set; }
        [Display(Name ="Creation Date")]
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }

    }
}
