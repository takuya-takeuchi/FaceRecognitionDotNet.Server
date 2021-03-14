using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FaceRecognitionDotNet.Front.Models;
using FaceRecognitionDotNet.Front.Services.Interfaces;

namespace FaceRecognitionDotNet.Front.Controllers
{

    public sealed class RegistrationController : Controller
    {

        #region Fields

        private readonly IFaceRegistrationService _FaceRegistrationService;

        #endregion

        #region Constructors

        public RegistrationController(IFaceRegistrationService faceRegistrationService)
        {
            this._FaceRegistrationService = faceRegistrationService;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(RegistrationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(nameof(this.Index), model);
            }

            await using var ms = new MemoryStream();
            await model.Photo.OpenReadStream().CopyToAsync(ms);

            var result = this._FaceRegistrationService.Register(model, ms.ToArray());

            return this.View(nameof(this.Index), model);
        }

        #region Helpers

        [NonAction]
        private static string ViewImage(byte[] arrayImage)
        {
            var base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);
            return $"data:image/png;base64,{base64String}";
        }

        #endregion

        #endregion

    }

}
