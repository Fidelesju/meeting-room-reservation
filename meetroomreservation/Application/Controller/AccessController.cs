using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices.Interfaces;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;
using meetroomreservation.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace meetroomreservation.Application.Controller
{
    [ApiController, Route("[controller]")]

    public class AccessController : BaseController<AccessController>
    {
        #region  Variables
        private readonly IAccessService _accessService;
        #endregion

        #region Constructor
        public AccessController(
            ILogger<AccessController> logger, 
            ILoggerService loggerService,
            IAccessService accessService) : base(logger, loggerService)
        {
            _accessService = accessService;
        }
        #endregion

        #region  Metodos
        /// <summary>
        /// Metodo de login - Controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<BaseResponse<UserLoginResponseModel>>> LoginUser(UserLoginRequestModel request)
        {
            UserLoginResponseModel userResponse;
            BaseResponse<UserLoginResponseModel> response;

            try
            {
                userResponse = await _accessService.AuthenticateUser(request);
                response = BaseResponse<UserLoginResponseModel>
                    .Builder()
                    .SetMessage("Usuário autenticado.")
                    .SetData(userResponse)
                    ;
                return Ok(response);
            }
             catch (RecordNotFoundException)
            {
                return StatusCode(401, BaseResponse<string>
                    .Builder()
                    .SetMessage("Acesso não autorizado.")
                    .SetData("")
                );
            }
            catch (Exception exception)
            {
                return await UntreatedException(exception);
            }
        }
        #endregion
    }
}