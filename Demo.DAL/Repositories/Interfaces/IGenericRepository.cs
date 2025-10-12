using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;


namespace Demo.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity? GetById(int id);
        public IEnumerable<TEntity> GetAll(bool withTracking = false);
        public int Add(TEntity entity);
        public int Update(TEntity entity);
        public int Remove(TEntity entity);
    }
}
