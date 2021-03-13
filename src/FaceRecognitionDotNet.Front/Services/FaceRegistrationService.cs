using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Front.Services.Interfaces;

namespace FaceRecognitionDotNet.Front.Services
{

    public sealed class FaceRegistrationService : IFaceRegistrationService
    {

        #region Fields

        private readonly string _EndPointUrl;

        #endregion

        #region Constructors

        public FaceRegistrationService(IConfiguration configuration)
        {
            this._EndPointUrl = configuration.GetSection("APIServer").GetValue<string>("EndPointUrl");
        }

        #endregion

        #region IFaceDetectionService Members

        public async Task<string> Register(byte[] image)
        {
            var faceDetectionApi = new FaceDetectionApi(this._EndPointUrl);
            var faceEncodingApi = new FaceEncodingApi(this._EndPointUrl);

            try
            {
                var target = new Client.Model.Image(image);
                var detectResult = await faceDetectionApi.FaceDetectionLocationsPostWithHttpInfoAsync(target);
                if (detectResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "Failed to invoke service";
                }

                if (detectResult.Data.Count == 0)
                {
                    return "Failed to detect face";
                }

                if (detectResult.Data.Count != 1)
                {
                    return "Detect multiple faces";
                }

                var area = detectResult.Data.First();

                await using var memoryStream = new MemoryStream(image);
                using var bitmap = Image.FromStream(memoryStream);
                var x = area.Left;
                var y = area.Top;
                var width = area.Right - area.Left;
                var height = area.Right - area.Left;
                using var cropped = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                using var g = Graphics.FromImage(cropped);
                g.DrawImage(bitmap, new Rectangle(x, y, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);

                await using var croppedMemoryStream = new MemoryStream();
                cropped.Save(croppedMemoryStream, ImageFormat.Png);
                target = new Client.Model.Image(croppedMemoryStream.ToArray());
                var encodingResult = await faceEncodingApi.FaceEncodingEncodingPostWithHttpInfoAsync(target);
                if (encodingResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "Failed to invoke service";
                }

                var encoding = encodingResult.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        #endregion

    }

}