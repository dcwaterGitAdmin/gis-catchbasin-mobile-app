using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class MAXROWSTAMPMap : EntityTypeConfiguration<MAXROWSTAMP>
    {
        public MAXROWSTAMPMap()
        {
            // Primary Key
            this.HasKey(t => new {  t.MAXROWSTAMPID });

            // Properties
            this.Property(t => t.TABLENAME)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("MAXROWSTAMP");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.CURMAXROWSTAMP).HasColumnName("CURMAXROWSTAMP");
            this.Property(t => t.MAXROWSTAMPID).HasColumnName("MAXROWSTAMPID");
            this.Property(t => t.TABLENAME).HasColumnName("TABLENAME");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
