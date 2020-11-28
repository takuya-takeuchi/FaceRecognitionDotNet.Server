using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FaceRecognitionDotNet.Client.Api;

namespace FaceEncoding
{

    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"[Error] {nameof(FaceEncoding)} <url> <image file path>");
                return;
            }

            var url = args[0];
            var file = args[1];
            if (!File.Exists(file))
            {
                Console.WriteLine($"[Error] '{file}' does not exist");
                return;
            }

            var faceDetectionApi = new FaceDetectionApi(url);
            var faceEncodingApi = new FaceEncodingApi(url);
            try
            {
                var image = new FaceRecognitionDotNet.Client.Model.Image(File.ReadAllBytes(file));
                var detectionResponse = faceDetectionApi.FaceDetectionLocationsPostWithHttpInfo(image);
                if (detectionResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine($"[Error] {nameof(FaceDetectionApi)} returns {detectionResponse.StatusCode}");
                    return;
                }

                Console.WriteLine($"[Info] Find {detectionResponse.Data.Count} faces");

                foreach (var faceArea in detectionResponse.Data)
                {
                    using var bitmap = (Bitmap)Image.FromFile(file);
                    var w = faceArea.Right - faceArea.Left;
                    var h = faceArea.Bottom - faceArea.Top;
                    using var cropped = new Bitmap(w, h, bitmap.PixelFormat);
                    using (var g = Graphics.FromImage(cropped))
                        g.DrawImage(bitmap, new Rectangle(0, 0, w, h), new Rectangle(faceArea.Left, faceArea.Top, w, h), GraphicsUnit.Pixel);
                    using (var ms = new MemoryStream())
                    {
                        cropped.Save(ms, ImageFormat.Png);

                        var croppedImage = new FaceRecognitionDotNet.Client.Model.Image(ms.ToArray());
                        var encodingResponse = faceEncodingApi.FaceEncodingEncodingPostWithHttpInfo(croppedImage);
                        if (encodingResponse.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            Console.WriteLine($"[Error] {nameof(FaceEncodingApi)} returns {encodingResponse.StatusCode}");
                            return;
                        }

                        Console.WriteLine($"[Info] Face Encoding has {encodingResponse.Data.Data.Count} length");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

    }

}
