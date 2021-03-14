using System.Collections.Generic;
using FaceRecognitionDotNet.Front.Models;

namespace FaceRecognitionDotNet.Front.Services.Interfaces
{

    public interface IFaceDetectionService
    {

        IEnumerable<DetectAreaModel> Locations(byte[] image);

    }

}