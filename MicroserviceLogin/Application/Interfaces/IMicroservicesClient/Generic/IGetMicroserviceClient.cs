namespace Application.Interfaces.IMicroservices.Generic
{
    public interface IGetMicroserviceClient
    {
        public Task<HttpResponseMessage> Get(string url);
    }
}
