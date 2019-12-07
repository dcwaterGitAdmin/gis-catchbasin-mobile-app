using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class WOSTATUSMap : EntityTypeConfiguration<WOSTATUS>
    {
        public WOSTATUSMap()
        {
            // Primary Key
            this.HasKey(t => t.C_WOSTATUSID_LOCAL_);

            // Properties
            this.Property(t => t.WONUM)
                .HasMaxLength(10);

            this.Property(t => t.STATUS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.CHANGEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.MEMO)
                .HasMaxLength(50);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.FINCNTRLID)
                .HasMaxLength(8);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.PARENT)
                .HasMaxLength(10);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("WOSTATUS");
            this.Property(t => t.C_WOSTATUSID_LOCAL_).HasColumnName("_WOSTATUSID_LOCAL_");
            this.Property(t => t.C_WORKORDERID_LOCAL_).HasColumnName("_WORKORDERID_LOCAL_");
            this.Property(t => t.WONUM).HasColumnName("WONUM");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.MEMO).HasColumnName("MEMO");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.FINCNTRLID).HasColumnName("FINCNTRLID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.WOSTATUSID).HasColumnName("WOSTATUSID");
            this.Property(t => t.PARENT).HasColumnName("PARENT");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
