using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class SYNONYMDOMAINMap : EntityTypeConfiguration<SYNONYMDOMAIN>
    {
        public SYNONYMDOMAINMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SYNONYMDOMAINID });

            // Properties
            this.Property(t => t.DOMAINID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.MAXVALUE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VALUE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(256);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.VALUEID)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("SYNONYMDOMAIN");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.MAXVALUE).HasColumnName("MAXVALUE");
            this.Property(t => t.VALUE).HasColumnName("VALUE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DEFAULTS).HasColumnName("DEFAULTS");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.SYNONYMDOMAINID).HasColumnName("SYNONYMDOMAINID");
            this.Property(t => t.VALUEID).HasColumnName("VALUEID");
        }
    }
}
