using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class DepartmentService
    {
        public DepartmentService()
        {
            ApplicationDbContext Context = new ApplicationDbContext(); // XXXX
        }

        public void UpdateDepartment(int id /*departmentViewModel*/)
        {
            // Get Department from Database By Id
            // call Repository.GetById( id , Context )
        }

    }
}
