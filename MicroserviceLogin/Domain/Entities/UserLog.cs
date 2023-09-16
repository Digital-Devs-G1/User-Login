namespace Domain.Entities
{
    public class UserLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
