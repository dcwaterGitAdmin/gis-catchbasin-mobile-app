using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class ALNDOMAINMap : EntityTypeConfiguration<ALNDOMAIN>
    {
        public ALNDOMAINMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ALNDOMAINID });

            // Properties
            this.Property(t => t.DOMAINID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.VALUE)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.VALUEID)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("ALNDOMAIN");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.VALUE).HasColumnName("VALUE");
            this.Property(t => t.ALNDOMAINID).HasColumnName("ALNDOMAINID");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.VALUEID).HasColumnName("VALUEID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
