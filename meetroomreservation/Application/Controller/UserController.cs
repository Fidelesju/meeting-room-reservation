using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<BaseResponse<int>>> CreateUser (UserCreateRequestModel userRequest)
        {
            BaseResponse<int> response;
            int id;

            try
            {
                id =  await _userService.CreateUser(userRequest);
                if(id == 0)
                {
                    response =  BaseResponse<int>
                        .Builder()
                        .SetMessage("Falha ao cadastrar um novo usuário!")
                        .SetData(0)
                    ;
                    return BadRequest(response);
                }

                 response =  BaseResponse<int>
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
            catch(Exception exception)
            {
                return await UntreatedException(exception);
            }
        }
    }
}