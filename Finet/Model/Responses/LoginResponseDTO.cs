namespace Finet.Model.Responses
{
    public class LoginResponseDTO
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public Guid UserID { get; set; }
        public string? Username { get; set; }
    }
}
