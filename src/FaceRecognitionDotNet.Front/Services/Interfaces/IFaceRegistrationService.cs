using System.Threading.Tasks;
using FaceRecognitionDotNet.Front.Models;

namespace FaceRecognitionDotNet.Front.Services.Interfaces
{

    public interface IFaceRegistrationService
    {

        Task<string> Register(RegistrationViewModel registrationViewModel, byte[] image);

    }

}