using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FaceRecognitionDotNet.Front.Helpers;
using FaceRecognitionDotNet.Front.Models;
using FaceRecognitionDotNet.Front.Services.Interfaces;

namespace FaceRecognitionDotNet.Front.Controllers
{

    public sealed class DetectionController : Controller
    {

        #region Fields

        private readonly IFaceDetectionService _FaceDetectionService;

        #endregion

        #region Constructors

        public DetectionController(IFaceDetectionService faceDetectionService)
        {
            this._FaceDetectionService = faceDetectionService;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            if (files.Count != 1)
                return this.View(nameof(this.Index));

            var formFile = files.First();

            var model = new DetectionViewModel();

            await using var ms = new MemoryStream();
            await formFile.OpenReadStream().CopyToAsync(ms);

            using var bitmap = Image.FromStream(ms);
            var data = ImageHelper.ConvertToBase64(ms.ToArray());
            var width = bitmap.Width;
            var height = bitmap.Height;

            model.Image = new ImageViewModel(formFile.FileName, data, width, height);

            var areas = new List<DetectAreaModel>();
            var detect = this._FaceDetectionService.Locations(ms.ToArray());
            if (detect != null)
                areas.AddRange(detect);
            
            model.DetectAreas = areas.ToArray();

            return this.View(nameof(this.Index), model);
        }

        #endregion

    }

}
