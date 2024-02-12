using Finet.Model.Responses;

namespace Finet.Output
{
    public class UserOutput
    {
            public ServerResponse Users { get; set; }
            public UserOutput()
            {
                this.Users = new ServerResponse();
            }
    }
}
