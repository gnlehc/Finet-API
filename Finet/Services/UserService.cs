using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    public class UserService : ControllerBase
    {
        public UserHelper _userHelper;
        private ILogger logger;
     

        public UserService(UserHelper userHelper, ILogger<UserService> logger) : base()
        {
            this._userHelper = userHelper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserRegister([FromBody] RegisterRequest request)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = _userHelper.RegisterHelper(request);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [HttpPost]
        [Route("api/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserLogin([FromBody] LoginRequest request)
        {
            try
            {
                LoginResponse loginResponse = new LoginResponse();
                loginResponse = _userHelper.LoginHelper(request);
                return new OkObjectResult(loginResponse);
            }
            catch(Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }
    }
}
