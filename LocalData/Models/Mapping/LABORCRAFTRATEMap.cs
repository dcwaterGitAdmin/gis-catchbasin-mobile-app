using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class LABORCRAFTRATEMap : EntityTypeConfiguration<LABORCRAFTRATE>
    {
        public LABORCRAFTRATEMap()
        {
            // Primary Key
            this.HasKey(t => new {  t.LABORCRAFTRATEID });

            // Properties
            this.Property(t => t.CONTRACTNUM)
                .HasMaxLength(8);

            this.Property(t => t.CONTROLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.CRAFT)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.DEFAULTTICKETGLACC)
                .HasMaxLength(30);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.LABORCODE)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SKILLLEVEL)
                .HasMaxLength(15);

            this.Property(t => t.VENDOR)
                .HasMaxLength(12);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("LABORCRAFTRATE");
            this.Property(t => t.CONTRACTNUM).HasColumnName("CONTRACTNUM");
            this.Property(t => t.CONTROLACCOUNT).HasColumnName("CONTROLACCOUNT");
            this.Property(t => t.CRAFT).HasColumnName("CRAFT");
            this.Property(t => t.DEFAULTCRAFT).HasColumnName("DEFAULTCRAFT");
            this.Property(t => t.DEFAULTTICKETGLACC).HasColumnName("DEFAULTTICKETGLACC");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.INHERIT).HasColumnName("INHERIT");
            this.Property(t => t.LABORCODE).HasColumnName("LABORCODE");
            this.Property(t => t.LABORCRAFTRATEID).HasColumnName("LABORCRAFTRATEID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.RATE).HasColumnName("RATE");
            this.Property(t => t.SKILLLEVEL).HasColumnName("SKILLLEVEL");
            this.Property(t => t.VENDOR).HasColumnName("VENDOR");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
