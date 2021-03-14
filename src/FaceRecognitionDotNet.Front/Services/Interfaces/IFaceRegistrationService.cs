using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FaceRecognitionDotNet.Client.Model;
using FaceRecognitionDotNet.Front.Models;

namespace FaceRecognitionDotNet.Front.Services.Interfaces
{

    public interface IFaceRegistrationService
    {
        
        Task<IEnumerable<Registration>> GetAll();

        Task<string> Register(RegistrationViewModel registrationViewModel, byte[] image);

        Task Remove(Guid id);

    }

}