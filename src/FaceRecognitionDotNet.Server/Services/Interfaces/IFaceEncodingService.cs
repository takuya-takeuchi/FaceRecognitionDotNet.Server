using System.Collections.Generic;
using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;

namespace FaceRecognitionDotNet.Server.Services.Interfaces
{

    public interface IFaceEncodingService
    {

        Encdoing Encoding(IResource<FaceRecognition> resource, byte[] data);

    }

}