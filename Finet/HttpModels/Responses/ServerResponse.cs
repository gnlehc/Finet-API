namespace Finet.HttpModels.Responses
{
    public class ServerResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public bool? success { get; set; }
    }
}
