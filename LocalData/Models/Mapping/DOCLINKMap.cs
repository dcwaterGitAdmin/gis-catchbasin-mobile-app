using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class DOCLINKMap : EntityTypeConfiguration<DOCLINK>
    {
        public DOCLINKMap()
        {
            // Primary Key
            this.HasKey(t => t.C_DOCLINKSID_LOCAL_);
             // Properties
            this.Property(t => t.DOCUMENT)
                .HasMaxLength(20);
            this.Property(t => t.REFERENCE)
                .HasMaxLength(8);

            this.Property(t => t.DOCTYPE)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.DOCVERSION)
                .HasMaxLength(20);

            this.Property(t => t.CREATEBY)
                .HasMaxLength(30);

            this.Property(t => t.CHANGEBY)
                .HasMaxLength(30);

            this.Property(t => t.OWNERTABLE)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("DOCLINKS");
            this.Property(t => t.C_DOCLINKSID_LOCAL_).HasColumnName("_DOCLINKSID_LOCAL_");
            this.Property(t => t.C_DOCINFOID_LOCAL_).HasColumnName("_DOCINFOID_LOCAL_");
            this.Property(t => t.C_OWNERID_LOCAL_).HasColumnName("_OWNERID_LOCAL_");
            this.Property(t => t.DOCUMENT).HasColumnName("DOCUMENT");
            this.Property(t => t.REFERENCE).HasColumnName("REFERENCE");
            this.Property(t => t.DOCTYPE).HasColumnName("DOCTYPE");
            this.Property(t => t.DOCVERSION).HasColumnName("DOCVERSION");
            this.Property(t => t.GETLATESTVERSION).HasColumnName("GETLATESTVERSION");
            this.Property(t => t.CREATEBY).HasColumnName("CREATEBY");
            this.Property(t => t.CREATEDATE).HasColumnName("CREATEDATE");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.PRINTTHRULINK).HasColumnName("PRINTTHRULINK");
            this.Property(t => t.COPYLINKTOWO).HasColumnName("COPYLINKTOWO");
            this.Property(t => t.DOCINFOID).HasColumnName("DOCINFOID");
            this.Property(t => t.DOCLINKSID).HasColumnName("DOCLINKSID");
            this.Property(t => t.OWNERID).HasColumnName("OWNERID");
            this.Property(t => t.OWNERTABLE).HasColumnName("OWNERTABLE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
