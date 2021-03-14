using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FaceRecognitionDotNet.Server.Models;

namespace FaceRecognitionDotNet.Server.Services.Interfaces
{

    public interface IFaceRegistrationService
    {

        Task<IEnumerable<Registration>> GetAll();

        Task Register(Registration registration);

        Task Remove(Guid id);

    }

}