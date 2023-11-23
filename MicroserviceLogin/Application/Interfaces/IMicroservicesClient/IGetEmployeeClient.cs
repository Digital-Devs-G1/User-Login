using Application.DTO.Response.Microservices;

namespace Application.Interfaces.IMicroservicesClient
{
    public interface IGetEmployeeClient
    {
        public Task<EmployeeResponse> GetEmployee(int id);
    }
}
