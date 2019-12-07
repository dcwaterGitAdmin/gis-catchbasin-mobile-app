using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class WORKTYPEMap : EntityTypeConfiguration<WORKTYPE>
    {
        public WORKTYPEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.WORKTYPEID });

            // Properties
            this.Property(t => t.WORKTYPE_)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.WTYPEDESC)
                .HasMaxLength(50);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.TYPE)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.WOCLASS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.COMPLETESTATUS)
                .HasMaxLength(16);

            this.Property(t => t.STARTSTATUS)
                .HasMaxLength(16);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.CONTENTUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("WORKTYPE");
            this.Property(t => t.WORKTYPE_).HasColumnName("WORKTYPE");
            this.Property(t => t.WTYPEDESC).HasColumnName("WTYPEDESC");
            this.Property(t => t.PROMPTFAIL).HasColumnName("PROMPTFAIL");
            this.Property(t => t.PROMPTDOWN).HasColumnName("PROMPTDOWN");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.TYPE).HasColumnName("TYPE");
            this.Property(t => t.WOCLASS).HasColumnName("WOCLASS");
            this.Property(t => t.WORKTYPEID).HasColumnName("WORKTYPEID");
            this.Property(t => t.COMPLETESTATUS).HasColumnName("COMPLETESTATUS");
            this.Property(t => t.STARTSTATUS).HasColumnName("STARTSTATUS");
            this.Property(t => t.KEEPTASKSTATUSHIST).HasColumnName("KEEPTASKSTATUSHIST");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.CONTENTUID).HasColumnName("CONTENTUID");
            this.Property(t => t.DCW_APPTRACK).HasColumnName("DCW_APPTRACK");
            this.Property(t => t.DCW_CDCTRACK).HasColumnName("DCW_CDCTRACK");
            this.Property(t => t.DCW_DSSTRACK).HasColumnName("DCW_DSSTRACK");
            this.Property(t => t.DCW_DWSTRACK).HasColumnName("DCW_DWSTRACK");
            this.Property(t => t.DCW_FACTRACK).HasColumnName("DCW_FACTRACK");
            this.Property(t => t.DCW_MOBTRACK).HasColumnName("DCW_MOBTRACK");
            this.Property(t => t.DCW_QUICKREP).HasColumnName("DCW_QUICKREP");
            this.Property(t => t.DCW_WOTRACK).HasColumnName("DCW_WOTRACK");
            this.Property(t => t.DCW_WQTRACK).HasColumnName("DCW_WQTRACK");

        }
    }
}
