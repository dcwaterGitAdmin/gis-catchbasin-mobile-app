using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class FAILUREREPORTMap : EntityTypeConfiguration<FAILUREREPORT>
    {
        public FAILUREREPORTMap()
        {
            // Primary Key
            this.HasKey(t => t.C_FAILUREREPORTID_LOCAL_);

            // Properties
            this.Property(t => t.C_ASSETNUM_LOCAL_);

            this.Property(t => t.WONUM)
                .HasMaxLength(10);

            this.Property(t => t.FAILURECODE)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TYPE)
                .HasMaxLength(12);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.ASSETNUM)
                .HasMaxLength(12);

            this.Property(t => t.TICKETCLASS)
                .HasMaxLength(16);

            this.Property(t => t.TICKETID)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("FAILUREREPORT");
            this.Property(t => t.C_FAILUREREPORTID_LOCAL_).HasColumnName("_FAILUREREPORTID_LOCAL_");
            this.Property(t => t.C_WONUM_LOCAL_).HasColumnName("_WONUM_LOCAL_");
            this.Property(t => t.C_ASSETNUM_LOCAL_).HasColumnName("_ASSETNUM_LOCAL_");
            this.Property(t => t.WONUM).HasColumnName("WONUM");
            this.Property(t => t.FAILURECODE).HasColumnName("FAILURECODE");
            this.Property(t => t.LINENUM).HasColumnName("LINENUM");
            this.Property(t => t.TYPE).HasColumnName("TYPE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.ASSETNUM).HasColumnName("ASSETNUM");
            this.Property(t => t.FAILUREREPORTID).HasColumnName("FAILUREREPORTID");
            this.Property(t => t.TICKETCLASS).HasColumnName("TICKETCLASS");
            this.Property(t => t.TICKETID).HasColumnName("TICKETID");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
