using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class FAILUREREMARKMap : EntityTypeConfiguration<FAILUREREMARK>
    {
        public FAILUREREMARKMap()
        {
            // Primary Key
            this.HasKey(t => t.C_FAILUREREMARKID_LOCAL_);

            this.HasRequired(t => t.Workorder)
                .WithOptional(w => w.FailureRemark)
                .Map(t => t.MapKey("_WONUM_LOCAL_"))
                .WillCascadeOnDelete(false);

            // Properties
            this.Property(t => t.WONUM)
                .HasMaxLength(10);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(254);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.TICKETCLASS)
                .HasMaxLength(16);

            this.Property(t => t.TICKETID)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("FAILUREREMARK");
            this.Property(t => t.C_FAILUREREMARKID_LOCAL_).HasColumnName("_FAILUREREMARKID_LOCAL_");
            //this.Property(t => t.C_WONUM_LOCAL_).HasColumnName("_WONUM_LOCAL_");
            this.Property(t => t.WONUM).HasColumnName("WONUM");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.ENTERDATE).HasColumnName("ENTERDATE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.FAILUREREMARKID).HasColumnName("FAILUREREMARKID");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.TICKETCLASS).HasColumnName("TICKETCLASS");
            this.Property(t => t.TICKETID).HasColumnName("TICKETID");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
