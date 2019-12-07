using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class ASSETMap : EntityTypeConfiguration<ASSET>
    {
        public ASSETMap()
        {
            // Primary Key
            this.HasKey(t => t.C_ASSETNUM_LOCAL_);

            // Navigation
            this.HasMany(t => t.AssetSpecs)
                .WithRequired(a => a.Asset)
                .HasForeignKey(a => a.C_ASSETNUM_LOCAL_);
                 
            // Properties
            this.Property(t => t.ANCESTOR)
                .HasMaxLength(12);

            this.Property(t => t.ASSETNUM)
                .HasMaxLength(12);
            
            this.Property(t => t.ASSETTAG)
                .HasMaxLength(18);

            this.Property(t => t.ASSETTYPE)
                .HasMaxLength(25);

            this.Property(t => t.BINNUM)
                .HasMaxLength(8);

            this.Property(t => t.CALNUM)
                .HasMaxLength(8);

            this.Property(t => t.CHANGEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.CLASSSTRUCTUREID)
                .HasMaxLength(20);

            this.Property(t => t.CONDITIONCODE)
                .HasMaxLength(30);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(254);

            this.Property(t => t.EQ1)
                .HasMaxLength(25);

            this.Property(t => t.EQ10)
                .HasMaxLength(14);

            this.Property(t => t.EQ11)
                .HasMaxLength(10);

            this.Property(t => t.EQ12)
                .HasMaxLength(10);

            this.Property(t => t.EQ2)
                .HasMaxLength(18);

            this.Property(t => t.EQ3)
                .HasMaxLength(254);

            this.Property(t => t.EQ4)
                .HasMaxLength(10);

            this.Property(t => t.EQ7)
                .HasMaxLength(10);

            this.Property(t => t.EQ8)
                .HasMaxLength(10);

            this.Property(t => t.EQ9)
                .HasMaxLength(10);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.FAILURECODE)
                .HasMaxLength(10);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.GROUPNAME)
                .HasMaxLength(10);

            this.Property(t => t.ITEMNUM)
                .HasMaxLength(15);

            this.Property(t => t.ITEMSETID)
                .HasMaxLength(10);

            this.Property(t => t.ITEMTYPE)
                .HasMaxLength(15);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.LOCATION)
                .HasMaxLength(12);

            this.Property(t => t.MANUFACTURER)
                .HasMaxLength(12);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.PARENT)
                .HasMaxLength(12);

            this.Property(t => t.ROTSUSPACCT)
                .HasMaxLength(30);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.SERIALNUM)
                .HasMaxLength(30);

            this.Property(t => t.SHIFTNUM)
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.STATUS)
                .HasMaxLength(20);

            this.Property(t => t.TOOLCONTROLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.USAGE)
                .HasMaxLength(15);

            this.Property(t => t.VENDOR)
                .HasMaxLength(12);

            this.Property(t => t.EQ13)
                .HasMaxLength(10);

            this.Property(t => t.EQ14)
                .HasMaxLength(30);

            this.Property(t => t.EQ15)
                .HasMaxLength(10);

            this.Property(t => t.EQ16)
                .HasMaxLength(100);

            this.Property(t => t.MAPNUM)
                .HasMaxLength(23);

            this.Property(t => t.GLOBALID)
                .HasMaxLength(38);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.DIRECTION)
                .HasMaxLength(30);

            this.Property(t => t.ENDDESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.STARTDESCRIPTION)
                .HasMaxLength(100);

            this.Property(t => t.LRM)
                .HasMaxLength(25);

            this.Property(t => t.PLUSSFEATURECLASS)
                .HasMaxLength(100);

            this.Property(t => t.PLUSSADDRESSCODE)
                .HasMaxLength(12);

            this.Property(t => t.DEFAULTREPFACSITEID)
                .HasMaxLength(8);

            this.Property(t => t.DEFAULTREPFAC)
                .HasMaxLength(12);

            this.Property(t => t.TLOAMHASH)
                .HasMaxLength(192);

            this.Property(t => t.PLUSCASSETDEPT)
                .HasMaxLength(80);

            this.Property(t => t.PLUSCCLASS)
                .HasMaxLength(12);

            this.Property(t => t.PLUSCISCONDESC)
                .HasMaxLength(250);

            this.Property(t => t.PLUSCISMTECLASS)
                .HasMaxLength(80);

            this.Property(t => t.PLUSCLOOPNUM)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCMODELNUM)
                .HasMaxLength(20);

            this.Property(t => t.PLUSCOPRGEEU)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCOPRGEFROM)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCOPRGETO)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCPHYLOC)
                .HasMaxLength(250);

            this.Property(t => t.PLUSCSUMDIR)
                .HasMaxLength(12);

            this.Property(t => t.PLUSCSUMEU)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCSUMREAD)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCSUMSPAN)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCSUMURV)
                .HasMaxLength(15);

            this.Property(t => t.PLUSCVENDOR)
                .HasMaxLength(12);

            this.Property(t => t.TEMPLATEID)
                .HasMaxLength(12);
            
            this.Property(t => t.PLUSCLPLOC)
                    .HasMaxLength(12);
            
            this.Property(t => t.SADDRESSCODE)
                    .HasMaxLength(12);

            this.Property(t => t.GEOWORXSYNCID)
                    .HasMaxLength(12);
            this.Property(t => t.C_mobile_asset_type_)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("ASSET");
            this.Property(t => t.C_ASSETNUM_LOCAL_).HasColumnName("_ASSETNUM_LOCAL_");
            this.Property(t => t.ANCESTOR).HasColumnName("ANCESTOR");
            this.Property(t => t.ASSETID).HasColumnName("ASSETID");
            this.Property(t => t.ASSETNUM).HasColumnName("ASSETNUM");
            this.Property(t => t.ASSETTAG).HasColumnName("ASSETTAG");
            this.Property(t => t.ASSETTYPE).HasColumnName("ASSETTYPE");
            this.Property(t => t.ASSETUID).HasColumnName("ASSETUID");
            this.Property(t => t.AUTOWOGEN).HasColumnName("AUTOWOGEN");
            this.Property(t => t.BINNUM).HasColumnName("BINNUM");
            this.Property(t => t.BUDGETCOST).HasColumnName("BUDGETCOST");
            this.Property(t => t.CALNUM).HasColumnName("CALNUM");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.CHILDREN).HasColumnName("CHILDREN");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.CONDITIONCODE).HasColumnName("CONDITIONCODE");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.DISABLED).HasColumnName("DISABLED");
            this.Property(t => t.EQ1).HasColumnName("EQ1");
            this.Property(t => t.EQ10).HasColumnName("EQ10");
            this.Property(t => t.EQ11).HasColumnName("EQ11");
            this.Property(t => t.EQ12).HasColumnName("EQ12");
            this.Property(t => t.EQ2).HasColumnName("EQ2");
            this.Property(t => t.EQ23).HasColumnName("EQ23");
            this.Property(t => t.EQ24).HasColumnName("EQ24");
            this.Property(t => t.EQ3).HasColumnName("EQ3");
            this.Property(t => t.EQ4).HasColumnName("EQ4");
            this.Property(t => t.EQ5).HasColumnName("EQ5");
            this.Property(t => t.EQ6).HasColumnName("EQ6");
            this.Property(t => t.EQ7).HasColumnName("EQ7");
            this.Property(t => t.EQ8).HasColumnName("EQ8");
            this.Property(t => t.EQ9).HasColumnName("EQ9");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.FAILURECODE).HasColumnName("FAILURECODE");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.GROUPNAME).HasColumnName("GROUPNAME");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.INSTALLDATE).HasColumnName("INSTALLDATE");
            this.Property(t => t.INVCOST).HasColumnName("INVCOST");
            this.Property(t => t.ISRUNNING).HasColumnName("ISRUNNING");
            this.Property(t => t.ITEMNUM).HasColumnName("ITEMNUM");
            this.Property(t => t.ITEMSETID).HasColumnName("ITEMSETID");
            this.Property(t => t.ITEMTYPE).HasColumnName("ITEMTYPE");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.MAINTHIERCHY).HasColumnName("MAINTHIERCHY");
            this.Property(t => t.MANUFACTURER).HasColumnName("MANUFACTURER");
            this.Property(t => t.MOVED).HasColumnName("MOVED");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.PARENT).HasColumnName("PARENT");
            this.Property(t => t.PRIORITY).HasColumnName("PRIORITY");
            this.Property(t => t.PURCHASEPRICE).HasColumnName("PURCHASEPRICE");
            this.Property(t => t.REPLACECOST).HasColumnName("REPLACECOST");
            this.Property(t => t.ROTSUSPACCT).HasColumnName("ROTSUSPACCT");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.SERIALNUM).HasColumnName("SERIALNUM");
            this.Property(t => t.SHIFTNUM).HasColumnName("SHIFTNUM");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.TOOLCONTROLACCOUNT).HasColumnName("TOOLCONTROLACCOUNT");
            this.Property(t => t.TOOLRATE).HasColumnName("TOOLRATE");
            this.Property(t => t.TOTALCOST).HasColumnName("TOTALCOST");
            this.Property(t => t.TOTDOWNTIME).HasColumnName("TOTDOWNTIME");
            this.Property(t => t.TOTUNCHARGEDCOST).HasColumnName("TOTUNCHARGEDCOST");
            this.Property(t => t.UNCHARGEDCOST).HasColumnName("UNCHARGEDCOST");
            this.Property(t => t.USAGE).HasColumnName("USAGE");
            this.Property(t => t.VENDOR).HasColumnName("VENDOR");
            this.Property(t => t.WARRANTYEXPDATE).HasColumnName("WARRANTYEXPDATE");
            this.Property(t => t.YTDCOST).HasColumnName("YTDCOST");
            this.Property(t => t.EQ13).HasColumnName("EQ13");
            this.Property(t => t.EQ14).HasColumnName("EQ14");
            this.Property(t => t.EQ15).HasColumnName("EQ15");
            this.Property(t => t.EQ16).HasColumnName("EQ16");
            this.Property(t => t.EQ19).HasColumnName("EQ19");
            this.Property(t => t.EQ22).HasColumnName("EQ22");
            this.Property(t => t.MAPNUM).HasColumnName("MAPNUM");
            this.Property(t => t.FIXEDASSET).HasColumnName("FIXEDASSET");
            this.Property(t => t.X1).HasColumnName("X1");
            this.Property(t => t.X2).HasColumnName("X2");
            this.Property(t => t.Y1).HasColumnName("Y1");
            this.Property(t => t.Y2).HasColumnName("Y2");
            this.Property(t => t.GLOBALID).HasColumnName("GLOBALID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.DIRECTION).HasColumnName("DIRECTION");
            this.Property(t => t.ENDDESCRIPTION).HasColumnName("ENDDESCRIPTION");
            this.Property(t => t.ENDMEASURE).HasColumnName("ENDMEASURE");
            this.Property(t => t.ISLINEAR).HasColumnName("ISLINEAR");
            this.Property(t => t.STARTDESCRIPTION).HasColumnName("STARTDESCRIPTION");
            this.Property(t => t.STARTMEASURE).HasColumnName("STARTMEASURE");
            this.Property(t => t.LRM).HasColumnName("LRM");
            this.Property(t => t.PLUSSFEATURECLASS).HasColumnName("PLUSSFEATURECLASS");
            this.Property(t => t.PLUSSISGIS).HasColumnName("PLUSSISGIS");
            this.Property(t => t.PLUSSADDRESSCODE).HasColumnName("PLUSSADDRESSCODE");
            this.Property(t => t.DEFAULTREPFACSITEID).HasColumnName("DEFAULTREPFACSITEID");
            this.Property(t => t.DEFAULTREPFAC).HasColumnName("DEFAULTREPFAC");
            this.Property(t => t.RETURNEDTOVENDOR).HasColumnName("RETURNEDTOVENDOR");
            this.Property(t => t.TLOAMHASH).HasColumnName("TLOAMHASH");
            this.Property(t => t.TLOAMPARTITION).HasColumnName("TLOAMPARTITION");
            this.Property(t => t.PLUSCASSETDEPT).HasColumnName("PLUSCASSETDEPT");
            this.Property(t => t.PLUSCCLASS).HasColumnName("PLUSCCLASS");
            this.Property(t => t.PLUSCDUEDATE).HasColumnName("PLUSCDUEDATE");
            this.Property(t => t.PLUSCISCONDESC).HasColumnName("PLUSCISCONDESC");
            this.Property(t => t.PLUSCISCONTAM).HasColumnName("PLUSCISCONTAM");
            this.Property(t => t.PLUSCISINHOUSECAL).HasColumnName("PLUSCISINHOUSECAL");
            this.Property(t => t.PLUSCISMTE).HasColumnName("PLUSCISMTE");
            this.Property(t => t.PLUSCISMTECLASS).HasColumnName("PLUSCISMTECLASS");
            this.Property(t => t.PLUSCLOOPNUM).HasColumnName("PLUSCLOOPNUM");
            this.Property(t => t.PLUSCMODELNUM).HasColumnName("PLUSCMODELNUM");
            this.Property(t => t.PLUSCOPRGEEU).HasColumnName("PLUSCOPRGEEU");
            this.Property(t => t.PLUSCOPRGEFROM).HasColumnName("PLUSCOPRGEFROM");
            this.Property(t => t.PLUSCOPRGETO).HasColumnName("PLUSCOPRGETO");
            this.Property(t => t.PLUSCPHYLOC).HasColumnName("PLUSCPHYLOC");
            this.Property(t => t.PLUSCPMEXTDATE).HasColumnName("PLUSCPMEXTDATE");
            this.Property(t => t.PLUSCSOLUTION).HasColumnName("PLUSCSOLUTION");
            this.Property(t => t.PLUSCSUMDIR).HasColumnName("PLUSCSUMDIR");
            this.Property(t => t.PLUSCSUMEU).HasColumnName("PLUSCSUMEU");
            this.Property(t => t.PLUSCSUMREAD).HasColumnName("PLUSCSUMREAD");
            this.Property(t => t.PLUSCSUMSPAN).HasColumnName("PLUSCSUMSPAN");
            this.Property(t => t.PLUSCSUMURV).HasColumnName("PLUSCSUMURV");
            this.Property(t => t.PLUSCVENDOR).HasColumnName("PLUSCVENDOR");
            this.Property(t => t.ISCALIBRATION).HasColumnName("ISCALIBRATION");
            this.Property(t => t.TEMPLATEID).HasColumnName("TEMPLATEID");
            this.Property(t => t.PLUSCLPLOC).HasColumnName("PLUSCLPLOC");
            this.Property(t => t.SADDRESSCODE).HasColumnName("SADDRESSCODE");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
            this.Property(t => t.C_mobile_asset_type_).HasColumnName("_mobile_asset_type_");
            this.Property(t => t.GEOWORXSYNCID).HasColumnName("GEOWORXSYNCID");
        }
    }
}
