namespace DataAccess.Repository.Common
{
    public interface IBaseRepository<T> where T : class
    {
        public Task Create(T entity);

        public void Delete(T entity);

        public void Update(T entity);

        public Task<bool> SaveChange();
    }
}