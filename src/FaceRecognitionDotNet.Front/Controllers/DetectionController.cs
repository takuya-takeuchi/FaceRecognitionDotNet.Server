using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FaceRecognitionDotNet.Client;
using FaceRecognitionDotNet.Client.Api;

namespace FaceRecognitionDotNet.Front.Controllers
{

    public class DetectionController : Controller
    {

        #region Methods

        public IActionResult Index()
        {
            this.ViewBag.Images = null;
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            // 保存先を取得
            var filePath = @"C:\work\";

            var validFiles = files.Where(formFile => formFile != null && formFile.Length > 0).ToArray();

            var list = new List<string>(validFiles.Length);
            this.ViewBag.Images = list;

            foreach (var formFile in validFiles)
            {
                await using var ms = new MemoryStream();
                await formFile.OpenReadStream().CopyToAsync(ms);
                list.Add(ViewImage(ms.ToArray()));
            }

            //this.ViewData["uploadResult"] = Ok(new { count = files.Count, size, filePath }).Value.ToString();

            return View(nameof(this.Index));
        }

        #region Helpers

        [NonAction]
        private void DetectFace(string url, string file)
        {
            var api = new FaceDetectionApi(url);
            try
            {
                var image = new Client.Model.Image(System.IO.File.ReadAllBytes(file));
                var result = api.FaceDetectionLocationsPostWithHttpInfo(image);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine($"[Error] {nameof(FaceDetectionApi)} returns {result.StatusCode}");
                    return;
                }

                Console.WriteLine($"[Info] Find {result.Data.Count} faces");

                //using var ms = new MemoryStream(image.Data);
                //using var bitmap = (Bitmap)Image.FromStream(ms);
                //using var g = Graphics.FromImage(bitmap);
                //using var pen = new Pen(Color.Red, 2);
                //foreach (var area in result.Data)
                //{
                //    var x = area.Left;
                //    var y = area.Top;
                //    var w = area.Right - x;
                //    var h = area.Bottom - y;
                //    g.DrawRectangle(pen, x, y, w, h);
                //}

                //bitmap.Save("result.jpg");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
