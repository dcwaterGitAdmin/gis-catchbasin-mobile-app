using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class INVENTORYMap : EntityTypeConfiguration<INVENTORY>
    {
        public INVENTORYMap()
        {
            // Primary Key
            this.HasKey(t => new { t.INVENTORYID });

            // Properties
            this.Property(t => t.ITEMNUM)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.LOCATION)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.BINNUM)
                .HasMaxLength(8);

            this.Property(t => t.VENDOR)
                .HasMaxLength(12);

            this.Property(t => t.MANUFACTURER)
                .HasMaxLength(12);

            this.Property(t => t.MODELNUM)
                .HasMaxLength(20);

            this.Property(t => t.CATALOGCODE)
                .HasMaxLength(40);

            this.Property(t => t.CATEGORY)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ORDERUNIT)
                .HasMaxLength(18);

            this.Property(t => t.ISSUEUNIT)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.ABCTYPE)
                .HasMaxLength(1);

            this.Property(t => t.IL1)
                .HasMaxLength(20);

            this.Property(t => t.IL2)
                .HasMaxLength(10);

            this.Property(t => t.IL3)
                .HasMaxLength(10);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.CONTROLACC)
                .HasMaxLength(30);

            this.Property(t => t.SHRINKAGEACC)
                .HasMaxLength(30);

            this.Property(t => t.INVCOSTADJACC)
                .HasMaxLength(30);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ITEMSETID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.STORELOC)
                .HasMaxLength(12);

            this.Property(t => t.STORELOCSITEID)
                .HasMaxLength(8);

            this.Property(t => t.STATUS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("INVENTORY");
            this.Property(t => t.ITEMNUM).HasColumnName("ITEMNUM");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.BINNUM).HasColumnName("BINNUM");
            this.Property(t => t.VENDOR).HasColumnName("VENDOR");
            this.Property(t => t.MANUFACTURER).HasColumnName("MANUFACTURER");
            this.Property(t => t.MODELNUM).HasColumnName("MODELNUM");
            this.Property(t => t.CATALOGCODE).HasColumnName("CATALOGCODE");
            this.Property(t => t.MINLEVEL).HasColumnName("MINLEVEL");
            this.Property(t => t.MAXLEVEL).HasColumnName("MAXLEVEL");
            this.Property(t => t.CATEGORY).HasColumnName("CATEGORY");
            this.Property(t => t.ORDERUNIT).HasColumnName("ORDERUNIT");
            this.Property(t => t.ISSUEUNIT).HasColumnName("ISSUEUNIT");
            this.Property(t => t.ORDERQTY).HasColumnName("ORDERQTY");
            this.Property(t => t.LASTISSUEDATE).HasColumnName("LASTISSUEDATE");
            this.Property(t => t.ISSUEYTD).HasColumnName("ISSUEYTD");
            this.Property(t => t.ISSUE1YRAGO).HasColumnName("ISSUE1YRAGO");
            this.Property(t => t.ISSUE2YRAGO).HasColumnName("ISSUE2YRAGO");
            this.Property(t => t.ISSUE3YRAGO).HasColumnName("ISSUE3YRAGO");
            this.Property(t => t.ABCTYPE).HasColumnName("ABCTYPE");
            this.Property(t => t.CCF).HasColumnName("CCF");
            this.Property(t => t.SSTOCK).HasColumnName("SSTOCK");
            this.Property(t => t.DELIVERYTIME).HasColumnName("DELIVERYTIME");
            this.Property(t => t.IL1).HasColumnName("IL1");
            this.Property(t => t.IL2).HasColumnName("IL2");
            this.Property(t => t.IL3).HasColumnName("IL3");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.CONTROLACC).HasColumnName("CONTROLACC");
            this.Property(t => t.SHRINKAGEACC).HasColumnName("SHRINKAGEACC");
            this.Property(t => t.INVCOSTADJACC).HasColumnName("INVCOSTADJACC");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.INTERNAL).HasColumnName("INTERNAL");
            this.Property(t => t.INVENTORYID).HasColumnName("INVENTORYID");
            this.Property(t => t.ITEMSETID).HasColumnName("ITEMSETID");
            this.Property(t => t.STORELOC).HasColumnName("STORELOC");
            this.Property(t => t.STORELOCSITEID).HasColumnName("STORELOCSITEID");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
        }
    }
}
