using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class MAXTABLEDOMAINMap : EntityTypeConfiguration<MAXTABLEDOMAIN>
    {
        public MAXTABLEDOMAINMap()
        {
            // Primary Key
            this.HasKey(t => new {t.MAXTABLEDOMAINID });

            // Properties
            this.Property(t => t.DOMAINID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.VALIDTNWHERECLAUSE)
                .HasMaxLength(4000);

            this.Property(t => t.LISTWHERECLAUSE)
                .HasMaxLength(4000);

            this.Property(t => t.ERRORRESOURCBUNDLE)
                .HasMaxLength(50);

            this.Property(t => t.ERRORACCESSKEY)
                .HasMaxLength(50);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.OBJECTNAME)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("MAXTABLEDOMAIN");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.VALIDTNWHERECLAUSE).HasColumnName("VALIDTNWHERECLAUSE");
            this.Property(t => t.LISTWHERECLAUSE).HasColumnName("LISTWHERECLAUSE");
            this.Property(t => t.ERRORRESOURCBUNDLE).HasColumnName("ERRORRESOURCBUNDLE");
            this.Property(t => t.ERRORACCESSKEY).HasColumnName("ERRORACCESSKEY");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.MAXTABLEDOMAINID).HasColumnName("MAXTABLEDOMAINID");
            this.Property(t => t.OBJECTNAME).HasColumnName("OBJECTNAME");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
        }
    }
}
