using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Front.Models;
using FaceRecognitionDotNet.Front.Services.Interfaces;

namespace FaceRecognitionDotNet.Front.Services
{

    public sealed class FaceDetectionService : IFaceDetectionService
    {

        #region Fields

        private readonly string _EndPointUrl;

        #endregion

        #region Constructors

        public FaceDetectionService(IConfiguration configuration)
        {
            this._EndPointUrl = configuration.GetSection("APIServer").GetValue<string>("EndPointUrl");
        }

        #endregion

        #region IFaceDetectionService Members

        public IEnumerable<DetectAreaModel> Locations(byte[] image)
        {
            var results = new List<DetectAreaModel>();

            var api = new FaceDetectionApi(this._EndPointUrl);

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

        #endregion

    }

}