using Microsoft.EntityFrameworkCore;
using PasswordGenerator.Database.Postgres.Context;
using PasswordGenerator.Database.Postgres.Repositories.Base;
using PasswordGenerator.Domain.Entities;

namespace PasswordGenerator.Database.Postgres.Repositories {
    public class PasswordNoteRepository : IPasswordNoteRepository {

        private readonly PasswordGeneratorDbContext _context;
        public PasswordNoteRepository(PasswordGeneratorDbContext context) {
            _context = context;
        }

        public async Task<bool> Add(PasswordNoteEntity entity) {
            _context.PasswordNotes.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> Delete(Guid id) {
            var note = await _context.PasswordNotes.FindAsync(id);
            if (note != null)
            {
                _context.PasswordNotes.Remove(note);
                var result = await _context.SaveChangesAsync();
                return result != 0;
            }
            return false;
        }

        public async Task<List<PasswordNoteEntity>> GetAll() {
            return await _context.PasswordNotes.ToListAsync();
        }

        public async Task<PasswordNoteEntity?> GetById(Guid id) {
            return await _context.PasswordNotes.FindAsync(id);
        }

        public Task<List<PasswordNoteEntity>> GetByUserId(Guid userId) {
            return _context.PasswordNotes.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<bool> Update(PasswordNoteEntity entity) {
            _context.PasswordNotes.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }
    }
}
