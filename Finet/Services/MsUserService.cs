using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finet.Services
{
    [ApiController]
    [Route("api/")]
    public class MsUserService : ControllerBase
    {
        public MsUserHelper _userHelper;
        private ILogger logger;
        private IConfiguration _config;
        public MsUserService(MsUserHelper userHelper, ILogger<MsUserService> logger, IConfiguration config) : base()
        {
            this._userHelper = userHelper;
            this.logger = logger;
            this._config = config;
        }

        [HttpPost]
        [Route("register")]
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
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserLogin([FromBody] LoginRequestDTO request)
        {
            try
            {
                IActionResult response = Unauthorized();
                LoginResponseDTO loginResponse = _userHelper.LoginHelper(request);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("userID", loginResponse.UserID.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = credentials,
                    Audience = _config["Jwt:Audience"], 
                    Issuer = _config["Jwt:Issuer"]
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString, Data = loginResponse });
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occurred: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }
    }
}
