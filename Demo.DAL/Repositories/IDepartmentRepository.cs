using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        public Department? GetById(int id);
        public IEnumerable<Department> GetAll(bool withTracking = false);
        public int Add(Department department);
        public int Update(Department department);
        public int Remove(Department department);

    }
}
