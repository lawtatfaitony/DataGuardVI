using DataGuard.Models.BusinessDataModel;
using System.Data.Entity.ModelConfiguration;

namespace DataGuard.Context
{
    public class MainComConfiguration : EntityTypeConfiguration<MainCom>
    {
        public MainComConfiguration()
        {
            HasKey(t => new { t.MainComId });
            Property(t => t.MainComId).HasColumnType("nvarchar").HasMaxLength(20);
            Property(t => t.Longitude).HasColumnType("decimal").HasPrecision(18, 7);
            Property(t => t.Latitude).HasColumnType("decimal").HasPrecision(18, 7);
        }
    }
}