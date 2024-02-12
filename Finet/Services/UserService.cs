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
            UserOutput userOutput = new UserOutput();
            try
            {
                userOutput.Users = _userHelper.RegisterHelper(request);
                if (userOutput.Users.statusCode == 200)
                {
                    return new OkObjectResult(userOutput.Users);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new UserOutput
                {
                    Users = new ServerResponse
                    {
                        statusCode = 500,
                        message = "An error occurred while adding user."
                    }
                };
                return new ObjectResult(errorResponse.Users)
                {
                    StatusCode = errorResponse.Users.statusCode
                };
            }


            var specificErrorResponse = new UserOutput
            {
                Users = new ServerResponse
                {
                    statusCode = 400,
                    message = "User add failed due to a specific reason."
                }
            };
            return new ObjectResult(specificErrorResponse.Users)
            {
                StatusCode = specificErrorResponse.Users.statusCode
            };

        }

        [HttpPost]
        [Route("api/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserLogin([FromBody] LoginRequest request)
        {
            
            UserOutput userOutput = new UserOutput();
            userOutput.Users = _userHelper.LoginHelper(request);
            return new OkObjectResult(userOutput.Users);
        }
    }
}
