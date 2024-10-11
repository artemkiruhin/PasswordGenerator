namespace PasswordGenerator.Domain.Entities {
    public class UserEntity {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public List<PasswordNoteEntity> PasswordNotes { get; set; } = new List<PasswordNoteEntity>();
    }
}
