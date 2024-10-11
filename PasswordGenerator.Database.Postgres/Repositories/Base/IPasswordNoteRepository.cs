using PasswordGenerator.Domain.Entities;

namespace PasswordGenerator.Database.Postgres.Repositories.Base {
    public interface IPasswordNoteRepository : ICrudRepository<PasswordNoteEntity> {
        Task<List<PasswordNoteEntity>> GetByUserId(Guid userId);
    }
}
