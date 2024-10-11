namespace PasswordGenerator.Domain.Entities {
    public class PasswordNoteEntity {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public UserEntity User { get; set; } = new UserEntity();
    }
}
