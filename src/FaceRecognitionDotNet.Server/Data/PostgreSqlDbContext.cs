using FaceRecognitionDotNet.Server.Models.Databases;
using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionDotNet.Server.Data
{
    
    public sealed class PostgreSqlDbContext : DbContext
    {

        #region Constructors

        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Properties

        public DbSet<FeatureData> FeatureDatum { get; set; }
        
        public DbSet<RegisteredPerson> RegisteredPersons { get; set; }

        #endregion

        #region Methods

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureData>().ToTable("FeatureData");
            modelBuilder.Entity<RegisteredPerson>().ToTable("RegisteredPerson");

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #endregion

    }

}
