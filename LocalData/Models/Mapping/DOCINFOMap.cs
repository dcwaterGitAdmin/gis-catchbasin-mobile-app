using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class DOCINFOMap : EntityTypeConfiguration<DOCINFO>
    {
        public DOCINFOMap()
        {
            // Primary Key
            this.HasKey(t => t.C_DOCINFOID_LOCAL_);

            // Navigation

            this.HasMany(t => t.DocLinks)
                .WithRequired (d => d.DocInfo)
                .HasForeignKey(d => d.C_DOCINFOID_LOCAL_);

            // Properties
            this.Property(t => t.DOCUMENT)
                .HasMaxLength(20);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(254);

            this.Property(t => t.APPLICATION)
                .HasMaxLength(8);

            this.Property(t => t.STATUS)
                .HasMaxLength(8);

            this.Property(t => t.EXTRA1)
                .HasMaxLength(9);

            this.Property(t => t.CHANGEBY)
                .HasMaxLength(30);

            this.Property(t => t.DOCLOCATION)
                .HasMaxLength(10);

            this.Property(t => t.DOCTYPE)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.CREATEBY)
                .HasMaxLength(30);

            this.Property(t => t.URLTYPE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.DMSNAME)
                .HasMaxLength(30);

            this.Property(t => t.URLNAME)
                .HasMaxLength(250);

            this.Property(t => t.URLPARAM1)
                .HasMaxLength(32);

            this.Property(t => t.URLPARAM2)
                .HasMaxLength(32);

            this.Property(t => t.URLPARAM3)
                .HasMaxLength(8);

            this.Property(t => t.URLPARAM4)
                .HasMaxLength(8);

            this.Property(t => t.URLPARAM5)
                .HasMaxLength(8);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.CONTENTUID)
                .HasMaxLength(50);
            this.Property(t => t.C_URLNAME_LOCAL_)
                .IsRequired()
                .HasMaxLength(250);


            // Table & Column Mappings
            this.ToTable("DOCINFO");
            this.Property(t => t.C_DOCINFOID_LOCAL_).HasColumnName("_DOCINFOID_LOCAL_");
            this.Property(t => t.DOCUMENT).HasColumnName("DOCUMENT");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.APPLICATION).HasColumnName("APPLICATION");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.CREATEDATE).HasColumnName("CREATEDATE");
            this.Property(t => t.REVISION).HasColumnName("REVISION");
            this.Property(t => t.EXTRA1).HasColumnName("EXTRA1");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.DOCLOCATION).HasColumnName("DOCLOCATION");
            this.Property(t => t.DOCTYPE).HasColumnName("DOCTYPE");
            this.Property(t => t.CREATEBY).HasColumnName("CREATEBY");
            this.Property(t => t.URLTYPE).HasColumnName("URLTYPE");
            this.Property(t => t.DMSNAME).HasColumnName("DMSNAME");
            this.Property(t => t.URLNAME).HasColumnName("URLNAME");
            this.Property(t => t.URLPARAM1).HasColumnName("URLPARAM1");
            this.Property(t => t.URLPARAM2).HasColumnName("URLPARAM2");
            this.Property(t => t.URLPARAM3).HasColumnName("URLPARAM3");
            this.Property(t => t.URLPARAM4).HasColumnName("URLPARAM4");
            this.Property(t => t.URLPARAM5).HasColumnName("URLPARAM5");
            this.Property(t => t.PRINTTHRULINKDFLT).HasColumnName("PRINTTHRULINKDFLT");
            this.Property(t => t.USEDEFAULTFILEPATH).HasColumnName("USEDEFAULTFILEPATH");
            this.Property(t => t.SHOW).HasColumnName("SHOW");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DOCINFOID).HasColumnName("DOCINFOID");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.CONTENTUID).HasColumnName("CONTENTUID");
            this.Property(t => t.C_URLNAME_LOCAL_).HasColumnName("_URLNAME_LOCAL_");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
