using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class DOCTYPEMap : EntityTypeConfiguration<DOCTYPE>
    {
        public DOCTYPEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DOCTYPESID });

            // Properties
            this.Property(t => t.DOCTYPE_)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.DEFAULTFILEPATH)
                .HasMaxLength(255);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("DOCTYPES");
            this.Property(t => t.DOCTYPE_).HasColumnName("DOCTYPE");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.DEFAULTFILEPATH).HasColumnName("DEFAULTFILEPATH");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DOCTYPESID).HasColumnName("DOCTYPESID");
        }
    }
}
