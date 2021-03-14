using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Model;
using FaceRecognitionDotNet.Front.Models;
using FaceRecognitionDotNet.Front.Services.Interfaces;

using Image = System.Drawing.Image;

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

        public async Task<IEnumerable<Registration>> GetAll()
        {
            var faceRegistrationApi = new FaceRegistrationApi(this._EndPointUrl);
            var registrationResult = await faceRegistrationApi.FaceRegistrationGetAllGetWithHttpInfoAsync();
            if (registrationResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return registrationResult.Data;
        }

        public async Task<string> Register(RegistrationViewModel registrationViewModel, byte[] image)
        {
            var faceDetectionApi = new FaceDetectionApi(this._EndPointUrl);
            var faceEncodingApi = new FaceEncodingApi(this._EndPointUrl);
            var faceRegistrationApi = new FaceRegistrationApi(this._EndPointUrl);

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
                g.DrawImage(bitmap, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);

                await using var croppedMemoryStream = new MemoryStream();
                cropped.Save(croppedMemoryStream, ImageFormat.Png);
                target = new Client.Model.Image(croppedMemoryStream.ToArray());
                var encodingResult = await faceEncodingApi.FaceEncodingEncodingPostWithHttpInfoAsync(target);
                if (encodingResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "Failed to invoke service";
                }

                var registration = new Registration
                (
                    new Demographics(registrationViewModel.Id,
                                     registrationViewModel.FirstName,
                                     registrationViewModel.LastName,
                                     DateTime.UtcNow),
                    new Encoding(encodingResult.Data.Data),
                    new Client.Model.Image(croppedMemoryStream.ToArray())
                );

                var registrationResult = await faceRegistrationApi.FaceRegistrationRegisterPostWithHttpInfoAsync(registration);
                if (registrationResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "Failed to register";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task Remove(Guid id)
        {
            var faceRegistrationApi = new FaceRegistrationApi(this._EndPointUrl);

            try
            {
                var detectResult = await faceRegistrationApi.FaceRegistrationRemovePostWithHttpInfoAsync(id);
                if (detectResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return;
        }

        #endregion

    }

}