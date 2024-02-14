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

        public UserService(UserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpPost]
        [Route("api/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserRegister([FromBody] RegisterRequest request)
        {
            BaseOutput output = new BaseOutput();
            try
            {
                output = _userHelper.RegisterHelper(request);
                if (output.statusCode == 200)
                {
                    return new OkObjectResult(output);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new BaseOutput
                {
                    statusCode = 500,
                    message = ex.Message
                };
                   
                return new ObjectResult(errorResponse)
                {
                    StatusCode = errorResponse.statusCode
                };
            }


            var specificErrorResponse = new BaseOutput
            {
                 statusCode = 400,
                 message = "User add failed due to a specific reason."
                
            };
            return new ObjectResult(specificErrorResponse)
            {
                StatusCode = specificErrorResponse.statusCode
            };

        }

        [HttpPost]
        [Route("api/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserLogin([FromBody] LoginRequest request)
        {
            
            LoginResponse response = _userHelper.LoginHelper(request);
            return new OkObjectResult(response);
        }
    }
}
