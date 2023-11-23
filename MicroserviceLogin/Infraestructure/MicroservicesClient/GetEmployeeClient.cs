using Application.DTO.Response.Microservices;
using Application.Exceptions;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Newtonsoft.Json;

namespace Infraestructure.MicroservicesClient
{
    public class GetEmployeeClient : IGetEmployeeClient
    {

        private readonly IGetMicroserviceClient _getClient;

        public GetEmployeeClient(IGetMicroserviceClient getMicroserviceClient)
        {
            _getClient = getMicroserviceClient;
        }
        public async Task<EmployeeResponse> GetEmployee(int id)
        {
            string url = $"https://localhost:7296/api/Employee/{id}";

            HttpResponseMessage response = await _getClient.Get(url);
            EmployeeResponse employee;

            if(response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    employee = JsonConvert.DeserializeObject<EmployeeResponse>(jsonResponse);
                }
                catch(Exception)
                {
                    throw new UnprocesableContentException("Error en el formate de respuesta del microservico con statusCode " + response.StatusCode);
                }

                if(employee is null)
                    throw new UnprocesableContentException("Id de aprovador con formato invalido en respuesta de microservicio");

                return employee;

            }
            else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException("" +
                    "El empleado no pertenece a ningun departamento"
                );
            }

            string json = await response.Content.ReadAsStringAsync();
            try
            {
                throw new MicroserviceErrorResponseException(
                    url,
                    "Code " + response.StatusCode.ToString() + ": " + json
                );
            }
            catch(Exception)
            {
                throw new UnprocesableContentException("Error en el formate de respuesta del microservico con statusCode " + response.StatusCode);
            }
        }
    }
}
