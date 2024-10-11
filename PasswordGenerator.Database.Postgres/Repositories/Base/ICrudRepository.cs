namespace PasswordGenerator.Database.Postgres.Repositories.Base {
    public interface ICrudRepository<T> {
        Task<List<T>> GetAll();
        Task<List<T>> GetById(Guid id);
        Task<bool> Add(T entity);
        Task Delete(Guid id);
        Task<bool> Update(T entity);
    }
}
