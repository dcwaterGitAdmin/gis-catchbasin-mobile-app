using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class MAXDOMAINMap : EntityTypeConfiguration<MAXDOMAIN>
    {
        public MAXDOMAINMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MAXDOMAINID });

            // Properties
            this.Property(t => t.DOMAINID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.DOMAINTYPE)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.MAXTYPE)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("MAXDOMAIN");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.DOMAINTYPE).HasColumnName("DOMAINTYPE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.LENGTH).HasColumnName("LENGTH");
            this.Property(t => t.MAXDOMAINID).HasColumnName("MAXDOMAINID");
            this.Property(t => t.MAXTYPE).HasColumnName("MAXTYPE");
            this.Property(t => t.SCALE).HasColumnName("SCALE");
            this.Property(t => t.INTERNAL).HasColumnName("INTERNAL");
            this.Property(t => t.NEVERCACHE).HasColumnName("NEVERCACHE");
        }
    }
}
