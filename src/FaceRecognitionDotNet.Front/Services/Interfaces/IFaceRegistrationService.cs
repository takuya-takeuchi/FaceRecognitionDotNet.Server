using System.Threading.Tasks;

namespace FaceRecognitionDotNet.Front.Services.Interfaces
{

    public interface IFaceRegistrationService
    {

        Task<string> Register(byte[] image);

    }

}