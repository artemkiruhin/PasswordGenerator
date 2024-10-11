using Microsoft.EntityFrameworkCore;
using PasswordGenerator.Database.Postgres.Context;
using PasswordGenerator.Database.Postgres.Repositories.Base;
using PasswordGenerator.Domain.Entities;

namespace PasswordGenerator.Database.Postgres.Repositories {
    public class UserRepository : IUserRepository {

        private readonly PasswordGeneratorDbContext _context;
        public UserRepository(PasswordGeneratorDbContext context) {
            _context = context;
        }

        public async Task<bool> Add(UserEntity entity) {
            _context.Users.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> Delete(Guid id) {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                var result = await _context.SaveChangesAsync();
                return result != 0;
            }
            return false;
        }


        public async Task<List<UserEntity>> GetAll() {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity?> GetById(Guid id) {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserEntity?> GetByUsername(string username) {
            var query = _context.Users.Where(x => x.Username == username);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<UserEntity?> GetByUsernameAndPassword(string username, string passwordHash) {
            var query = _context.Users.Where(x => x.Username == username && x.PasswordHash == passwordHash);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(UserEntity entity) {
            _context.Users.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

    }
}
