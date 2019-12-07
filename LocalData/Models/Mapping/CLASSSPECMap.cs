using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class CLASSSPECMap : EntityTypeConfiguration<CLASSSPEC>
    {
        public CLASSSPECMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CLASSSPECID });

            // Properties
            this.Property(t => t.CLASSSTRUCTUREID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ASSETATTRID)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.MEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.DOMAINID)
                .HasMaxLength(18);

            this.Property(t => t.ATTRDESCPREFIX)
                .HasMaxLength(8);

            this.Property(t => t.CS01)
                .HasMaxLength(10);

            this.Property(t => t.CS02)
                .HasMaxLength(10);

            this.Property(t => t.CS03)
                .HasMaxLength(10);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SECTION)
                .HasMaxLength(10);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.INHERITEDFROM)
                .HasMaxLength(254);

            this.Property(t => t.LINKEDTOATTRIBUTE)
                .HasMaxLength(300);

            this.Property(t => t.LINKEDTOSECTION)
                .HasMaxLength(10);

            this.Property(t => t.LOOKUPNAME)
                .HasMaxLength(30);

            this.Property(t => t.TABLEATTRIBUTE)
                .HasMaxLength(50);

            this.Property(t => t.LINEARTYPE)
                .HasMaxLength(12);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("CLASSSPEC");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.ASSETATTRID).HasColumnName("ASSETATTRID");
            this.Property(t => t.MEASUREUNITID).HasColumnName("MEASUREUNITID");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.ATTRDESCPREFIX).HasColumnName("ATTRDESCPREFIX");
            this.Property(t => t.CS01).HasColumnName("CS01");
            this.Property(t => t.CS02).HasColumnName("CS02");
            this.Property(t => t.CS03).HasColumnName("CS03");
            this.Property(t => t.CS04).HasColumnName("CS04");
            this.Property(t => t.CS05).HasColumnName("CS05");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.CLASSSPECID).HasColumnName("CLASSSPECID");
            this.Property(t => t.SECTION).HasColumnName("SECTION");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.APPLYDOWNHIER).HasColumnName("APPLYDOWNHIER");
            this.Property(t => t.ASSETATTRIBUTEID).HasColumnName("ASSETATTRIBUTEID");
            this.Property(t => t.INHERITEDFROM).HasColumnName("INHERITEDFROM");
            this.Property(t => t.INHERITEDFROMID).HasColumnName("INHERITEDFROMID");
            this.Property(t => t.LINKEDTOATTRIBUTE).HasColumnName("LINKEDTOATTRIBUTE");
            this.Property(t => t.LINKEDTOSECTION).HasColumnName("LINKEDTOSECTION");
            this.Property(t => t.LOOKUPNAME).HasColumnName("LOOKUPNAME");
            this.Property(t => t.TABLEATTRIBUTE).HasColumnName("TABLEATTRIBUTE");
            this.Property(t => t.CONTINUOUS).HasColumnName("CONTINUOUS");
            this.Property(t => t.LINEARTYPE).HasColumnName("LINEARTYPE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
