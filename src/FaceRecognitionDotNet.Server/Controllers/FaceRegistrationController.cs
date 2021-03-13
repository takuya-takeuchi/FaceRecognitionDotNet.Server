using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Controllers
{

    /// <summary>
    /// Post person data.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FaceRegistrationController : ControllerBase
    {

        #region Fields

        private readonly IFaceRegistrationService _FaceRegistrationService;

        private readonly ILogger<FaceEncodingController> _Logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRegistrationController"/> class with <see cref="IFaceRegistrationService"/> and logger.
        /// </summary>
        /// <param name="faceRegistrationService">The service provide face detect functions.</param>
        /// <param name="logger">The logger.</param>
        public FaceRegistrationController(IFaceRegistrationService faceRegistrationService,
                                          ILogger<FaceEncodingController> logger)
        {
            this._FaceRegistrationService = faceRegistrationService;
            this._Logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register person data.
        /// </summary>
        [Route("Register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Register([FromBody] Registration registration)
        {
            try
            {
                return Ok(this._FaceRegistrationService.Register(registration));
            }
            catch (Exception e)
            {
                this._Logger.LogError($"[{nameof(this.Register)}] {e.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion

    }

}
