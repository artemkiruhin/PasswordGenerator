using PasswordGenerator.Domain.Entities;

namespace PasswordGenerator.Database.Postgres.Repositories.Base {
    public interface IUserRepository : ICrudRepository<UserEntity> {
        Task<UserEntity?> GetByUsername(string username);
        Task<UserEntity?> GetByUsernameAndPassword(string username, string password);
    }
}
