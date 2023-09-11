using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices.Interfaces;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.Models;
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
        /// <summary>
        /// Criando agendamento 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Alteração de agendamentos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>e
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse<bool>>> UpdateScheduling (SchedulingUpdateRequestModel request)
        {
            BaseResponse<bool> response;
            bool success;

            try
            {
                success = await _schedulingService.UpdateScheduling(request);
                if(!success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Falha ao atualizar agendamento")
                        .SetData(false)
                        ;
                    return BadRequest(response);
                }
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Agendamento atualizado com sucesso!")
                        .SetData(success)
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
        
        /// <summary>
        /// Buscando agendamentos por user Id (Paginado)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        [HttpGet("Page/{page}/PerPage{perPage}/userId")]
        public async Task<ActionResult<BaseResponse<PaginatedList<SchedulingResponseModel>>>> GetPaginatedListSchedulingByUserId (int userId, int page, int perPage)
        {
            PaginatedList<SchedulingResponseModel> schedulingModel;
            BaseResponse<PaginatedList<SchedulingResponseModel>> response;
            Pagination pagination;

            try
            {
                pagination = Pagination
                        .Builder()
                        .SetCurrentPage(page)
                        .SetPerPage(perPage)
                    ;
                schedulingModel = await _schedulingService.GetPaginatedListSchedulingByUserId(userId,page, perPage,pagination);
                response = BaseResponse<PaginatedList<SchedulingResponseModel>>
                        .Builder()
                        .SetMessage("Agendamentos encontrados com sucesso.")
                        .SetData(schedulingModel)
                    ;
                return Ok(response);
            }
            catch (RecordNotFoundException exception)
            {
                return await NotFoundResponse(exception);
            }
            catch (Exception exception)
            {
                return await UntreatedException(exception);
            }
        }

        /// <summary>
        /// Deletando um agendamento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteSchedulingById (int id)
        {
            BaseResponse<bool> response;
            bool success;

            try
            {
                success = await _schedulingService.DeleteSchedulingById(id);
                if(!success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Falha ao deletar agendamento")
                        .SetData(false)
                        ;
                    return BadRequest(response);
                }
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Agendamento deletado com sucesso!")
                        .SetData(success)
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