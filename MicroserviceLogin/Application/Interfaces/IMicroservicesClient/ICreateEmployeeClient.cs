using Application.DTO.Request;

namespace Application.Interfaces.IMicroservicesClient
{
    public interface ICreateEmployeeClient
    {
        public Task CreateEmployee(EmployeeRequest request);
    }
}
