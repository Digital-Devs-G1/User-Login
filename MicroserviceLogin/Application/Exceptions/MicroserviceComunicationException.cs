namespace Application.Exceptions
{
    public class MicroserviceComunicationException : Exception
    {
        private static readonly string description = 
            "No fue posible la comunicacion entre microservicios. ";
        public MicroserviceComunicationException()
        : base(description)
        { }

        public MicroserviceComunicationException(string message)
            : base(description + message)
        { }
    }
}
