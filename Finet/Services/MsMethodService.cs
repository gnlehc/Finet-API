using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    public class MsMethodService : ControllerBase
    {
        public MsMethodHelper methodHelper;
        private ILogger logger;


        public MsMethodService(MsMethodHelper methodHelper, ILogger<MsUserService> logger) : base()
        {
            this.methodHelper = methodHelper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/addMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddMethod([FromBody] MsMethodRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = methodHelper.AddMethod(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [HttpPost]
        [Route("api/deactivateMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeactivateMethod([FromBody] MsMethodRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = methodHelper.DeactivateMethod(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [HttpPost]
        [Route("api/removeMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveMethod([FromBody] MsMethodRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = methodHelper.RemoveMethod(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [HttpGet]
        [Route("api/getListMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetListMethod()
        {
            try
            {
                ListMethodOutput output = new ListMethodOutput();
                output = methodHelper.GetListMethod();
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
