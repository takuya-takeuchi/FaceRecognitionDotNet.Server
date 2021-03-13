using System.Threading.Tasks;
using FaceRecognitionDotNet.Server.Models;

namespace FaceRecognitionDotNet.Server.Services.Interfaces
{

    public interface IFaceRegistrationService
    {

        Task Register(Registration registration);

    }

}