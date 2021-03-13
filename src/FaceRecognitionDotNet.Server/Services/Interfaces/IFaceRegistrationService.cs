using System.Collections.Generic;
using FaceRecognitionDotNet.Server.Helpers;
using FaceRecognitionDotNet.Server.Models;

namespace FaceRecognitionDotNet.Server.Services.Interfaces
{

    public interface IFaceRegistrationService
    {

        Encoding Encoding(IResource<FaceRecognition> resource, byte[] data);

    }

}