using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class WORKORDERMap : EntityTypeConfiguration<WORKORDER>
    {
        public WORKORDERMap()
        {
            // Primary Key
            this.HasKey(t => t.C_WORKORDERID_LOCAL_);

            // Workorder Spec
            this.HasMany(t => t.WorkorderSpecs)
                .WithRequired(w => w.Workorder)
                .HasForeignKey(w => w.C_WORKORDERID_LOCAL_)
                .WillCascadeOnDelete();

            // Doclinks
            this.HasMany(t => t.Doclinks)
                .WithRequired(d => d.Workorder)
                .HasForeignKey(d => d.C_OWNERID_LOCAL_)
                .WillCascadeOnDelete();

            // LabTrans
            this.HasMany(t => t.LabTrans)
                .WithRequired(l => l.Workorder)
                .HasForeignKey(l => l.C_REFWO_LOCAL_)
                .WillCascadeOnDelete();

            // ToolTrans
            this.HasMany(t => t.ToolTrans)
                .WithRequired(t => t.Workorder)
                .HasForeignKey(t => t.C_REFWO_LOCAL_)
                .WillCascadeOnDelete();

            // Asset
            this.HasOptional(t => t.Asset)
                .WithMany()
                .HasForeignKey(t => t.C_ASSETNUM_LOCAL)
                .WillCascadeOnDelete(false);

            //FailureReport
            this.HasMany(t => t.FailureReports)
                .WithRequired(f => f.Workorder)
                .HasForeignKey(f => f.C_WONUM_LOCAL_)
                .WillCascadeOnDelete(true);

            //Originator
            this.HasOptional(t => t.Originator)
                .WithMany()
                .HasForeignKey(t => t.C_ORIGRECORDID_LOCAL_)
                .WillCascadeOnDelete(false);

            // Properties
            this.Property(t => t.WONUM)
                .HasMaxLength(10);

            this.Property(t => t.PARENT)
                .HasMaxLength(10);

            this.Property(t => t.STATUS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.WORKTYPE)
                .HasMaxLength(5);

            this.Property(t => t.LEADCRAFT)
                .HasMaxLength(12);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(254);

            this.Property(t => t.LOCATION)
                .HasMaxLength(12);

            this.Property(t => t.JPNUM)
                .HasMaxLength(20);

            this.Property(t => t.CHANGEBY)
                .HasMaxLength(30);

            this.Property(t => t.PMNUM)
                .HasMaxLength(20);

            this.Property(t => t.CONTRACT)
                .HasMaxLength(8);

            this.Property(t => t.WOEQ1)
                .HasMaxLength(25);

            this.Property(t => t.WOEQ2)
                .HasMaxLength(18);

            this.Property(t => t.WOEQ3)
                .HasMaxLength(254);

            this.Property(t => t.WOEQ4)
                .HasMaxLength(10);

            this.Property(t => t.WOEQ7)
                .HasMaxLength(10);

            this.Property(t => t.WOEQ8)
                .HasMaxLength(10);

            this.Property(t => t.WOEQ9)
                .HasMaxLength(10);

            this.Property(t => t.WOEQ10)
                .HasMaxLength(14);

            this.Property(t => t.WOEQ11)
                .HasMaxLength(10);

            this.Property(t => t.WOEQ12)
                .HasMaxLength(10);

            this.Property(t => t.WO1)
                .HasMaxLength(10);

            this.Property(t => t.WO3)
                .HasMaxLength(10);

            this.Property(t => t.WO4)
                .HasMaxLength(10);

            this.Property(t => t.WO7)
                .HasMaxLength(20);

            this.Property(t => t.WO9)
                .HasMaxLength(10);

            this.Property(t => t.WO10)
                .HasMaxLength(10);

            this.Property(t => t.REPORTEDBY)
                .HasMaxLength(62);

            this.Property(t => t.PHONE)
                .HasMaxLength(20);

            this.Property(t => t.PROBLEMCODE)
                .HasMaxLength(10);

            this.Property(t => t.CALENDAR)
                .HasMaxLength(8);

            this.Property(t => t.CREWID)
                .HasMaxLength(12);

            this.Property(t => t.SUPERVISOR)
                .HasMaxLength(30);

            this.Property(t => t.WOJP1)
                .HasMaxLength(10);

            this.Property(t => t.WOJP2)
                .HasMaxLength(10);

            this.Property(t => t.WOJP3)
                .HasMaxLength(10);

            this.Property(t => t.WOL1)
                .HasMaxLength(10);

            this.Property(t => t.WOL2)
                .HasMaxLength(10);

            this.Property(t => t.WOLABLNK)
                .HasMaxLength(12);

            this.Property(t => t.FAILURECODE)
                .HasMaxLength(10);

            this.Property(t => t.WOLO1)
                .HasMaxLength(10);

            this.Property(t => t.WOLO2)
                .HasMaxLength(25);

            this.Property(t => t.WOLO3)
                .HasMaxLength(50);

            this.Property(t => t.WOLO4)
                .HasMaxLength(100);

            this.Property(t => t.WOLO5)
                .HasMaxLength(50);

            this.Property(t => t.WOLO9)
                .HasMaxLength(10);

            this.Property(t => t.GLACCOUNT)
                .HasMaxLength(30);

            this.Property(t => t.WORTS1)
                .HasMaxLength(10);

            this.Property(t => t.WORTS2)
                .HasMaxLength(10);

            this.Property(t => t.WORTS3)
                .HasMaxLength(10);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.WORKLOCATION)
                .HasMaxLength(12);

            this.Property(t => t.WO11)
                .HasMaxLength(2);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.FINCNTRLID)
                .HasMaxLength(8);

            this.Property(t => t.GENERATEDFORPO)
                .HasMaxLength(8);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.INSPECTOR)
                .HasMaxLength(30);

            this.Property(t => t.OBSERVATION)
                .HasMaxLength(8);

            this.Property(t => t.POINTNUM)
                .HasMaxLength(8);

            this.Property(t => t.WOJO1)
                .HasMaxLength(10);

            this.Property(t => t.WOJO2)
                .HasMaxLength(10);

            this.Property(t => t.WOJO3)
                .HasMaxLength(10);

            this.Property(t => t.WOJO5)
                .HasMaxLength(10);

            this.Property(t => t.WOJO6)
                .HasMaxLength(10);

            this.Property(t => t.WOJO7)
                .HasMaxLength(10);

            this.Property(t => t.WOJO8)
                .HasMaxLength(10);

            this.Property(t => t.SERVICE)
                .HasMaxLength(4);

            this.Property(t => t.ORIGPROBLEMTYPE)
                .HasMaxLength(2);

            this.Property(t => t.CISNUM)
                .HasMaxLength(10);

            this.Property(t => t.MISSUTILITYNUM)
                .HasMaxLength(15);

            this.Property(t => t.MAPNUM)
                .HasMaxLength(23);

            this.Property(t => t.RECEIVEDVIA)
                .HasMaxLength(10);

            this.Property(t => t.LOCATIONDETAILS)
                .HasMaxLength(254);

            this.Property(t => t.OTHERCONTACT)
                .HasMaxLength(40);

            this.Property(t => t.WATERCOLOR)
                .HasMaxLength(10);

            this.Property(t => t.DISCOLORHOTCOLD)
                .HasMaxLength(4);

            this.Property(t => t.PARTICLECOLOR)
                .HasMaxLength(10);

            this.Property(t => t.TYPEODOR)
                .HasMaxLength(30);

            this.Property(t => t.MEDICALREPORT)
                .HasMaxLength(50);

            this.Property(t => t.CONNECTIONTYPE)
                .HasMaxLength(11);

            this.Property(t => t.PROBLEMBEGAN)
                .HasMaxLength(30);

            this.Property(t => t.PROBLEMLOC)
                .HasMaxLength(4);

            this.Property(t => t.LOCALIZEDWHERE)
                .HasMaxLength(254);

            this.Property(t => t.TYPETREATMENT)
                .HasMaxLength(20);

            this.Property(t => t.SAMPLELOCTYPE)
                .HasMaxLength(10);

            this.Property(t => t.CUTNUM)
                .HasMaxLength(16);

            this.Property(t => t.FINALPOSITION)
                .HasMaxLength(10);

            this.Property(t => t.WATERTASTEDESC)
                .HasMaxLength(50);

            this.Property(t => t.FUND)
                .HasMaxLength(10);

            this.Property(t => t.OUTLETDIA)
                .HasMaxLength(3);

            this.Property(t => t.PROBLEMSIDE)
                .HasMaxLength(10);

            this.Property(t => t.CUSTOMERSTREET)
                .HasMaxLength(60);

            this.Property(t => t.CUSTOMERCITY)
                .HasMaxLength(40);

            this.Property(t => t.CUSTOMERSTATE)
                .HasMaxLength(2);

            this.Property(t => t.CUSTOMERZIP)
                .HasMaxLength(10);

            this.Property(t => t.CUSTOMEREMAIL)
                .HasMaxLength(60);

            this.Property(t => t.ALTPHONEFAX)
                .HasMaxLength(25);

            this.Property(t => t.OTHERCOMPANY)
                .HasMaxLength(80);

            this.Property(t => t.PLUMBERNAME)
                .HasMaxLength(40);

            this.Property(t => t.PLUMBERLICNUM)
                .HasMaxLength(20);

            this.Property(t => t.SNAKELOC)
                .HasMaxLength(17);

            this.Property(t => t.CLEANOUTLOC)
                .HasMaxLength(10);

            this.Property(t => t.RUNNINGTRAPLOC)
                .HasMaxLength(10);

            this.Property(t => t.EQUIPMENTUSED)
                .HasMaxLength(50);

            this.Property(t => t.JUSTIFICATION)
                .HasMaxLength(254);

            this.Property(t => t.DEBRISDESC)
                .HasMaxLength(100);

            this.Property(t => t.WEATHERCOND)
                .HasMaxLength(10);

            this.Property(t => t.WINDS)
                .HasMaxLength(5);

            this.Property(t => t.ENGINEERCOMPANY)
                .HasMaxLength(80);

            this.Property(t => t.DEVELOPERCOMPANY)
                .HasMaxLength(80);

            this.Property(t => t.DEVELOPERCONTACT)
                .HasMaxLength(40);

            this.Property(t => t.DEVELOPERPHONE)
                .HasMaxLength(25);

            this.Property(t => t.AGENCYID)
                .HasMaxLength(5);

            this.Property(t => t.RECEIVEDAT)
                .HasMaxLength(5);

            this.Property(t => t.CONTRACTORCONTACT)
                .HasMaxLength(40);

            this.Property(t => t.ENUM)
                .HasMaxLength(10);

            this.Property(t => t.PIPETYPE)
                .HasMaxLength(15);

            this.Property(t => t.CONTRACTORPHONE)
                .HasMaxLength(25);

            this.Property(t => t.PROJECTTYPE)
                .HasMaxLength(10);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.ASSETNUM)
                .HasMaxLength(12);

            this.Property(t => t.BACKOUTPLAN)
                .HasMaxLength(50);

            this.Property(t => t.CLASSSTRUCTUREID)
                .HasMaxLength(20);

            this.Property(t => t.COMMODITY)
                .HasMaxLength(12);

            this.Property(t => t.COMMODITYGROUP)
                .HasMaxLength(12);

            this.Property(t => t.ENVIRONMENT)
                .HasMaxLength(50);

            this.Property(t => t.JUSTIFYPRIORITY)
                .HasMaxLength(50);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.LEAD)
                .HasMaxLength(30);

            this.Property(t => t.ONBEHALFOF)
                .HasMaxLength(62);

            this.Property(t => t.ORIGRECORDCLASS)
                .HasMaxLength(16);

            this.Property(t => t.ORIGRECORDID)
                .HasMaxLength(10);

            this.Property(t => t.OWNER)
                .HasMaxLength(30);

            this.Property(t => t.OWNERGROUP)
                .HasMaxLength(15);

            this.Property(t => t.PERSONGROUP)
                .HasMaxLength(15);

            this.Property(t => t.REASONFORCHANGE)
                .HasMaxLength(20);

            this.Property(t => t.RISK)
                .HasMaxLength(10);

            this.Property(t => t.VENDOR)
                .HasMaxLength(12);

            this.Property(t => t.VERIFICATION)
                .HasMaxLength(20);

            this.Property(t => t.WHOMISCHANGEFOR)
                .HasMaxLength(20);

            this.Property(t => t.WOCLASS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.WOGROUP)
                .HasMaxLength(10);

            this.Property(t => t.BKPCONTRACT)
                .HasMaxLength(8);

            this.Property(t => t.CINUM)
                .HasMaxLength(150);

            this.Property(t => t.FLOWACTION)
                .HasMaxLength(30);

            this.Property(t => t.LAUNCHENTRYNAME)
                .HasMaxLength(32);

            this.Property(t => t.NEWCHILDCLASS)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ROUTE)
                .HasMaxLength(20);

            this.Property(t => t.TARGETDESC)
                .HasMaxLength(50);

            this.Property(t => t.FIRSTAPPRSTATUS)
                .HasMaxLength(16);

            this.Property(t => t.PMCOMTYPE)
                .HasMaxLength(50);

            this.Property(t => t.PMCOMSTATE)
                .HasMaxLength(16);

            this.Property(t => t.PMCOMBPELACTNAME)
                .HasMaxLength(32);

            this.Property(t => t.CONPERMITNUM)
                .HasMaxLength(5);

            this.Property(t => t.OCCPERMITNUM)
                .HasMaxLength(8);

            this.Property(t => t.CALCORGID)
                .HasMaxLength(8);

            this.Property(t => t.CALCCALENDAR)
                .HasMaxLength(8);

            this.Property(t => t.CALCSHIFT)
                .HasMaxLength(8);

            this.Property(t => t.RESTORATIONREQD)
                .HasMaxLength(1);

            this.Property(t => t.DCW_SNAKEDIST2BLCKG)
                .HasMaxLength(20);

            this.Property(t => t.CONTRACTORJUSTIFICATION)
                .HasMaxLength(10);

            this.Property(t => t.PLUSSFEATURECLASS)
                .HasMaxLength(100);

            this.Property(t => t.REPFACSITEID)
                .HasMaxLength(8);

            this.Property(t => t.REPAIRFACILITY)
                .HasMaxLength(12);

            this.Property(t => t.STOREROOMMTLSTATUS)
                .HasMaxLength(20);

            this.Property(t => t.DIRISSUEMTLSTATUS)
                .HasMaxLength(20);

            this.Property(t => t.WORKPACKMTLSTATUS)
                .HasMaxLength(20);

            this.Property(t => t.ASSIGNEDOWNERGROUP)
                .HasMaxLength(11);

            this.Property(t => t.PLUSCFREQUNIT)
                .HasMaxLength(8);

            this.Property(t => t.PLUSCPHYLOC)
                .HasMaxLength(250);

            this.Property(t => t.AMCREW)
                .HasMaxLength(8);

            this.Property(t => t.CREWWORKGROUP)
                .HasMaxLength(11);
            this.Property(t => t.C_mobile_work_type_)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("WORKORDER");
            this.Property(t => t.C_WORKORDERID_LOCAL_).HasColumnName("_WORKORDERID_LOCAL_");
            this.Property(t => t.WONUM).HasColumnName("WONUM");
            this.Property(t => t.PARENT).HasColumnName("PARENT");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.WORKTYPE).HasColumnName("WORKTYPE");
            this.Property(t => t.LEADCRAFT).HasColumnName("LEADCRAFT");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.JPNUM).HasColumnName("JPNUM");
            this.Property(t => t.FAILDATE).HasColumnName("FAILDATE");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.ESTDUR).HasColumnName("ESTDUR");
            this.Property(t => t.ESTLABHRS).HasColumnName("ESTLABHRS");
            this.Property(t => t.ESTMATCOST).HasColumnName("ESTMATCOST");
            this.Property(t => t.ESTLABCOST).HasColumnName("ESTLABCOST");
            this.Property(t => t.ESTTOOLCOST).HasColumnName("ESTTOOLCOST");
            this.Property(t => t.PMNUM).HasColumnName("PMNUM");
            this.Property(t => t.ACTLABHRS).HasColumnName("ACTLABHRS");
            this.Property(t => t.ACTMATCOST).HasColumnName("ACTMATCOST");
            this.Property(t => t.ACTLABCOST).HasColumnName("ACTLABCOST");
            this.Property(t => t.ACTTOOLCOST).HasColumnName("ACTTOOLCOST");
            this.Property(t => t.HASCHILDREN).HasColumnName("HASCHILDREN");
            this.Property(t => t.OUTLABCOST).HasColumnName("OUTLABCOST");
            this.Property(t => t.OUTMATCOST).HasColumnName("OUTMATCOST");
            this.Property(t => t.OUTTOOLCOST).HasColumnName("OUTTOOLCOST");
            this.Property(t => t.HISTORYFLAG).HasColumnName("HISTORYFLAG");
            this.Property(t => t.CONTRACT).HasColumnName("CONTRACT");
            this.Property(t => t.WOPRIORITY).HasColumnName("WOPRIORITY");
            this.Property(t => t.TARGCOMPDATE).HasColumnName("TARGCOMPDATE");
            this.Property(t => t.TARGSTARTDATE).HasColumnName("TARGSTARTDATE");
            this.Property(t => t.WOEQ1).HasColumnName("WOEQ1");
            this.Property(t => t.WOEQ2).HasColumnName("WOEQ2");
            this.Property(t => t.WOEQ3).HasColumnName("WOEQ3");
            this.Property(t => t.WOEQ4).HasColumnName("WOEQ4");
            this.Property(t => t.WOEQ5).HasColumnName("WOEQ5");
            this.Property(t => t.WOEQ6).HasColumnName("WOEQ6");
            this.Property(t => t.WOEQ7).HasColumnName("WOEQ7");
            this.Property(t => t.WOEQ8).HasColumnName("WOEQ8");
            this.Property(t => t.WOEQ9).HasColumnName("WOEQ9");
            this.Property(t => t.WOEQ10).HasColumnName("WOEQ10");
            this.Property(t => t.WOEQ11).HasColumnName("WOEQ11");
            this.Property(t => t.WOEQ12).HasColumnName("WOEQ12");
            this.Property(t => t.WO1).HasColumnName("WO1");
            this.Property(t => t.WO3).HasColumnName("WO3");
            this.Property(t => t.WO4).HasColumnName("WO4");
            this.Property(t => t.WO7).HasColumnName("WO7");
            this.Property(t => t.WO9).HasColumnName("WO9");
            this.Property(t => t.WO10).HasColumnName("WO10");
            this.Property(t => t.REPORTEDBY).HasColumnName("REPORTEDBY");
            this.Property(t => t.REPORTDATE).HasColumnName("REPORTDATE");
            this.Property(t => t.PHONE).HasColumnName("PHONE");
            this.Property(t => t.PROBLEMCODE).HasColumnName("PROBLEMCODE");
            this.Property(t => t.CALENDAR).HasColumnName("CALENDAR");
            this.Property(t => t.DOWNTIME).HasColumnName("DOWNTIME");
            this.Property(t => t.ACTSTART).HasColumnName("ACTSTART");
            this.Property(t => t.ACTFINISH).HasColumnName("ACTFINISH");
            this.Property(t => t.SCHEDSTART).HasColumnName("SCHEDSTART");
            this.Property(t => t.SCHEDFINISH).HasColumnName("SCHEDFINISH");
            this.Property(t => t.REMDUR).HasColumnName("REMDUR");
            this.Property(t => t.CREWID).HasColumnName("CREWID");
            this.Property(t => t.SUPERVISOR).HasColumnName("SUPERVISOR");
            this.Property(t => t.WOEQ13).HasColumnName("WOEQ13");
            this.Property(t => t.WOEQ14).HasColumnName("WOEQ14");
            this.Property(t => t.WOJP1).HasColumnName("WOJP1");
            this.Property(t => t.WOJP2).HasColumnName("WOJP2");
            this.Property(t => t.WOJP3).HasColumnName("WOJP3");
            this.Property(t => t.WOJP4).HasColumnName("WOJP4");
            this.Property(t => t.WOJP5).HasColumnName("WOJP5");
            this.Property(t => t.WOL1).HasColumnName("WOL1");
            this.Property(t => t.WOL2).HasColumnName("WOL2");
            this.Property(t => t.WOL3).HasColumnName("WOL3");
            this.Property(t => t.WOL4).HasColumnName("WOL4");
            this.Property(t => t.WOLABLNK).HasColumnName("WOLABLNK");
            this.Property(t => t.RESPONDBY).HasColumnName("RESPONDBY");
            this.Property(t => t.CALCPRIORITY).HasColumnName("CALCPRIORITY");
            this.Property(t => t.CHARGESTORE).HasColumnName("CHARGESTORE");
            this.Property(t => t.FAILURECODE).HasColumnName("FAILURECODE");
            this.Property(t => t.WOLO1).HasColumnName("WOLO1");
            this.Property(t => t.WOLO2).HasColumnName("WOLO2");
            this.Property(t => t.WOLO3).HasColumnName("WOLO3");
            this.Property(t => t.WOLO4).HasColumnName("WOLO4");
            this.Property(t => t.WOLO5).HasColumnName("WOLO5");
            this.Property(t => t.WOLO6).HasColumnName("WOLO6");
            this.Property(t => t.WOLO7).HasColumnName("WOLO7");
            this.Property(t => t.WOLO8).HasColumnName("WOLO8");
            this.Property(t => t.WOLO9).HasColumnName("WOLO9");
            this.Property(t => t.WOLO10).HasColumnName("WOLO10");
            this.Property(t => t.GLACCOUNT).HasColumnName("GLACCOUNT");
            this.Property(t => t.ESTSERVCOST).HasColumnName("ESTSERVCOST");
            this.Property(t => t.ACTSERVCOST).HasColumnName("ACTSERVCOST");
            this.Property(t => t.DISABLED).HasColumnName("DISABLED");
            this.Property(t => t.ESTATAPPRLABHRS).HasColumnName("ESTATAPPRLABHRS");
            this.Property(t => t.ESTATAPPRLABCOST).HasColumnName("ESTATAPPRLABCOST");
            this.Property(t => t.ESTATAPPRMATCOST).HasColumnName("ESTATAPPRMATCOST");
            this.Property(t => t.ESTATAPPRTOOLCOST).HasColumnName("ESTATAPPRTOOLCOST");
            this.Property(t => t.ESTATAPPRSERVCOST).HasColumnName("ESTATAPPRSERVCOST");
            this.Property(t => t.WOSEQUENCE).HasColumnName("WOSEQUENCE");
            this.Property(t => t.HASFOLLOWUPWORK).HasColumnName("HASFOLLOWUPWORK");
            this.Property(t => t.WORTS1).HasColumnName("WORTS1");
            this.Property(t => t.WORTS2).HasColumnName("WORTS2");
            this.Property(t => t.WORTS3).HasColumnName("WORTS3");
            this.Property(t => t.WORTS4).HasColumnName("WORTS4");
            this.Property(t => t.WORTS5).HasColumnName("WORTS5");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.PMDUEDATE).HasColumnName("PMDUEDATE");
            this.Property(t => t.PMEXTDATE).HasColumnName("PMEXTDATE");
            this.Property(t => t.PMNEXTDUEDATE).HasColumnName("PMNEXTDUEDATE");
            this.Property(t => t.WORKLOCATION).HasColumnName("WORKLOCATION");
            this.Property(t => t.WO11).HasColumnName("WO11");
            this.Property(t => t.WO13).HasColumnName("WO13");
            this.Property(t => t.WO14).HasColumnName("WO14");
            this.Property(t => t.WO15).HasColumnName("WO15");
            this.Property(t => t.WO16).HasColumnName("WO16");
            this.Property(t => t.WO17).HasColumnName("WO17");
            this.Property(t => t.WO18).HasColumnName("WO18");
            this.Property(t => t.WO19).HasColumnName("WO19");
            this.Property(t => t.WO20).HasColumnName("WO20");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.FINCNTRLID).HasColumnName("FINCNTRLID");
            this.Property(t => t.GENERATEDFORPO).HasColumnName("GENERATEDFORPO");
            this.Property(t => t.GENFORPOLINEID).HasColumnName("GENFORPOLINEID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.TASKID).HasColumnName("TASKID");
            this.Property(t => t.INSPECTOR).HasColumnName("INSPECTOR");
            this.Property(t => t.MEASUREMENTVALUE).HasColumnName("MEASUREMENTVALUE");
            this.Property(t => t.MEASUREDATE).HasColumnName("MEASUREDATE");
            this.Property(t => t.OBSERVATION).HasColumnName("OBSERVATION");
            this.Property(t => t.POINTNUM).HasColumnName("POINTNUM");
            this.Property(t => t.WOJO1).HasColumnName("WOJO1");
            this.Property(t => t.WOJO2).HasColumnName("WOJO2");
            this.Property(t => t.WOJO3).HasColumnName("WOJO3");
            this.Property(t => t.WOJO4).HasColumnName("WOJO4");
            this.Property(t => t.WOJO5).HasColumnName("WOJO5");
            this.Property(t => t.WOJO6).HasColumnName("WOJO6");
            this.Property(t => t.WOJO7).HasColumnName("WOJO7");
            this.Property(t => t.WOJO8).HasColumnName("WOJO8");
            this.Property(t => t.ISTASK).HasColumnName("ISTASK");
            this.Property(t => t.SERVICE).HasColumnName("SERVICE");
            this.Property(t => t.ORIGPROBLEMTYPE).HasColumnName("ORIGPROBLEMTYPE");
            this.Property(t => t.CISNUM).HasColumnName("CISNUM");
            this.Property(t => t.MISSUTILITYDATE).HasColumnName("MISSUTILITYDATE");
            this.Property(t => t.MISSUTILITYNUM).HasColumnName("MISSUTILITYNUM");
            this.Property(t => t.MISSUTILITYEMERG).HasColumnName("MISSUTILITYEMERG");
            this.Property(t => t.MAPNUM).HasColumnName("MAPNUM");
            this.Property(t => t.RECEIVEDVIA).HasColumnName("RECEIVEDVIA");
            this.Property(t => t.LOCATIONDETAILS).HasColumnName("LOCATIONDETAILS");
            this.Property(t => t.OTHERCONTACT).HasColumnName("OTHERCONTACT");
            this.Property(t => t.WATERDISCOLORED).HasColumnName("WATERDISCOLORED");
            this.Property(t => t.WATERCOLOR).HasColumnName("WATERCOLOR");
            this.Property(t => t.DISCOLORHOTCOLD).HasColumnName("DISCOLORHOTCOLD");
            this.Property(t => t.RUN15MINUTES).HasColumnName("RUN15MINUTES");
            this.Property(t => t.PARTICLESINWATER).HasColumnName("PARTICLESINWATER");
            this.Property(t => t.PARTICLECOLOR).HasColumnName("PARTICLECOLOR");
            this.Property(t => t.WATERCLOUDY).HasColumnName("WATERCLOUDY");
            this.Property(t => t.WATERODOR).HasColumnName("WATERODOR");
            this.Property(t => t.TYPEODOR).HasColumnName("TYPEODOR");
            this.Property(t => t.WATERCAUSERASH).HasColumnName("WATERCAUSERASH");
            this.Property(t => t.PERSONSEENDOCTOR).HasColumnName("PERSONSEENDOCTOR");
            this.Property(t => t.MEDICALREPORT).HasColumnName("MEDICALREPORT");
            this.Property(t => t.CONNECTIONTYPE).HasColumnName("CONNECTIONTYPE");
            this.Property(t => t.PROBLEMBEGAN).HasColumnName("PROBLEMBEGAN");
            this.Property(t => t.PROBLEMLOC).HasColumnName("PROBLEMLOC");
            this.Property(t => t.PROBLEMTHRUOUT).HasColumnName("PROBLEMTHRUOUT");
            this.Property(t => t.LOCALIZEDWHERE).HasColumnName("LOCALIZEDWHERE");
            this.Property(t => t.WATERTREATMENT).HasColumnName("WATERTREATMENT");
            this.Property(t => t.TYPETREATMENT).HasColumnName("TYPETREATMENT");
            this.Property(t => t.MEASUREMENTVALUE2).HasColumnName("MEASUREMENTVALUE2");
            this.Property(t => t.MEASUREMENTVALUE3).HasColumnName("MEASUREMENTVALUE3");
            this.Property(t => t.SAMPLELOCTYPE).HasColumnName("SAMPLELOCTYPE");
            this.Property(t => t.PETROLEUMODOR).HasColumnName("PETROLEUMODOR");
            this.Property(t => t.CUTNUM).HasColumnName("CUTNUM");
            this.Property(t => t.DISTANCE).HasColumnName("DISTANCE");
            this.Property(t => t.FINALPOSITION).HasColumnName("FINALPOSITION");
            this.Property(t => t.NUMBEROFTURNS).HasColumnName("NUMBEROFTURNS");
            this.Property(t => t.WATERTASTE).HasColumnName("WATERTASTE");
            this.Property(t => t.WATERTASTEDESC).HasColumnName("WATERTASTEDESC");
            this.Property(t => t.FUND).HasColumnName("FUND");
            this.Property(t => t.OUTLETDIA).HasColumnName("OUTLETDIA");
            this.Property(t => t.VELOCITYPRES).HasColumnName("VELOCITYPRES");
            this.Property(t => t.SNAKELINE).HasColumnName("SNAKELINE");
            this.Property(t => t.JETLINE).HasColumnName("JETLINE");
            this.Property(t => t.PROBLEMSIDE).HasColumnName("PROBLEMSIDE");
            this.Property(t => t.MEASUREMENTVALUE4).HasColumnName("MEASUREMENTVALUE4");
            this.Property(t => t.VALIDATED).HasColumnName("VALIDATED");
            this.Property(t => t.CUSTOMERSTREET).HasColumnName("CUSTOMERSTREET");
            this.Property(t => t.CUSTOMERCITY).HasColumnName("CUSTOMERCITY");
            this.Property(t => t.CUSTOMERSTATE).HasColumnName("CUSTOMERSTATE");
            this.Property(t => t.CUSTOMERZIP).HasColumnName("CUSTOMERZIP");
            this.Property(t => t.CUSTOMEREMAIL).HasColumnName("CUSTOMEREMAIL");
            this.Property(t => t.ALTPHONEFAX).HasColumnName("ALTPHONEFAX");
            this.Property(t => t.OTHERCOMPANY).HasColumnName("OTHERCOMPANY");
            this.Property(t => t.PLUMBERNAME).HasColumnName("PLUMBERNAME");
            this.Property(t => t.PLUMBERLICNUM).HasColumnName("PLUMBERLICNUM");
            this.Property(t => t.SEWERRELIEVED).HasColumnName("SEWERRELIEVED");
            this.Property(t => t.SNAKELOC).HasColumnName("SNAKELOC");
            this.Property(t => t.SNAKETOSEWER).HasColumnName("SNAKETOSEWER");
            this.Property(t => t.CLEANOUT).HasColumnName("CLEANOUT");
            this.Property(t => t.CLEANOUTLOC).HasColumnName("CLEANOUTLOC");
            this.Property(t => t.RUNNINGTRAP).HasColumnName("RUNNINGTRAP");
            this.Property(t => t.RUNNINGTRAPLOC).HasColumnName("RUNNINGTRAPLOC");
            this.Property(t => t.EQUIPMENTUSED).HasColumnName("EQUIPMENTUSED");
            this.Property(t => t.JUSTIFICATION).HasColumnName("JUSTIFICATION");
            this.Property(t => t.DEBRIS).HasColumnName("DEBRIS");
            this.Property(t => t.DEBRISDESC).HasColumnName("DEBRISDESC");
            this.Property(t => t.WEATHERCOND).HasColumnName("WEATHERCOND");
            this.Property(t => t.WINDS).HasColumnName("WINDS");
            this.Property(t => t.TEMPERATURE).HasColumnName("TEMPERATURE");
            this.Property(t => t.PRECIPITATION).HasColumnName("PRECIPITATION");
            this.Property(t => t.ENGINEERCOMPANY).HasColumnName("ENGINEERCOMPANY");
            this.Property(t => t.DEVELOPERCOMPANY).HasColumnName("DEVELOPERCOMPANY");
            this.Property(t => t.DEVELOPERCONTACT).HasColumnName("DEVELOPERCONTACT");
            this.Property(t => t.DEVELOPERPHONE).HasColumnName("DEVELOPERPHONE");
            this.Property(t => t.AGENCYID).HasColumnName("AGENCYID");
            this.Property(t => t.RECEIVEDAT).HasColumnName("RECEIVEDAT");
            this.Property(t => t.CONTRACTORCONTACT).HasColumnName("CONTRACTORCONTACT");
            this.Property(t => t.ENUM).HasColumnName("ENUM");
            this.Property(t => t.PIPETYPE).HasColumnName("PIPETYPE");
            this.Property(t => t.PERMITDATE).HasColumnName("PERMITDATE");
            this.Property(t => t.ASBUILTREQD).HasColumnName("ASBUILTREQD");
            this.Property(t => t.ASBUILTRECD).HasColumnName("ASBUILTRECD");
            this.Property(t => t.CONTRACTORPHONE).HasColumnName("CONTRACTORPHONE");
            this.Property(t => t.PROJECTTYPE).HasColumnName("PROJECTTYPE");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.ASSETLOCPRIORITY).HasColumnName("ASSETLOCPRIORITY");
            this.Property(t => t.ASSETNUM).HasColumnName("ASSETNUM");
            this.Property(t => t.BACKOUTPLAN).HasColumnName("BACKOUTPLAN");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.COMMODITY).HasColumnName("COMMODITY");
            this.Property(t => t.COMMODITYGROUP).HasColumnName("COMMODITYGROUP");
            this.Property(t => t.ENVIRONMENT).HasColumnName("ENVIRONMENT");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.INTERRUPTIBLE).HasColumnName("INTERRUPTIBLE");
            this.Property(t => t.JUSTIFYPRIORITY).HasColumnName("JUSTIFYPRIORITY");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.LEAD).HasColumnName("LEAD");
            this.Property(t => t.ONBEHALFOF).HasColumnName("ONBEHALFOF");
            this.Property(t => t.ORIGRECORDCLASS).HasColumnName("ORIGRECORDCLASS");
            this.Property(t => t.ORIGRECORDID).HasColumnName("ORIGRECORDID");
            this.Property(t => t.OWNER).HasColumnName("OWNER");
            this.Property(t => t.OWNERGROUP).HasColumnName("OWNERGROUP");
            this.Property(t => t.PARENTCHGSSTATUS).HasColumnName("PARENTCHGSSTATUS");
            this.Property(t => t.PERSONGROUP).HasColumnName("PERSONGROUP");
            this.Property(t => t.REASONFORCHANGE).HasColumnName("REASONFORCHANGE");
            this.Property(t => t.RISK).HasColumnName("RISK");
            this.Property(t => t.VENDOR).HasColumnName("VENDOR");
            this.Property(t => t.VERIFICATION).HasColumnName("VERIFICATION");
            this.Property(t => t.WHOMISCHANGEFOR).HasColumnName("WHOMISCHANGEFOR");
            this.Property(t => t.WOACCEPTSCHARGES).HasColumnName("WOACCEPTSCHARGES");
            this.Property(t => t.WOCLASS).HasColumnName("WOCLASS");
            this.Property(t => t.WOGROUP).HasColumnName("WOGROUP");
            this.Property(t => t.WORKORDERID).HasColumnName("WORKORDERID");
            this.Property(t => t.BKPCONTRACT).HasColumnName("BKPCONTRACT");
            this.Property(t => t.CINUM).HasColumnName("CINUM");
            this.Property(t => t.FLOWACTION).HasColumnName("FLOWACTION");
            this.Property(t => t.FLOWACTIONASSIST).HasColumnName("FLOWACTIONASSIST");
            this.Property(t => t.FLOWCONTROLLED).HasColumnName("FLOWCONTROLLED");
            this.Property(t => t.JOBTASKID).HasColumnName("JOBTASKID");
            this.Property(t => t.LAUNCHENTRYNAME).HasColumnName("LAUNCHENTRYNAME");
            this.Property(t => t.NEWCHILDCLASS).HasColumnName("NEWCHILDCLASS");
            this.Property(t => t.ROUTE).HasColumnName("ROUTE");
            this.Property(t => t.ROUTESTOPID).HasColumnName("ROUTESTOPID");
            this.Property(t => t.SUSPENDFLOW).HasColumnName("SUSPENDFLOW");
            this.Property(t => t.TARGETDESC).HasColumnName("TARGETDESC");
            this.Property(t => t.WOISSWAP).HasColumnName("WOISSWAP");
            this.Property(t => t.FIRSTAPPRSTATUS).HasColumnName("FIRSTAPPRSTATUS");
            this.Property(t => t.PMCOMTYPE).HasColumnName("PMCOMTYPE");
            this.Property(t => t.PMCOMSTATE).HasColumnName("PMCOMSTATE");
            this.Property(t => t.PMCOMBPELACTNAME).HasColumnName("PMCOMBPELACTNAME");
            this.Property(t => t.PMCOMBPELENABLED).HasColumnName("PMCOMBPELENABLED");
            this.Property(t => t.PMCOMBPELINPROG).HasColumnName("PMCOMBPELINPROG");
            this.Property(t => t.CONPERMITNUM).HasColumnName("CONPERMITNUM");
            this.Property(t => t.OCCPERMITNUM).HasColumnName("OCCPERMITNUM");
            this.Property(t => t.CALCORGID).HasColumnName("CALCORGID");
            this.Property(t => t.CALCCALENDAR).HasColumnName("CALCCALENDAR");
            this.Property(t => t.CALCSHIFT).HasColumnName("CALCSHIFT");
            this.Property(t => t.RESTORATIONREQD).HasColumnName("RESTORATIONREQD");
            this.Property(t => t.CONTR_REL_NUM).HasColumnName("CONTR_REL_NUM");
            this.Property(t => t.DCW_LWBUDGETCHECK).HasColumnName("DCW_LWBUDGETCHECK");
            this.Property(t => t.DCW_SENDMATL2LW).HasColumnName("DCW_SENDMATL2LW");
            this.Property(t => t.DCW_SNAKEDIST2BLCKG).HasColumnName("DCW_SNAKEDIST2BLCKG");
            this.Property(t => t.CONTRACTORJUSTIFICATION).HasColumnName("CONTRACTORJUSTIFICATION");
            this.Property(t => t.COMPLEXITY).HasColumnName("COMPLEXITY");
            this.Property(t => t.DCW_UTILITYSTRIKE).HasColumnName("DCW_UTILITYSTRIKE");
            this.Property(t => t.DCW_REVISEDPRIORITY).HasColumnName("DCW_REVISEDPRIORITY");
            this.Property(t => t.REPFACSITEID).HasColumnName("REPFACSITEID");
            this.Property(t => t.REPAIRFACILITY).HasColumnName("REPAIRFACILITY");
            this.Property(t => t.GENFORPOREVISION).HasColumnName("GENFORPOREVISION");
            this.Property(t => t.STOREROOMMTLSTATUS).HasColumnName("STOREROOMMTLSTATUS");
            this.Property(t => t.DIRISSUEMTLSTATUS).HasColumnName("DIRISSUEMTLSTATUS");
            this.Property(t => t.WORKPACKMTLSTATUS).HasColumnName("WORKPACKMTLSTATUS");
            this.Property(t => t.IGNORESRMAVAIL).HasColumnName("IGNORESRMAVAIL");
            this.Property(t => t.IGNOREDIAVAIL).HasColumnName("IGNOREDIAVAIL");
            this.Property(t => t.ESTINTLABCOST).HasColumnName("ESTINTLABCOST");
            this.Property(t => t.ESTINTLABHRS).HasColumnName("ESTINTLABHRS");
            this.Property(t => t.ESTOUTLABHRS).HasColumnName("ESTOUTLABHRS");
            this.Property(t => t.ESTOUTLABCOST).HasColumnName("ESTOUTLABCOST");
            this.Property(t => t.ACTINTLABCOST).HasColumnName("ACTINTLABCOST");
            this.Property(t => t.ACTINTLABHRS).HasColumnName("ACTINTLABHRS");
            this.Property(t => t.ACTOUTLABHRS).HasColumnName("ACTOUTLABHRS");
            this.Property(t => t.ACTOUTLABCOST).HasColumnName("ACTOUTLABCOST");
            this.Property(t => t.ESTATAPPRINTLABCOST).HasColumnName("ESTATAPPRINTLABCOST");
            this.Property(t => t.ESTATAPPRINTLABHRS).HasColumnName("ESTATAPPRINTLABHRS");
            this.Property(t => t.ESTATAPPROUTLABHRS).HasColumnName("ESTATAPPROUTLABHRS");
            this.Property(t => t.ESTATAPPROUTLABCOST).HasColumnName("ESTATAPPROUTLABCOST");
            this.Property(t => t.ASSIGNEDOWNERGROUP).HasColumnName("ASSIGNEDOWNERGROUP");
            this.Property(t => t.AVAILSTATUSDATE).HasColumnName("AVAILSTATUSDATE");
            this.Property(t => t.LASTCOPYLINKDATE).HasColumnName("LASTCOPYLINKDATE");
            this.Property(t => t.NESTEDJPINPROCESS).HasColumnName("NESTEDJPINPROCESS");
            this.Property(t => t.PLUSCFREQUENCY).HasColumnName("PLUSCFREQUENCY");
            this.Property(t => t.PLUSCFREQUNIT).HasColumnName("PLUSCFREQUNIT");
            this.Property(t => t.PLUSCISMOBILE).HasColumnName("PLUSCISMOBILE");
            this.Property(t => t.PLUSCJPREVNUM).HasColumnName("PLUSCJPREVNUM");
            this.Property(t => t.PLUSCLOOP).HasColumnName("PLUSCLOOP");
            this.Property(t => t.PLUSCNEXTDATE).HasColumnName("PLUSCNEXTDATE");
            this.Property(t => t.PLUSCOVERDUEDATE).HasColumnName("PLUSCOVERDUEDATE");
            this.Property(t => t.PLUSCPHYLOC).HasColumnName("PLUSCPHYLOC");
            this.Property(t => t.INCTASKSINSCHED).HasColumnName("INCTASKSINSCHED");
            this.Property(t => t.SNECONSTRAINT).HasColumnName("SNECONSTRAINT");
            this.Property(t => t.FNLCONSTRAINT).HasColumnName("FNLCONSTRAINT");
            this.Property(t => t.AMCREW).HasColumnName("AMCREW");
            this.Property(t => t.CREWWORKGROUP).HasColumnName("CREWWORKGROUP");
            this.Property(t => t.REQASSTDWNTIME).HasColumnName("REQASSTDWNTIME");
            this.Property(t => t.APPTREQUIRED).HasColumnName("APPTREQUIRED");
            this.Property(t => t.AOS).HasColumnName("AOS");
            this.Property(t => t.AMS).HasColumnName("AMS");
            this.Property(t => t.LOS).HasColumnName("LOS");
            this.Property(t => t.LMS).HasColumnName("LMS"); 
            this.Property(t => t.PLUSSFEATURECLASS).HasColumnName("PLUSSFEATURECLASS");
            this.Property(t => t.PLUSSISGIS).HasColumnName("PLUSSISGIS");
            this.Property(t => t.DCW_CBASSIGNED).HasColumnName("DCW_CBASSIGNED");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
            this.Property(t => t.C_ASSETNUM_LOCAL).HasColumnName("_ASSETNUM_LOCAL");
            this.Property(t => t.C_ORIGRECORDID_LOCAL_).HasColumnName("_ORIGRECORDID_LOCAL_");
            this.Property(t => t.C_mobile_work_type_).HasColumnName("_mobile_work_type_");
        }
    }
}
