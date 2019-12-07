using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class LABTRANMap : EntityTypeConfiguration<LABTRAN>
    {
        public LABTRANMap()
        {
            // Primary Key
            this.HasKey(t => t.C_LABTRANSID_LOCAL_);

            // Properties
            //this.Property(t => t.C_LABTRANSID_LOCAL_)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(t => t.TRANSDATE)
                .IsRequired();

            this.Property(t => t.LABORCODE)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.CRAFT)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.PAYRATE)
                .IsRequired();

            this.Property(t => t.REGULARHRS)
                .IsRequired();

            this.Property(t => t.ENTERBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ENTERDATE)
                .IsRequired();

            this.Property(t => t.LTWO1)
                .HasMaxLength(14);

            this.Property(t => t.LT7)
                .IsRequired();

            this.Property(t => t.STARTDATE)
                .IsRequired();

            this.Property(t => t.TRANSTYPE)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.OUTSIDE)
                .IsRequired();

            this.Property(t => t.MEMO)
                .HasMaxLength(100);

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

            this.Property(t => t.PONUM)
                .HasMaxLength(8);

            this.Property(t => t.LOCATION)
                .HasMaxLength(12);

            this.Property(t => t.GENAPPRSERVRECEIPT)
                .IsRequired();

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

            this.Property(t => t.CONTRACTNUM)
                .HasMaxLength(8);

            this.Property(t => t.INVOICENUM)
                .HasMaxLength(8);

            this.Property(t => t.PREMIUMPAYCODE)
                .HasMaxLength(25);

            this.Property(t => t.PREMIUMPAYRATETYPE)
                .HasMaxLength(10);

            this.Property(t => t.SKILLLEVEL)
                .HasMaxLength(15);

            this.Property(t => t.TICKETCLASS)
                .HasMaxLength(16);

            this.Property(t => t.TICKETID)
                .HasMaxLength(10);

            this.Property(t => t.TIMERSTATUS)
                .HasMaxLength(16);

            this.Property(t => t.VENDOR)
                .HasMaxLength(12);

            this.Property(t => t.CREWWORKGROUP)
                .HasMaxLength(11);
            this.Property(t => t.AMCREW)
                .HasMaxLength(8);
            this.Property(t => t.AMCREWTYPE)
                .HasMaxLength(8);
            this.Property(t => t.POSITION)
                .HasMaxLength(20);

            this.Property(t => t.DCW_TRUCKDRIVER)
                .IsRequired();

            this.Property(t => t.DCW_TRUCKLEAD)
                .IsRequired();

            this.Property(t => t.DCW_TRUCKNUM)
                .HasMaxLength(15);

            this.Property(t => t.DCW_TRUCKSECOND)
                .IsRequired();


            // Table & Column Mappings
            this.ToTable("LABTRANS");
            this.Property(t => t.C_LABTRANSID_LOCAL_).HasColumnName("_LABTRANSID_LOCAL_");
            this.Property(t => t.C_REFWO_LOCAL_).HasColumnName("_REFWO_LOCAL_");
            this.Property(t => t.C_ASSETNUM_LOCAL_).HasColumnName("_ASSETNUM_LOCAL_");
            this.Property(t => t.TRANSDATE).HasColumnName("TRANSDATE");
            this.Property(t => t.LABORCODE).HasColumnName("LABORCODE");
            this.Property(t => t.CRAFT).HasColumnName("CRAFT");
            this.Property(t => t.PAYRATE).HasColumnName("PAYRATE");
            this.Property(t => t.REGULARHRS).HasColumnName("REGULARHRS");
            this.Property(t => t.ENTERBY).HasColumnName("ENTERBY");
            this.Property(t => t.ENTERDATE).HasColumnName("ENTERDATE");
            this.Property(t => t.LTWO1).HasColumnName("LTWO1");
            this.Property(t => t.LT7).HasColumnName("LT7");
            this.Property(t => t.STARTDATE).HasColumnName("STARTDATE");
            this.Property(t => t.STARTTIME).HasColumnName("STARTTIME");
            this.Property(t => t.FINISHDATE).HasColumnName("FINISHDATE");
            this.Property(t => t.FINISHTIME).HasColumnName("FINISHTIME");
            this.Property(t => t.TRANSTYPE).HasColumnName("TRANSTYPE");
            this.Property(t => t.OUTSIDE).HasColumnName("OUTSIDE");
            this.Property(t => t.MEMO).HasColumnName("MEMO");
            this.Property(t => t.ROLLUP).HasColumnName("ROLLUP");
            this.Property(t => t.GLDEBITACCT).HasColumnName("GLDEBITACCT");
            this.Property(t => t.LINECOST).HasColumnName("LINECOST");
            this.Property(t => t.GLCREDITACCT).HasColumnName("GLCREDITACCT");
            this.Property(t => t.FINANCIALPERIOD).HasColumnName("FINANCIALPERIOD");
            this.Property(t => t.PONUM).HasColumnName("PONUM");
            this.Property(t => t.POLINENUM).HasColumnName("POLINENUM");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.GENAPPRSERVRECEIPT).HasColumnName("GENAPPRSERVRECEIPT");
            this.Property(t => t.PAYMENTTRANSDATE).HasColumnName("PAYMENTTRANSDATE");
            this.Property(t => t.EXCHANGERATE2).HasColumnName("EXCHANGERATE2");
            this.Property(t => t.LINECOST2).HasColumnName("LINECOST2");
            this.Property(t => t.LABTRANSID).HasColumnName("LABTRANSID");
            this.Property(t => t.SERVRECTRANSID).HasColumnName("SERVRECTRANSID");
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
            this.Property(t => t.CONTRACTNUM).HasColumnName("CONTRACTNUM");
            this.Property(t => t.INVOICELINENUM).HasColumnName("INVOICELINENUM");
            this.Property(t => t.INVOICENUM).HasColumnName("INVOICENUM");
            this.Property(t => t.PREMIUMPAYCODE).HasColumnName("PREMIUMPAYCODE");
            this.Property(t => t.PREMIUMPAYHOURS).HasColumnName("PREMIUMPAYHOURS");
            this.Property(t => t.PREMIUMPAYRATE).HasColumnName("PREMIUMPAYRATE");
            this.Property(t => t.PREMIUMPAYRATETYPE).HasColumnName("PREMIUMPAYRATETYPE");
            this.Property(t => t.REVISIONNUM).HasColumnName("REVISIONNUM");
            this.Property(t => t.SKILLLEVEL).HasColumnName("SKILLLEVEL");
            this.Property(t => t.TICKETCLASS).HasColumnName("TICKETCLASS");
            this.Property(t => t.TICKETID).HasColumnName("TICKETID");
            this.Property(t => t.TIMERSTATUS).HasColumnName("TIMERSTATUS");
            this.Property(t => t.VENDOR).HasColumnName("VENDOR");
            this.Property(t => t.POREVISIONNUM).HasColumnName("POREVISIONNUM");
            this.Property(t => t.CREWWORKGROUP).HasColumnName("CREWWORKGROUP");
            this.Property(t => t.AMCREW).HasColumnName("AMCREW");
            this.Property(t => t.AMCREWTYPE).HasColumnName("AMCREWTYPE");
            this.Property(t => t.POSITION).HasColumnName("POSITION");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
            this.Property(t => t.DCW_TRUCKLEAD).HasColumnName("DCW_TRUCKLEAD");
            this.Property(t => t.DCW_TRUCKSECOND).HasColumnName("DCW_TRUCKSECOND");
            this.Property(t => t.DCW_TRUCKDRIVER).HasColumnName("DCW_TRUCKDRIVER");
            this.Property(t => t.DCW_TRUCKNUM).HasColumnName("DCW_TRUCKNUM");
        }
    }
}
