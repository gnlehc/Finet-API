﻿using Finet.Helpers;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finet.Services
{
    [ApiController]
    [Route("api/")]
    public class TrExpenseService : ControllerBase
    {
        public TrExpenseHelper trExpenseHelper;
        private ILogger logger;
        public TrExpenseService(TrExpenseHelper trExpenseHelper, ILogger<MsUserService> logger) : base()
        {
            this.trExpenseHelper = trExpenseHelper;
            this.logger = logger;
        }

        [Authorize]
        [HttpPost]
        [Route("addExpense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddExpense([FromBody] TrExpenseRequestDTO req)
        {
            try
            {
                BaseOutput output = new BaseOutput();
                output = trExpenseHelper.AddExpense(req);
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
