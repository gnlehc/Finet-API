using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    public class MsAccountService : ControllerBase
    {
        public MsAccountHelper accountHelper;
        private ILogger logger;


        public MsAccountService(MsAccountHelper accountHelper, ILogger<MsUserService> logger) : base()
        {
            this.accountHelper = accountHelper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/addAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddAccount([FromBody] MsAccountRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = accountHelper.AddAccount(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }
    }
}
