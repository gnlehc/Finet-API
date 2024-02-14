namespace Finet.Output
{
    public class BaseOutput
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public BaseOutput()
        {
            StatusCode = 200;
            ErrorMessage = "Success";
        }

        public BaseOutput(Exception ex)
        {
            StatusCode = 500;
            ErrorMessage = ex.Message;
        }
    }
}
