namespace Application.Interfaces.IMicroservices.Generic
{
    public interface IPostMicroserviceClient
    {
        public Task<HttpResponseMessage> Post(string url, string body);
    }
}
