using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    public class MsUserService : ControllerBase
    {
        public MsUserHelper _userHelper;
        private ILogger logger;
     

        public MsUserService(MsUserHelper userHelper, ILogger<MsUserService> logger) : base()
        {
            this._userHelper = userHelper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserRegister([FromBody] RegisterRequestDTO request)
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
        public IActionResult UserLogin([FromBody] LoginRequestDTO request)
        {
            try
            {
                LoginResponseDTO loginResponse = new LoginResponseDTO();
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
