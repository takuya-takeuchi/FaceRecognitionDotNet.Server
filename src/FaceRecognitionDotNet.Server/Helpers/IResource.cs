using System;

namespace FaceRecognitionDotNet.Server.Helpers
{

    public interface IResource<T> : IDisposable
        where T: IDisposable
    {

        T Object
        {
            get;
        }

    }

}