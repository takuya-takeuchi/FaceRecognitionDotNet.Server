using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionDotNet.Server.Data
{

    public static class DatabaseInitializer<T>
        where T : DbContext
    {

        #region Methods

        public static void Initialize(T context)
        {
            context.Database.EnsureCreated();
        }

        #endregion

    }

}
