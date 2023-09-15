namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }

        public IEnumerable<UserLog> userLogs { get; set; }
    }
}
