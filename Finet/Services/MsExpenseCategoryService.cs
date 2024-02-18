using Finet.Helpers;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    [ApiController]
    [Route("api/")]
    public class MsExpenseCategoryService : ControllerBase
    {
        public MsExpenseCategoryHelper ECategoryHelper;
        private ILogger logger;


        public MsExpenseCategoryService(MsExpenseCategoryHelper ECategoryHelper, ILogger<MsUserService> logger) : base()
        {
            this.ECategoryHelper = ECategoryHelper;
            this.logger = logger;
        }

        [Authorize]
        [HttpPost]
        [Route("addExpenseCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddECategory([FromBody] MsExpenseCategoryRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = ECategoryHelper.AddECategory(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [Authorize]
        [HttpPost]
        [Route("deactivateExpenseCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeactivateECategory([FromBody] MsExpenseCategoryRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = ECategoryHelper.DeactivateECategory(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [Authorize]
        [HttpPost]
        [Route("removeExpenseCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveECategory([FromBody] MsExpenseCategoryRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = ECategoryHelper.RemoveECategory(req);
                return new OkObjectResult(output);
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error occured: " + ex.ToString());
                return StatusCode(500, new BaseOutput(ex));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getListExpenseCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetListExpenseCategory()
        {
            try
            {
                ListExpenseCategoryOutput output = new ListExpenseCategoryOutput();
                output = ECategoryHelper.GetListExpenseCategory();
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
