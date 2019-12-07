using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class WORKLOGMap : EntityTypeConfiguration<WORKLOG>
    {
        public WORKLOGMap()
        {
            // Primary Key
            this.HasKey(t => t.C_WORKLOGID_LOCAL_);

            // Properties
            this.Property(t => t.CLASS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.CREATEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.LOGTYPE)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.MODIFYBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.RECORDKEY)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("WORKLOG");
            this.Property(t => t.C_WORKLOGID_LOCAL_).HasColumnName("_WORKLOGID_LOCAL_");
            this.Property(t => t.CLASS).HasColumnName("CLASS");
            this.Property(t => t.CLIENTVIEWABLE).HasColumnName("CLIENTVIEWABLE");
            this.Property(t => t.CREATEBY).HasColumnName("CREATEBY");
            this.Property(t => t.CREATEDATE).HasColumnName("CREATEDATE");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.LOGTYPE).HasColumnName("LOGTYPE");
            this.Property(t => t.MODIFYBY).HasColumnName("MODIFYBY");
            this.Property(t => t.MODIFYDATE).HasColumnName("MODIFYDATE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.RECORDKEY).HasColumnName("RECORDKEY");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.WORKLOGID).HasColumnName("WORKLOGID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
