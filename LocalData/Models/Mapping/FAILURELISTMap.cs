using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class FAILURELISTMap : EntityTypeConfiguration<FAILURELIST>
    {
        public FAILURELISTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FAILURELIST_});

            // Properties
            this.Property(t => t.FAILURECODE)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TYPE)
                .HasMaxLength(12);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("FAILURELIST");
            this.Property(t => t.FAILURELIST_).HasColumnName("FAILURELIST");
            this.Property(t => t.FAILURECODE).HasColumnName("FAILURECODE");
            this.Property(t => t.PARENT).HasColumnName("PARENT");
            this.Property(t => t.TYPE).HasColumnName("TYPE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
