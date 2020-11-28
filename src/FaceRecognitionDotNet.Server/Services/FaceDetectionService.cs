using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Services
{

    public sealed class FaceDetectionService : IFaceDetectionService
    {

        public IEnumerable<FaceArea> Locations(IResource<FaceRecognition> resource, byte[] data)
        {
            if (resource == null)
                throw new ArgumentNullException(nameof(resource));
            if (data == null) 
                throw new ArgumentNullException(nameof(data));

            var areas = new List<FaceArea>();

            using (var ms = new MemoryStream(data))
            using (var bitmap = (Bitmap)System.Drawing.Image.FromStream(ms))
            using (var faceImage = FaceRecognition.LoadImage(bitmap))
            {
                var dets = resource.Object.FaceLocations(faceImage);
                foreach (var r in dets)
                    areas.Add(new FaceArea
                    {
                        Left = r.Left,
                        Top = r.Top,
                        Right = r.Right,
                        Bottom = r.Bottom
                    });
            }

            return areas;
        }

    }

}