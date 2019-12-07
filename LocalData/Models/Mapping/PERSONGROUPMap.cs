using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class PERSONGROUPMap : EntityTypeConfiguration<PERSONGROUP>
    {
        public PERSONGROUPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PERSONGROUPID });

            // Properties
            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.PERSONGROUP_)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.VEHICLENUM)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PERSONGROUP");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.PERSONGROUP_).HasColumnName("PERSONGROUP");
            this.Property(t => t.PERSONGROUPID).HasColumnName("PERSONGROUPID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.VEHICLENUM).HasColumnName("VEHICLENUM");
        }
    }
}
