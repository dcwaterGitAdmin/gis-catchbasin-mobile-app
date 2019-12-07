using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class ASSETATTRIBUTEMap : EntityTypeConfiguration<ASSETATTRIBUTE>
    {
        public ASSETATTRIBUTEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ASSETATTRIBUTEID });

            // Properties
            this.Property(t => t.ASSETATTRID)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.DATATYPE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.MEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.DOMAINID)
                .HasMaxLength(18);

            this.Property(t => t.ATTRDESCPREFIX)
                .HasMaxLength(8);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("ASSETATTRIBUTE");
            this.Property(t => t.ASSETATTRID).HasColumnName("ASSETATTRID");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.DATATYPE).HasColumnName("DATATYPE");
            this.Property(t => t.MEASUREUNITID).HasColumnName("MEASUREUNITID");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.ATTRDESCPREFIX).HasColumnName("ATTRDESCPREFIX");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.ASSETATTRIBUTEID).HasColumnName("ASSETATTRIBUTEID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
        }
    }
}
