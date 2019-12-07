using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class FAILURECODEMap : EntityTypeConfiguration<FAILURECODE>
    {
        public FAILURECODEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FAILURECODEID });

            // Properties
            this.Property(t => t.FAILURECODE_)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("FAILURECODE");
            this.Property(t => t.FAILURECODE_).HasColumnName("FAILURECODE");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.FAILURECODEID).HasColumnName("FAILURECODEID");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
        }
    }
}
