using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    public class MsCategoryService : ControllerBase
    {
        public MsCategoryHelper categoryHelper;
        private ILogger logger;


        public MsCategoryService(MsCategoryHelper categoryHelper, ILogger<MsUserService> logger) : base()
        {
            this.categoryHelper = categoryHelper;
            this.logger = logger;
        }
        [HttpPost]
        [Route("api/addCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddCategory([FromBody] MsCategoryRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = categoryHelper.AddCategory(req);
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
