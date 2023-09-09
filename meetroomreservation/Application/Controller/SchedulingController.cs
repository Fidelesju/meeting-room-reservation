using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices.Interfaces;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace meetroomreservation.Application.Controller
{
    [ApiController, Route("[controller]")]
    public class SchedulingController : BaseController<SchedulingController>
    {
        #region  Variables
        private readonly ISchedulingService _schedulingService;
        #endregion
        #region Constructor
        public SchedulingController(
            ILogger<SchedulingController> logger, 
            ILoggerService loggerService,
            ISchedulingService schedulingService) : base(logger, loggerService)
        {
            _schedulingService = schedulingService;
        }
        #endregion
        #region Methods
        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<int>>> CreateScheduling (SchedulingCreateRequest request)
        {
            BaseResponse<int> response;
            int id;
            
            try
            {
                id = await _schedulingService.CreateScheduling(request);
                if(id == 0 )
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao criar agendamento")
                        .SetData(0)
                        ;
                    return BadRequest(response);
                }
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Agendamento criado com sucesso!")
                        .SetData(id)
                        ;
                    return Ok(response);
            }
            catch (CustomValidationException exception)
            {
                return ValidationErrorsBadRequest(exception);
            }
            catch (Exception exception)
            {
                return await UntreatedException(exception);
            }
        }
        #endregion
    }
}