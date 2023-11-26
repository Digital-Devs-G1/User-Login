namespace Application.DTOs.Users
{
    public class RegisterUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public bool IsApprover { get; set; }
        public int? SuperiorId { get; set; }
    }
}