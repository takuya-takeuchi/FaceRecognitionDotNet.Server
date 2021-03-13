﻿using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Storage;

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
            IDbContextTransaction transaction = null;

            try
            {
                var context = this._DatabaseContext;
                transaction = context.Database.BeginTransaction();
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

                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                // TODO: Handle failure
            }
            finally
            {
                transaction?.Dispose();
            }

            return Task.CompletedTask;
        }

        #endregion

    }

}