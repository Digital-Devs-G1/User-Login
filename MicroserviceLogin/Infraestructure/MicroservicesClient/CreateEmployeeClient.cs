
using Application.DTO.Request;
using Application.DTO.Response.Microservices;
using Application.Exceptions;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.MicroservicesClient
{
    public class CreateEmployeeClient : ICreateEmployeeClient
    {
        private readonly IPostMicroserviceClient _postClient;

        public CreateEmployeeClient(IPostMicroserviceClient postClient)
        {
            _postClient = postClient;
        }

        public async Task CreateEmployee(EmployeeRequest request)
        {
            string url = "https://localhost:7296/api/v1/Employee";
            string json = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = await _postClient.Post(url, json);

            if (!response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                try
                {
                    throw new MicroserviceErrorResponseException(
                        url,
                        "Code " + response.StatusCode.ToString() + ": " + json
                    );
                }
                catch (Exception)
                {
                    throw new UnprocesableContentException("Error en el formate de respuesta del microservico con statusCode " + response.StatusCode);
                }
            }
        }
    }
}
