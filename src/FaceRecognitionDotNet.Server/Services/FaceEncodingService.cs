using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Services
{

    public sealed class FaceEncodingService : IFaceEncodingService
    {

        public Encoding Encoding(IResource<FaceRecognition> resource, byte[] data)
        {
            if (resource == null)
                throw new ArgumentNullException(nameof(resource));
            if (data == null) 
                throw new ArgumentNullException(nameof(data));

            using var ms = new MemoryStream(data);
            using var bitmap = (Bitmap)System.Drawing.Image.FromStream(ms);
            using var faceImage = FaceRecognition.LoadImage(bitmap);
            var location = new Location(0, 0, bitmap.Width, bitmap.Height);
            var encodings = resource.Object.FaceEncodings(faceImage, new []{ location }, 1, PredictorModel.Large);
            return new Encoding()
            {
                Data = encodings.First().GetRawEncoding()
            };
        }

    }

}