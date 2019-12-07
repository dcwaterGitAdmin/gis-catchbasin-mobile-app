using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class TOOLTRANMap : EntityTypeConfiguration<TOOLTRAN>
    {
        public TOOLTRANMap()
        {
            // Primary Key
            this.HasKey(t => t.C_TOOLTRANSID_LOCAL_);

            // Properties
            //this.Property(t => t.C_TOOLTRANSID_LOCAL_)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ENTERBY)
                .IsRequired()
                .HasMaxLength(30);
            this.Property(t => t.TRANSDATE)
                .IsRequired();
            this.Property(t => t.TOOLRATE)
                .IsRequired();
            this.Property(t => t.TOOLQTY)
                 .IsRequired();
            this.Property(t => t.ENTERDATE)
                 .IsRequired();
            this.Property(t => t.ENTERBY)
                 .IsRequired();
            this.Property(t => t.OUTSIDE)
                 .IsRequired();
            this.Property(t => t.ROLLUP)
                 .IsRequired();
            this.Property(t => t.GLDEBITACCT)
                .HasMaxLength(30);
            this.Property(t => t.LINECOST)
                 .IsRequired();
            this.Property(t => t.GLCREDITACCT)
                .HasMaxLength(30);

            this.Property(t => t.FINANCIALPERIOD)
                .HasMaxLength(6);

            this.Property(t => t.LOCATION)
                .HasMaxLength(12);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.FINCNTRLID)
                .HasMaxLength(8);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.REFWO)
                .HasMaxLength(10);
            this.Property(t => t.ENTEREDASTASK)
                .IsRequired();

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.ASSETNUM)
                .HasMaxLength(12);

            this.Property(t => t.ITEMNUM)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.ITEMSETID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ROTASSETNUM)
                .HasMaxLength(12);

            this.Property(t => t.ROTASSETSITE)
                .HasMaxLength(8);

            this.Property(t => t.PLUSCCOMMENT)
                .HasMaxLength(250);
            this.Property(t => t.PLUSCLOTNUM)
                .HasMaxLength(8);
            this.Property(t => t.PLUSCMANUFACTURER)
                .HasMaxLength(12);
            this.Property(t => t.PLUSCTECHNICIAN)
                .HasMaxLength(30);
            this.Property(t => t.PLUSCTYPE)
                .HasMaxLength(30);
            this.Property(t => t.HASLD)
                .IsRequired();
            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);
            this.Property(t => t.AMCREW)
                .HasMaxLength(8);
            this.Property(t => t.TOOLSQ)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("TOOLTRANS");
            this.Property(t => t.C_TOOLTRANSID_LOCAL_).HasColumnName("_TOOLTRANSID_LOCAL_");
            this.Property(t => t.C_REFWO_LOCAL_).HasColumnName("_REFWO_LOCAL_");
            this.Property(t => t.C_ASSETNUM_LOCAL_).HasColumnName("_ASSETNUM_LOCAL_");
            this.Property(t => t.TRANSDATE).HasColumnName("TRANSDATE");
            this.Property(t => t.TOOLRATE).HasColumnName("TOOLRATE");
            this.Property(t => t.TOOLQTY).HasColumnName("TOOLQTY");
            this.Property(t => t.TOOLHRS).HasColumnName("TOOLHRS");
            this.Property(t => t.ENTERDATE).HasColumnName("ENTERDATE");
            this.Property(t => t.ENTERBY).HasColumnName("ENTERBY");
            this.Property(t => t.OUTSIDE).HasColumnName("OUTSIDE");
            this.Property(t => t.ROLLUP).HasColumnName("ROLLUP");
            this.Property(t => t.GLDEBITACCT).HasColumnName("GLDEBITACCT");
            this.Property(t => t.LINECOST).HasColumnName("LINECOST");
            this.Property(t => t.GLCREDITACCT).HasColumnName("GLCREDITACCT");
            this.Property(t => t.FINANCIALPERIOD).HasColumnName("FINANCIALPERIOD");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.EXCHANGERATE2).HasColumnName("EXCHANGERATE2");
            this.Property(t => t.LINECOST2).HasColumnName("LINECOST2");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.FINCNTRLID).HasColumnName("FINCNTRLID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.REFWO).HasColumnName("REFWO");
            this.Property(t => t.ENTEREDASTASK).HasColumnName("ENTEREDASTASK");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.ASSETNUM).HasColumnName("ASSETNUM");
            this.Property(t => t.ITEMNUM).HasColumnName("ITEMNUM");
            this.Property(t => t.ITEMSETID).HasColumnName("ITEMSETID");
            this.Property(t => t.ROTASSETNUM).HasColumnName("ROTASSETNUM");
            this.Property(t => t.ROTASSETSITE).HasColumnName("ROTASSETSITE");
            this.Property(t => t.TOOLTRANSID).HasColumnName("TOOLTRANSID");
            this.Property(t => t.PLUSCCOMMENT).HasColumnName("PLUSCCOMMENT");
            this.Property(t => t.PLUSCDUEDATE).HasColumnName("PLUSCDUEDATE");
            this.Property(t => t.PLUSCEXPIRYDATE).HasColumnName("PLUSCEXPIRYDATE");
            this.Property(t => t.PLUSCLOTNUM).HasColumnName("PLUSCLOTNUM");
            this.Property(t => t.PLUSCMANUFACTURER).HasColumnName("PLUSCMANUFACTURER");
            this.Property(t => t.PLUSCTECHNICIAN).HasColumnName("PLUSCTECHNICIAN");
            this.Property(t => t.PLUSCTOOLUSEDATE).HasColumnName("PLUSCTOOLUSEDATE");
            this.Property(t => t.PLUSCTYPE).HasColumnName("PLUSCTYPE");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.AMCREW).HasColumnName("AMCREW");
            this.Property(t => t.TOOLSQ).HasColumnName("TOOLSQ"); 
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
