using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PLI.System.API.Entities.Business;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Services;

namespace PLI.System.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AttendantController : ControllerBase
    {
        private readonly ILogger<AttendantController> _logger;
        private readonly IAttendantService _attendantService;

        public AttendantController(ILogger<AttendantController> logger, IAttendantService attendantService)
        {
            _logger = logger;
            _attendantService = attendantService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AttendantCreateViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                //if (await _attendantService.IsExists("Name", model.Name, cancellationToken))
                //{
                //    message = $"The attendant name- '{model.Name}' already exists";
                //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseViewModel<attendantViewModel>
                //    {
                //        Success = false,
                //        Message = message,
                //        Error = new ErrorViewModel
                //        {
                //            Code = "DUPLICATE_NAME",
                //            Message = message
                //        }
                //    });
                //}

                //if (await _attendantService.IsExists("Code", model.Code, cancellationToken))
                //{
                //    message = $"The attendant code- '{model.Code}' already exists";
                //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseViewModel<attendantViewModel>
                //    {
                //        Success = false,
                //        Message = message,
                //        Error = new ErrorViewModel
                //        {
                //            Code = "DUPLICATE_CODE",
                //            Message = message
                //        }
                //    });
                //}

                try
                {
                    var data = await _attendantService.Create(model, cancellationToken);

                    var response = new ResponseViewModel<AttendantViewModel>
                    {
                        Success = true,
                        Message = "Attendant created successfully",
                        Data = data
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the attendant");
                    message = $"An error occurred while adding the attendant- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseViewModel<AttendantViewModel>
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorViewModel
                        {
                            Code = "ADD_attendant_ERROR",
                            Message = message
                        }
                    });
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseViewModel<AttendantViewModel>
            {
                Success = false,
                Message = "Invalid input",
                Error = new ErrorViewModel
                {
                    Code = "INPUT_VALIDATION_ERROR",
                    //Message = ModelStateHelper.GetErrors(ModelState)
                }
            });
        }
    }

}