using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.CoreServices.Interfaces;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace meetroomreservation.Application.Controller
{
    [ApiController, Route("[controller]")]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;
        public UserController(
            ILogger<UserController> logger,
            ILoggerService loggerService,
            IUserService userService) : base(logger, loggerService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<int>>> CreateUser(UserCreateRequestModel request)
        {
            BaseResponse<int> response;
            int id;

            try
            {
                id = await _userService.CreateUser(request);
                if (id == 0)
                {
                    response = BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao cadastrar um novo usuário!")
                        .SetData(0)
                    ;
                    return BadRequest(response);
                }

                response = BaseResponse<int>
                       .Builder()
                       .SetMessage("Usuário cadastrado com sucesso!")
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

        [HttpPost("Update")]
        public async Task<ActionResult<BaseResponse<string>>> UpdateUser(UserUpadateRequestModel request)
        {
            BaseResponse<string> response;
            bool success;

            try
            {
                success = await _userService.UpdateUser(request);
                if (!success)
                {
                    response = BaseResponse<string>
                            .Builder()
                            .SetMessage("Falha na atualização do usuário.")
                            .SetData("")
                        ;
                    return BadRequest(response);
                }

                response = BaseResponse<string>
                        .Builder()
                        .SetMessage("Usuário atualizado com sucesso")
                        .SetData("")
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
        /// alterando senha
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Update/Password")]
        public async Task<ActionResult<BaseResponse<bool>>> UpdateUserPassword(UserUpdatePasswordRequestModel request)
        {
            BaseResponse<bool> response;
            bool success;

            try
            {
                success = await _userService.UpdateUserPassword(request);
                if (!success)
                {
                    response = BaseResponse<bool>
                            .Builder()
                            .SetMessage("Falha ao atualizar senha do usuário.")
                            .SetData(false)
                        ;
                    return BadRequest(response);
                }

                response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Usuário atualizado com sucesso")
                        .SetData(true)
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
        /// Deletando um usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteUserById (int id)
        {
            BaseResponse<bool> response;
            bool success;

            try
            {
                success = await _userService.DeleteUserById(id);
                if(!success)
                {
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Falha ao deletar usuário")
                        .SetData(false)
                        ;
                    return BadRequest(response);
                }
                    response = BaseResponse<bool>
                        .Builder()
                        .SetMessage("Usuário deletado com sucesso!")
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
    }
}