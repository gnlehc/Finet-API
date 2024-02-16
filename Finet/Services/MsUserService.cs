using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Finet.Services
{
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
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                return Ok(new { Token = token, Data = loginResponse });
                //return new OkObjectResult(loginResponse);


            }
            catch(Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }
    }
}
