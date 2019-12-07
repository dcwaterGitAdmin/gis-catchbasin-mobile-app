using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class LOCATIONMap : EntityTypeConfiguration<LOCATION>
    {
        public LOCATIONMap()
        {
            // Primary Key
            this.HasKey(t => t.LOCATIONSID);

  
            // Properties
            this.Property(t => t.LOCATIONSID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LOCATION_)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(254);

            this.Property(t => t.TYPE)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.CONTROLACC)
                .HasMaxLength(30);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.PURCHVARACC)
                .HasMaxLength(30);

            this.Property(t => t.INVOICEVARACC)
                .HasMaxLength(30);

            this.Property(t => t.CURVARACC)
                .HasMaxLength(30);

            this.Property(t => t.SHRINKAGEACC)
                .HasMaxLength(30);

            this.Property(t => t.INVCOSTADJACC)
                .HasMaxLength(30);

            this.Property(t => t.RECEIPTVARACC)
                .HasMaxLength(30);

            this.Property(t => t.CHANGEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.LO1)
                .HasMaxLength(10);

            this.Property(t => t.LO2)
                .HasMaxLength(10);

            this.Property(t => t.LO4)
                .HasMaxLength(10);

            this.Property(t => t.LO5)
                .HasMaxLength(10);

            this.Property(t => t.OLDCONTROLACC)
                .HasMaxLength(30);

            this.Property(t => t.OLDSHRINKAGEACC)
                .HasMaxLength(30);

            this.Property(t => t.OLDINVCOSTADJACC)
                .HasMaxLength(30);

            this.Property(t => t.CLASSSTRUCTUREID)
                .HasMaxLength(20);

            this.Property(t => t.GISPARAM1)
                .HasMaxLength(1);

            this.Property(t => t.GISPARAM2)
                .HasMaxLength(1);

            this.Property(t => t.GISPARAM3)
                .HasMaxLength(1);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.SITEID)
                .HasMaxLength(8);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.INTLABREC)
                .HasMaxLength(30);

            this.Property(t => t.SHIPTOADDRESSCODE)
                .HasMaxLength(30);

            this.Property(t => t.SHIPTOLABORCODE)
                .HasMaxLength(30);

            this.Property(t => t.BILLTOADDRESSCODE)
                .HasMaxLength(30);

            this.Property(t => t.BILLTOLABORCODE)
                .HasMaxLength(30);

            this.Property(t => t.PREMISESTATUS)
                .HasMaxLength(10);

            this.Property(t => t.CUSTOMERNUM)
                .HasMaxLength(10);

            this.Property(t => t.ACCOUNTNUM)
                .HasMaxLength(10);

            this.Property(t => t.QUAD)
                .HasMaxLength(10);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.SERVICEADDRESSCODE)
                .HasMaxLength(30);

            this.Property(t => t.STATUS)
                .HasMaxLength(20);

            this.Property(t => t.TOOLCONTROLACC)
                .HasMaxLength(30);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.PLUSSFEATURECLASS)
                .HasMaxLength(100);

            this.Property(t => t.PLUSSADDRESSCODE)
                .HasMaxLength(12);

            this.Property(t => t.INVOWNER)
                .HasMaxLength(30);

            this.Property(t => t.SADDRESSCODE)
                .HasMaxLength(12);

            this.Property(t => t.GEOWORXSYNCID)
                .HasMaxLength(12);


            // Table & Column Mappings
            this.ToTable("LOCATIONS");
            this.Property(t => t.LOCATION_).HasColumnName("LOCATION");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.TYPE).HasColumnName("TYPE");
            this.Property(t => t.CONTROLACC).HasColumnName("CONTROLACC");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.PURCHVARACC).HasColumnName("PURCHVARACC");
            this.Property(t => t.INVOICEVARACC).HasColumnName("INVOICEVARACC");
            this.Property(t => t.CURVARACC).HasColumnName("CURVARACC");
            this.Property(t => t.SHRINKAGEACC).HasColumnName("SHRINKAGEACC");
            this.Property(t => t.INVCOSTADJACC).HasColumnName("INVCOSTADJACC");
            this.Property(t => t.RECEIPTVARACC).HasColumnName("RECEIPTVARACC");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.LO1).HasColumnName("LO1");
            this.Property(t => t.LO2).HasColumnName("LO2");
            this.Property(t => t.LO4).HasColumnName("LO4");
            this.Property(t => t.LO5).HasColumnName("LO5");
            this.Property(t => t.DISABLED).HasColumnName("DISABLED");
            this.Property(t => t.OLDCONTROLACC).HasColumnName("OLDCONTROLACC");
            this.Property(t => t.OLDSHRINKAGEACC).HasColumnName("OLDSHRINKAGEACC");
            this.Property(t => t.OLDINVCOSTADJACC).HasColumnName("OLDINVCOSTADJACC");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.GISPARAM1).HasColumnName("GISPARAM1");
            this.Property(t => t.GISPARAM2).HasColumnName("GISPARAM2");
            this.Property(t => t.GISPARAM3).HasColumnName("GISPARAM3");
            this.Property(t => t.LO15).HasColumnName("LO15");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.INTLABREC).HasColumnName("INTLABREC");
            this.Property(t => t.ISDEFAULT).HasColumnName("ISDEFAULT");
            this.Property(t => t.SHIPTOADDRESSCODE).HasColumnName("SHIPTOADDRESSCODE");
            this.Property(t => t.SHIPTOLABORCODE).HasColumnName("SHIPTOLABORCODE");
            this.Property(t => t.BILLTOADDRESSCODE).HasColumnName("BILLTOADDRESSCODE");
            this.Property(t => t.BILLTOLABORCODE).HasColumnName("BILLTOLABORCODE");
            this.Property(t => t.PREMISESTATUS).HasColumnName("PREMISESTATUS");
            this.Property(t => t.CUSTOMERNUM).HasColumnName("CUSTOMERNUM");
            this.Property(t => t.ACCOUNTNUM).HasColumnName("ACCOUNTNUM");
            this.Property(t => t.QUAD).HasColumnName("QUAD");
            this.Property(t => t.AUTOWOGEN).HasColumnName("AUTOWOGEN");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.LOCATIONSID).HasColumnName("LOCATIONSID");
            this.Property(t => t.SERVICEADDRESSCODE).HasColumnName("SERVICEADDRESSCODE");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.TOOLCONTROLACC).HasColumnName("TOOLCONTROLACC");
            this.Property(t => t.USEINPOPR).HasColumnName("USEINPOPR");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DCW_MATLMGMTCTRLD).HasColumnName("DCW_MATLMGMTCTRLD");
            this.Property(t => t.INVOWNER).HasColumnName("INVOWNER");
            this.Property(t => t.ISREPAIRFACILITY).HasColumnName("ISREPAIRFACILITY");
            this.Property(t => t.PLUSCDUEDATE).HasColumnName("PLUSCDUEDATE");
            this.Property(t => t.PLUSCLOOP).HasColumnName("PLUSCLOOP");
            this.Property(t => t.PLUSCPMEXTDATE).HasColumnName("PLUSCPMEXTDATE");
            this.Property(t => t.SADDRESSCODE).HasColumnName("SADDRESSCODE");
            this.Property(t => t.PLUSSFEATURECLASS).HasColumnName("PLUSSFEATURECLASS");
            this.Property(t => t.PLUSSISGIS).HasColumnName("PLUSSISGIS");
            this.Property(t => t.PLUSSADDRESSCODE).HasColumnName("PLUSSADDRESSCODE");
            this.Property(t => t.GEOWORXSYNCID).HasColumnName("GEOWORXSYNCID");
        }
    }
}
