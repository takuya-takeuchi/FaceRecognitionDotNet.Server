using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Front.Models;

namespace FaceRecognitionDotNet.Front.Controllers
{

    public class DetectionController : Controller
    {

        #region Methods

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            var model = new DetectionViewModel();

            var validFiles = files.Where(formFile => formFile != null && formFile.Length > 0).ToArray();

            var images = new List<ImageViewModel>(validFiles.Length);
            var detectAreas = new List<IEnumerable<DetectAreaModel>>(validFiles.Length);
            this.ViewBag.Images = detectAreas;

            foreach (var formFile in validFiles)
            {
                await using var ms = new MemoryStream();
                await formFile.OpenReadStream().CopyToAsync(ms);

                using var bitmap = Image.FromStream(ms);
                var data = ViewImage(ms.ToArray());
                var width = bitmap.Width;
                var height = bitmap.Height;

                images.Add(new ImageViewModel(formFile.FileName, data, width, height));

                var areas = new List<DetectAreaModel>();
                //areas.Add(new DetectAreaModel(100, 100, 200, 200, 0.8f));
                areas.AddRange(DetectFace("http://localhost:9000", ms.ToArray()));
                detectAreas.Add(areas);
            }

            model.Images = images.ToArray();
            model.DetectAreas = detectAreas.ToArray();

            return this.View(nameof(this.Index), model);
        }

        #region Helpers

        [NonAction]
        private IEnumerable<DetectAreaModel> DetectFace(string url, byte[] image)
        {
            var results = new List<DetectAreaModel>();

            var api = new FaceDetectionApi(url);

            try
            {
                var target = new Client.Model.Image(image);
                var result = api.FaceDetectionLocationsPostWithHttpInfo(target);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return null;
                }

                results.AddRange(result.Data.Select(area => new DetectAreaModel(area.Left,
                                                                                area.Top,
                                                                                area.Right - area.Left,
                                                                                area.Bottom - area.Top,
                                                                                0)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return results;
        }

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
