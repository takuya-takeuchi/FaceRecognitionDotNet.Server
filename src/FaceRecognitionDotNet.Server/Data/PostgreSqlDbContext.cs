using FaceRecognitionDotNet.Server.Models.Databases;
using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionDotNet.Server.Data
{
    
    public sealed class PostgreSqlDbContext : DbContext
    {

        #region Constructors

        public PostgreSqlDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        #region Properties

        public System.Data.Entity.DbSet<FeatureData> FeatureDatum { get; set; }
        
        public System.Data.Entity.DbSet<RegisteredPerson> RegisteredPersons { get; set; }

        #endregion

        #region Methods

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureData>().ToTable("FeatureData");
            modelBuilder.Entity<RegisteredPerson>().ToTable("RegisteredPerson");
        }

        #endregion

        #endregion

    }

}
