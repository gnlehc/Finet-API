using Finet.Helpers;
using Finet.HttpModels.Requests;
using Finet.HttpModels.Responses;
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
            ServerResponse response = new ServerResponse();

            try
            {
                response = _userHelper.RegisterHelper(request);
                if (response.statusCode == 200)
                {
                    return new OkObjectResult(response);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new ServerResponse
                {
                    statusCode = 500,
                    message = "An error occurred while adding user."
                };
               
                return new ObjectResult(errorResponse)
                {
                    StatusCode = errorResponse.statusCode
                };
            }


            var specificErrorResponse = new ServerResponse
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
            LoginResponse response = new LoginResponse();
            response = _userHelper.LoginHelper(request);
            return new OkObjectResult(response);
        }
    }
}
