using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Controllers
{

    /// <summary>
    /// Get rectangles of face area from specified image.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FaceDetectionController : ControllerBase
    {

        #region Fields

        private readonly IFaceDetectionService _FaceDetectionService;

        private readonly ILogger<FaceDetectionController> _Logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceDetectionController"/> class with <see cref="IFaceDetectionService"/> and logger.
        /// </summary>
        /// <param name="faceDetectionService">The service provide face detect functions.</param>
        /// <param name="logger">The logger.</param>
        public FaceDetectionController(IFaceDetectionService faceDetectionService,
                                       ILogger<FaceDetectionController> logger)
        {
            this._FaceDetectionService = faceDetectionService;
            this._Logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an enumerable collection of face location correspond to all faces in specified image.
        /// </summary>
        [Route("Locations")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<FaceArea>> Locations([FromBody] Models.Image image)
        {
            IResource<FaceRecognition> resource = null;

            try
            {
                if (!Cache.TryGetResource(out resource))
                    return new StatusCodeResult(StatusCodes.Status429TooManyRequests);

                return Ok(this._FaceDetectionService.Locations(resource, image.Data));
            }
            catch (Exception e)
            {
                this._Logger.LogError($"[{nameof(this.Locations)}] {e.Message}");
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
