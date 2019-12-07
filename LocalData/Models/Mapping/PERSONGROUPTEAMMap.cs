using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class PERSONGROUPTEAMMap : EntityTypeConfiguration<PERSONGROUPTEAM>
    {
        public PERSONGROUPTEAMMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PERSONGROUPTEAMID });

            // Properties
            this.Property(t => t.PERSONGROUP)
                .HasMaxLength(15);

            this.Property(t => t.RESPPARTY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.RESPPARTYGROUP)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.USEFORORG)
                .HasMaxLength(8);

            this.Property(t => t.USEFORSITE)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.DCW_DESIGNATION)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("PERSONGROUPTEAM");
            this.Property(t => t.GROUPDEFAULT).HasColumnName("GROUPDEFAULT");
            this.Property(t => t.ORGDEFAULT).HasColumnName("ORGDEFAULT");
            this.Property(t => t.PERSONGROUP).HasColumnName("PERSONGROUP");
            this.Property(t => t.PERSONGROUPTEAMID).HasColumnName("PERSONGROUPTEAMID");
            this.Property(t => t.RESPPARTY).HasColumnName("RESPPARTY");
            this.Property(t => t.RESPPARTYGROUP).HasColumnName("RESPPARTYGROUP");
            this.Property(t => t.RESPPARTYGROUPSEQ).HasColumnName("RESPPARTYGROUPSEQ");
            this.Property(t => t.RESPPARTYSEQ).HasColumnName("RESPPARTYSEQ");
            this.Property(t => t.SITEDEFAULT).HasColumnName("SITEDEFAULT");
            this.Property(t => t.USEFORORG).HasColumnName("USEFORORG");
            this.Property(t => t.USEFORSITE).HasColumnName("USEFORSITE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DCW_DESIGNATION).HasColumnName("DCW_DESIGNATION");
        }
    }
}
