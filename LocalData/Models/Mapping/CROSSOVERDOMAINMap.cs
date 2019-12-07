using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class CROSSOVERDOMAINMap : EntityTypeConfiguration<CROSSOVERDOMAIN>
    {
        public CROSSOVERDOMAINMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CROSSOVERDOMAINID });

            // Properties
            this.Property(t => t.DOMAINID)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.SOURCEFIELD)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DESTFIELD)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.ORGID)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.DESTCONDITION)
                .HasMaxLength(12);

            this.Property(t => t.SOURCECONDITION)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("CROSSOVERDOMAIN");
            this.Property(t => t.DOMAINID).HasColumnName("DOMAINID");
            this.Property(t => t.SOURCEFIELD).HasColumnName("SOURCEFIELD");
            this.Property(t => t.DESTFIELD).HasColumnName("DESTFIELD");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.CROSSOVERDOMAINID).HasColumnName("CROSSOVERDOMAINID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.COPYEVENIFSRCNULL).HasColumnName("COPYEVENIFSRCNULL");
            this.Property(t => t.COPYONLYIFDESTNULL).HasColumnName("COPYONLYIFDESTNULL");
            this.Property(t => t.DESTCONDITION).HasColumnName("DESTCONDITION");
            this.Property(t => t.SEQUENCE).HasColumnName("SEQUENCE");
            this.Property(t => t.SOURCECONDITION).HasColumnName("SOURCECONDITION");
        }
    }
}
