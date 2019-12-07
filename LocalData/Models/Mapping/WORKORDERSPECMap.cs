using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class WORKORDERSPECMap : EntityTypeConfiguration<WORKORDERSPEC>
    {
        public WORKORDERSPECMap()
        {
            // Primary Key
            this.HasKey(t => t.C_WORKORDERSPECID_LOCAL_);

            // Properties
            this.Property(t => t.ALNVALUE)
                .HasMaxLength(255);

            this.Property(t => t.ASSETATTRID)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.CHANGEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.CLASSSTRUCTUREID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LINKEDTOATTRIBUTE)
                .HasMaxLength(300);

            this.Property(t => t.LINKEDTOSECTION)
                .HasMaxLength(10);

            this.Property(t => t.MEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.REFOBJECTNAME)
                .HasMaxLength(30);

            this.Property(t => t.SECTION)
                .HasMaxLength(10);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.TABLEVALUE)
                .HasMaxLength(254);

            this.Property(t => t.WONUM)
                .HasMaxLength(10);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("WORKORDERSPEC");
            this.Property(t => t.C_WORKORDERSPECID_LOCAL_).HasColumnName("_WORKORDERSPECID_LOCAL_");
            this.Property(t => t.ALNVALUE).HasColumnName("ALNVALUE");
            this.Property(t => t.ASSETATTRID).HasColumnName("ASSETATTRID");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.CLASSSPECID).HasColumnName("CLASSSPECID");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.DISPLAYSEQUENCE).HasColumnName("DISPLAYSEQUENCE");
            this.Property(t => t.LINKEDTOATTRIBUTE).HasColumnName("LINKEDTOATTRIBUTE");
            this.Property(t => t.LINKEDTOSECTION).HasColumnName("LINKEDTOSECTION");
            this.Property(t => t.MANDATORY).HasColumnName("MANDATORY");
            this.Property(t => t.MEASUREUNITID).HasColumnName("MEASUREUNITID");
            this.Property(t => t.NUMVALUE).HasColumnName("NUMVALUE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.REFOBJECTID).HasColumnName("REFOBJECTID");
            this.Property(t => t.REFOBJECTNAME).HasColumnName("REFOBJECTNAME");
            this.Property(t => t.SECTION).HasColumnName("SECTION");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.TABLEVALUE).HasColumnName("TABLEVALUE");
            this.Property(t => t.WONUM).HasColumnName("WONUM");
            this.Property(t => t.WORKORDERSPECID).HasColumnName("WORKORDERSPECID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
            this.Property(t => t.C_WORKORDERID_LOCAL_).HasColumnName("_WORKORDERID_LOCAL_");
        }
    }
}
