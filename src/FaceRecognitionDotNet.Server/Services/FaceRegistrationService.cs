using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FaceRecognitionDotNet.Server.Data;
using FaceRecognitionDotNet.Server.Models;
using FaceRecognitionDotNet.Server.Models.Databases;
using FaceRecognitionDotNet.Server.Services.Interfaces;

namespace FaceRecognitionDotNet.Server.Services
{

    public sealed class FaceRegistrationService : IFaceRegistrationService
    {

        #region Fields

        private readonly PostgreSqlDbContext _DatabaseContext;

        #endregion

        #region Constructors

        public FaceRegistrationService(PostgreSqlDbContext databaseContext)
        {
            this._DatabaseContext = databaseContext;
        }

        #endregion

        #region IFaceRegistrationService Members

        public Task Register(Registration registration)
        {
            var context = this._DatabaseContext;
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var id = Guid.NewGuid();
                context.RegisteredPersons.Add(new RegisteredPerson
                {
                    Id = id,
                    FirstName = registration.Demographics.FirstName,
                    LastName = registration.Demographics.LastName,
                    Photo = registration.Photo.Data,
                    CreatedDateTime = registration.Demographics.CreatedDateTime
                });
                
                var encoding = new byte[registration.Encoding.Data.Length * sizeof(double)];
                Buffer.BlockCopy(registration.Encoding.Data, 0, encoding, 0, encoding.Length);

                context.FeatureDatum.Add(new FeatureData
                {
                    Id = Guid.NewGuid(),
                    RegisteredPersonId = id,
                    Encoding = encoding
                });

                transaction.Commit();
            }
            catch (Exception ex)
            {
                // TODO: Handle failure
            }

            return Task.CompletedTask;
        }

        #endregion

    }

}