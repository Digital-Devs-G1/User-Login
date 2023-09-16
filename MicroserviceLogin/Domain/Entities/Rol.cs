namespace Domain.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<User> Users { get; set; }     
    }
}
