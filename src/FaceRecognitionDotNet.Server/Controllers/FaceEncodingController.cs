using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Controllers
{

    /// <summary>
    /// Get feature data of face.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FaceEncodingController : ControllerBase
    {

        #region Fields

        private readonly IFaceEncodingService _FaceEncodingService;

        private readonly ILogger<FaceEncodingController> _Logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEncodingController"/> class with <see cref="IFaceEncodingService"/> and logger.
        /// </summary>
        /// <param name="faceEncodingService">The service provide face detect functions.</param>
        /// <param name="logger">The logger.</param>
        public FaceEncodingController(IFaceEncodingService faceEncodingService,
                                      ILogger<FaceEncodingController> logger)
        {
            this._FaceEncodingService = faceEncodingService;
            this._Logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an face feature data from image contains a human face.
        /// </summary>
        [Route("Encoding")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Encdoing> Encoding([FromBody] Models.Image image)
        {
            IResource<FaceRecognition> resource = null;

            try
            {
                if (!Cache.TryGetResource(out resource))
                    return new StatusCodeResult(StatusCodes.Status429TooManyRequests);

                return Ok(this._FaceEncodingService.Encoding(resource, image.Data));
            }
            catch (Exception e)
            {
                this._Logger.LogError($"[{nameof(this.Encoding)}] {e.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                resource?.Dispose();
            }
        }

        #endregion

    }

}
