using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DCWaterMobile.LocalData.Models;
using DCWaterMobile.MaximoService;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.LocalData
{
    public static class Mapper
    {
        internal static void PopulateLocation(LOCATION localLocation, LOCATIONSMboSetLOCATIONS refLocation)
        {
            localLocation.LOCATION_ = refLocation.LOCATION;
            localLocation.DESCRIPTION = refLocation.DESCRIPTION;
            if (refLocation.TYPE != null)
                localLocation.TYPE = refLocation.TYPE.Value;
            if (refLocation.CONTROLACC != null)
                localLocation.CONTROLACC = refLocation.CONTROLACC.VALUE;
            if (refLocation.GLACCOUNT != null)
                localLocation.GLACCOUNT = refLocation.GLACCOUNT.VALUE;
            if (refLocation.PURCHVARACC != null)
                localLocation.PURCHVARACC = refLocation.PURCHVARACC.VALUE;
            if (refLocation.INVOICEVARACC != null)
                localLocation.INVOICEVARACC = refLocation.INVOICEVARACC.VALUE;
            if (refLocation.CURVARACC != null)
                localLocation.CURVARACC = refLocation.CURVARACC.VALUE;
            if (refLocation.SHRINKAGEACC != null)
                localLocation.SHRINKAGEACC = refLocation.SHRINKAGEACC.VALUE;
            if (refLocation.INVCOSTADJACC != null)
                localLocation.INVCOSTADJACC = refLocation.INVCOSTADJACC.VALUE;
            if (refLocation.RECEIPTVARACC != null)
                localLocation.RECEIPTVARACC = refLocation.RECEIPTVARACC.VALUE;
            localLocation.CHANGEBY = refLocation.CHANGEBY;
            localLocation.CHANGEDATE = refLocation.CHANGEDATE;
            localLocation.LO1 = refLocation.LO1;
            localLocation.LO2 = refLocation.LO2;
            localLocation.LO4 = refLocation.LO4;
            localLocation.LO5 = refLocation.LO5;
            localLocation.DISABLED = refLocation.DISABLED;
            if (refLocation.OLDCONTROLACC != null)
                localLocation.OLDCONTROLACC = refLocation.OLDCONTROLACC.VALUE;
            if (refLocation.OLDSHRINKAGEACC != null)
                localLocation.OLDSHRINKAGEACC = refLocation.OLDSHRINKAGEACC.VALUE;
            if (refLocation.OLDINVCOSTADJACC != null)
                localLocation.OLDINVCOSTADJACC = refLocation.OLDINVCOSTADJACC.VALUE;
            localLocation.CLASSSTRUCTUREID = refLocation.CLASSSTRUCTUREID;
            localLocation.GISPARAM1 = refLocation.GISPARAM1;
            localLocation.GISPARAM2 = refLocation.GISPARAM2;
            localLocation.GISPARAM3 = refLocation.GISPARAM3;
            localLocation.LO15 = refLocation.LO15;
            localLocation.SOURCESYSID = refLocation.SOURCESYSID;
            localLocation.OWNERSYSID = refLocation.OWNERSYSID;
            localLocation.EXTERNALREFID = refLocation.EXTERNALREFID;
            localLocation.SENDERSYSID = refLocation.SENDERSYSID;
            localLocation.SITEID = refLocation.SITEID;
            localLocation.ORGID = refLocation.ORGID;
            if (refLocation.INTLABREC != null)
                localLocation.INTLABREC = refLocation.INTLABREC.VALUE;
            localLocation.ISDEFAULT = refLocation.ISDEFAULT;
            localLocation.SHIPTOADDRESSCODE = refLocation.SHIPTOADDRESSCODE;
            localLocation.SHIPTOLABORCODE = refLocation.SHIPTOLABORCODE;
            localLocation.BILLTOADDRESSCODE = refLocation.BILLTOADDRESSCODE;
            localLocation.BILLTOLABORCODE = refLocation.BILLTOLABORCODE;
            localLocation.PREMISESTATUS = refLocation.PREMISESTATUS;
            localLocation.CUSTOMERNUM = refLocation.CUSTOMERNUM;
            localLocation.ACCOUNTNUM = refLocation.ACCOUNTNUM;
            localLocation.QUAD = refLocation.QUAD;
            localLocation.AUTOWOGEN = refLocation.AUTOWOGEN;
            localLocation.HASLD = refLocation.HASLD;
            localLocation.LANGCODE = refLocation.LANGCODE;
            localLocation.LOCATIONSID = refLocation.LOCATIONSID;
            localLocation.SERVICEADDRESSCODE = refLocation.SERVICEADDRESSCODE;
            if (refLocation.STATUS != null)
                localLocation.STATUS = refLocation.STATUS.Value;
            if (refLocation.TOOLCONTROLACC != null)
                localLocation.TOOLCONTROLACC = refLocation.TOOLCONTROLACC.VALUE;
            localLocation.USEINPOPR = refLocation.USEINPOPR;
            localLocation.STATUSDATE = refLocation.STATUSDATE;
            localLocation.DCW_MATLMGMTCTRLD = refLocation.DCW_MATLMGMTCTRLD;
            localLocation.INVOWNER = refLocation.INVOWNER;
            localLocation.ISREPAIRFACILITY = refLocation.ISREPAIRFACILITY;
            localLocation.PLUSCDUEDATE = refLocation.PLUSCDUEDATE;
            localLocation.PLUSCLOOP = refLocation.PLUSCLOOP;
            localLocation.PLUSCPMEXTDATE = refLocation.PLUSCPMEXTDATE;
            localLocation.SADDRESSCODE = refLocation.SADDRESSCODE;
            localLocation.PLUSSFEATURECLASS = refLocation.PLUSSFEATURECLASS;
            localLocation.PLUSSISGIS = refLocation.PLUSSISGIS;
            localLocation.PLUSSADDRESSCODE = refLocation.PLUSSADDRESSCODE;
            localLocation.GEOWORXSYNCID = refLocation.GEOWORXSYNCID;
        }

        internal static void PopulateAsset(ASSET localAsset, CompositeAsset compositeAsset)
        {
            localAsset.ANCESTOR = compositeAsset.ASSET.ANCESTOR;
            localAsset.ASSETID = compositeAsset.ASSET.ASSETID;
            localAsset.ASSETNUM = compositeAsset.ASSET.ASSETNUM;
            localAsset.ASSETTAG = compositeAsset.ASSET.ASSETTAG;
            localAsset.ASSETTYPE = compositeAsset.ASSET.ASSETTYPE;
            localAsset.ASSETUID = compositeAsset.ASSET.ASSETUID;
            localAsset.AUTOWOGEN = compositeAsset.ASSET.AUTOWOGEN;
            localAsset.BINNUM = compositeAsset.ASSET.BINNUM;
            localAsset.BUDGETCOST = Convert.ToDouble(compositeAsset.ASSET.BUDGETCOST);
            localAsset.CALNUM = compositeAsset.ASSET.CALNUM;
            localAsset.CHANGEBY = compositeAsset.ASSET.CHANGEBY;
            localAsset.CHANGEDATE = compositeAsset.ASSET.CHANGEDATE;
            localAsset.CHILDREN = compositeAsset.ASSET.CHILDREN;
            localAsset.CLASSSTRUCTUREID = compositeAsset.ASSET.CLASSSTRUCTUREID;
            localAsset.CONDITIONCODE = compositeAsset.ASSET.CONDITIONCODE;
            localAsset.DESCRIPTION = compositeAsset.ASSET.DESCRIPTION;
            localAsset.DISABLED = compositeAsset.ASSET.DISABLED;
            localAsset.EQ1 = compositeAsset.ASSET.EQ1;
            localAsset.EQ10 = compositeAsset.ASSET.EQ10;
            localAsset.EQ11 = compositeAsset.ASSET.EQ11;
            localAsset.EQ12 = compositeAsset.ASSET.EQ12;
            localAsset.EQ2 = compositeAsset.ASSET.EQ2;
            localAsset.EQ23 = compositeAsset.ASSET.EQ23;
            if (compositeAsset.ASSET.EQ24.HasValue)
                localAsset.EQ24 = Convert.ToDouble(compositeAsset.ASSET.EQ24);
            localAsset.EQ3 = compositeAsset.ASSET.EQ3;
            localAsset.EQ4 = compositeAsset.ASSET.EQ4;
            if (compositeAsset.ASSET.EQ5.HasValue)
                localAsset.EQ5 = Convert.ToDouble(compositeAsset.ASSET.EQ5);
            localAsset.EQ6 = compositeAsset.ASSET.EQ6;
            localAsset.EQ7 = compositeAsset.ASSET.EQ7;
            localAsset.EQ8 = compositeAsset.ASSET.EQ8;
            localAsset.EQ9 = compositeAsset.ASSET.EQ9;
            localAsset.EXTERNALREFID = compositeAsset.ASSET.EXTERNALREFID;
            localAsset.FAILURECODE = compositeAsset.ASSET.FAILURECODE;
            if (compositeAsset.ASSET.GLACCOUNT != null)
                localAsset.GLACCOUNT = compositeAsset.ASSET.GLACCOUNT.VALUE;
            localAsset.GROUPNAME = compositeAsset.ASSET.GROUPNAME;
            localAsset.HASLD = compositeAsset.ASSET.HASLD;
            localAsset.INSTALLDATE = compositeAsset.ASSET.INSTALLDATE;
            localAsset.INVCOST = Convert.ToDouble(compositeAsset.ASSET.INVCOST);
            localAsset.ISRUNNING = compositeAsset.ASSET.ISRUNNING;
            localAsset.ITEMNUM = compositeAsset.ASSET.ITEMNUM;
            localAsset.ITEMSETID = compositeAsset.ASSET.ITEMSETID;
            localAsset.ITEMTYPE = compositeAsset.ASSET.ITEMTYPE;
            localAsset.LANGCODE = compositeAsset.ASSET.LANGCODE;
            localAsset.LOCATION = compositeAsset.ASSET.LOCATION;
            localAsset.MAINTHIERCHY = compositeAsset.ASSET.MAINTHIERCHY;
            localAsset.MANUFACTURER = compositeAsset.ASSET.MANUFACTURER;
            localAsset.MOVED = compositeAsset.ASSET.MOVED;
            localAsset.ORGID = compositeAsset.ASSET.ORGID;
            localAsset.OWNERSYSID = compositeAsset.ASSET.OWNERSYSID;
            localAsset.PARENT = compositeAsset.ASSET.PARENT;
            localAsset.PRIORITY = compositeAsset.ASSET.PRIORITY;
            localAsset.PURCHASEPRICE = Convert.ToDouble(compositeAsset.ASSET.PURCHASEPRICE);
            localAsset.REPLACECOST = Convert.ToDouble(compositeAsset.ASSET.REPLACECOST);

            if (compositeAsset.ASSET.ROTSUSPACCT != null)
                localAsset.ROTSUSPACCT = compositeAsset.ASSET.ROTSUSPACCT.VALUE;
            localAsset.SENDERSYSID = compositeAsset.ASSET.SENDERSYSID;
            localAsset.SERIALNUM = compositeAsset.ASSET.SERIALNUM;
            localAsset.SHIFTNUM = compositeAsset.ASSET.SHIFTNUM;
            localAsset.SITEID = compositeAsset.ASSET.SITEID;
            localAsset.SOURCESYSID = compositeAsset.ASSET.SOURCESYSID;

            if (compositeAsset.ASSET.STATUS != null)
                localAsset.STATUS = compositeAsset.ASSET.STATUS.Value;
            localAsset.STATUSDATE = compositeAsset.ASSET.STATUSDATE;
            if (compositeAsset.ASSET.TOOLCONTROLACCOUNT != null)
                localAsset.TOOLCONTROLACCOUNT = compositeAsset.ASSET.TOOLCONTROLACCOUNT.VALUE;
            if (compositeAsset.ASSET.TOOLRATE.HasValue)
                localAsset.TOOLRATE = Convert.ToDouble(compositeAsset.ASSET.TOOLRATE);
            localAsset.TOTALCOST = Convert.ToDouble(compositeAsset.ASSET.TOTALCOST);
            localAsset.TOTDOWNTIME = Convert.ToDouble(compositeAsset.ASSET.TOTDOWNTIME);
            localAsset.TOTUNCHARGEDCOST = Convert.ToDouble(compositeAsset.ASSET.TOTUNCHARGEDCOST);
            localAsset.UNCHARGEDCOST = Convert.ToDouble(compositeAsset.ASSET.UNCHARGEDCOST);
            localAsset.USAGE = compositeAsset.ASSET.USAGE;
            localAsset.VENDOR = compositeAsset.ASSET.VENDOR;
            localAsset.WARRANTYEXPDATE = compositeAsset.ASSET.WARRANTYEXPDATE;
            localAsset.YTDCOST = Convert.ToDouble(compositeAsset.ASSET.YTDCOST);
            localAsset.EQ13 = compositeAsset.ASSET.EQ13;
            localAsset.EQ14 = compositeAsset.ASSET.EQ14;
            localAsset.EQ15 = compositeAsset.ASSET.EQ15;
            localAsset.EQ16 = compositeAsset.ASSET.EQ16;
            localAsset.EQ19 = compositeAsset.ASSET.EQ19;
            localAsset.EQ22 = compositeAsset.ASSET.EQ22;
            localAsset.MAPNUM = compositeAsset.ASSET.MAPNUM;
            localAsset.FIXEDASSET = compositeAsset.ASSET.FIXEDASSET;
            if (compositeAsset.ASSET.X1.HasValue)
                localAsset.X1 = Convert.ToDouble(compositeAsset.ASSET.X1);
            if (compositeAsset.ASSET.X2.HasValue)
                localAsset.X2 = Convert.ToDouble(compositeAsset.ASSET.X2);
            if (compositeAsset.ASSET.Y1.HasValue)
                localAsset.Y1 = Convert.ToDouble(compositeAsset.ASSET.Y1);
            if (compositeAsset.ASSET.Y2.HasValue)
                localAsset.Y2 = Convert.ToDouble(compositeAsset.ASSET.Y2);
            localAsset.GLOBALID = compositeAsset.ASSET.GLOBALID;
            localAsset.DIRECTION = compositeAsset.ASSET.DIRECTION;
            localAsset.ENDDESCRIPTION = compositeAsset.ASSET.ENDDESCRIPTION;
            if (compositeAsset.ASSET.ENDMEASURE.HasValue)
                localAsset.ENDMEASURE = Convert.ToDouble(compositeAsset.ASSET.ENDMEASURE);
            localAsset.ISLINEAR = compositeAsset.ASSET.ISLINEAR;
            localAsset.STARTDESCRIPTION = compositeAsset.ASSET.STARTDESCRIPTION;
            if (compositeAsset.ASSET.STARTMEASURE.HasValue)
                localAsset.STARTMEASURE = Convert.ToDouble(compositeAsset.ASSET.STARTMEASURE);
            localAsset.LRM = compositeAsset.ASSET.LRM;
            localAsset.PLUSSFEATURECLASS = compositeAsset.ASSET.PLUSSFEATURECLASS;
            localAsset.PLUSSISGIS = compositeAsset.ASSET.PLUSSISGIS;
            localAsset.PLUSSADDRESSCODE = compositeAsset.ASSET.PLUSSADDRESSCODE;
            localAsset.DEFAULTREPFACSITEID = compositeAsset.ASSET.DEFAULTREPFACSITEID;
            localAsset.DEFAULTREPFAC = compositeAsset.ASSET.DEFAULTREPFAC;
            localAsset.RETURNEDTOVENDOR = compositeAsset.ASSET.RETURNEDTOVENDOR;
            localAsset.TLOAMHASH = compositeAsset.ASSET.TLOAMHASH;
            localAsset.TLOAMPARTITION = compositeAsset.ASSET.TLOAMPARTITION;
            localAsset.PLUSCASSETDEPT = compositeAsset.ASSET.PLUSCASSETDEPT;
            localAsset.PLUSCCLASS = compositeAsset.ASSET.PLUSCCLASS;
            localAsset.PLUSCDUEDATE = compositeAsset.ASSET.PLUSCDUEDATE;
            localAsset.PLUSCISCONDESC = compositeAsset.ASSET.PLUSCISCONDESC;
            localAsset.PLUSCISCONTAM = compositeAsset.ASSET.PLUSCISCONTAM;
            localAsset.PLUSCISINHOUSECAL = compositeAsset.ASSET.PLUSCISINHOUSECAL;
            localAsset.PLUSCISMTE = compositeAsset.ASSET.PLUSCISMTE;
            localAsset.PLUSCISMTECLASS = compositeAsset.ASSET.PLUSCISMTECLASS;
            localAsset.PLUSCLOOPNUM = compositeAsset.ASSET.PLUSCLOOPNUM;
            localAsset.PLUSCMODELNUM = compositeAsset.ASSET.PLUSCMODELNUM;
            localAsset.PLUSCOPRGEEU = compositeAsset.ASSET.PLUSCOPRGEEU;
            localAsset.PLUSCOPRGEFROM = compositeAsset.ASSET.PLUSCOPRGEFROM;
            localAsset.PLUSCOPRGETO = compositeAsset.ASSET.PLUSCOPRGETO;
            localAsset.PLUSCPHYLOC = compositeAsset.ASSET.PLUSCPHYLOC;
            localAsset.PLUSCPMEXTDATE = compositeAsset.ASSET.PLUSCPMEXTDATE;
            localAsset.PLUSCSOLUTION = compositeAsset.ASSET.PLUSCSOLUTION;
            localAsset.PLUSCSUMDIR = compositeAsset.ASSET.PLUSCSUMDIR;
            localAsset.PLUSCSUMEU = compositeAsset.ASSET.PLUSCSUMEU;
            localAsset.PLUSCSUMREAD = compositeAsset.ASSET.PLUSCSUMREAD;
            localAsset.PLUSCSUMSPAN = compositeAsset.ASSET.PLUSCSUMSPAN;
            localAsset.PLUSCSUMURV = compositeAsset.ASSET.PLUSCSUMURV;
            localAsset.PLUSCVENDOR = compositeAsset.ASSET.PLUSCVENDOR;
            localAsset.ISCALIBRATION = compositeAsset.ASSET.ISCALIBRATION;
            localAsset.TEMPLATEID = compositeAsset.ASSET.TEMPLATEID;
            localAsset.PLUSCLPLOC = compositeAsset.ASSET.PLUSCLPLOC;
            localAsset.SADDRESSCODE = compositeAsset.ASSET.SADDRESSCODE;
            localAsset.GEOWORXSYNCID = compositeAsset.ASSET.GEOWORXSYNCID;  

            localAsset.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateAssetSpec(ASSETSPEC newAssetSpec, ASSETSPECMboSetASSETSPEC assetSpec)
        {
            newAssetSpec.ALNVALUE = assetSpec.ALNVALUE;
            newAssetSpec.ASSETATTRID = assetSpec.ASSETATTRID;
            newAssetSpec.ASSETNUM = assetSpec.ASSETNUM;
            newAssetSpec.ASSETSPECID = assetSpec.ASSETSPECID;
            newAssetSpec.CHANGEBY = assetSpec.CHANGEBY;
            newAssetSpec.CHANGEDATE = assetSpec.CHANGEDATE;
            newAssetSpec.CLASSSTRUCTUREID = assetSpec.CLASSSTRUCTUREID;
            newAssetSpec.DISPLAYSEQUENCE = assetSpec.DISPLAYSEQUENCE;
            newAssetSpec.ES01 = assetSpec.ES01;
            newAssetSpec.ES02 = assetSpec.ES02;
            newAssetSpec.ES03 = assetSpec.ES03;
            newAssetSpec.ES04 = assetSpec.ES04;
            if (assetSpec.ES05.HasValue)
                newAssetSpec.ES05 = Convert.ToDouble(assetSpec.ES05);
            newAssetSpec.INHERITEDFROMITEM = assetSpec.INHERITEDFROMITEM;
            newAssetSpec.ITEMSPECVALCHANGED = assetSpec.ITEMSPECVALCHANGED;
            newAssetSpec.MEASUREUNITID = assetSpec.MEASUREUNITID;
            if (assetSpec.NUMVALUE.HasValue)
                newAssetSpec.NUMVALUE = Convert.ToDouble(assetSpec.NUMVALUE);
            newAssetSpec.ORGID = assetSpec.ORGID;
            newAssetSpec.SECTION = assetSpec.SECTION;
            newAssetSpec.SITEID = assetSpec.SITEID;
            newAssetSpec.CONTINUOUS = assetSpec.CONTINUOUS;
            if (assetSpec.ENDMEASURE.HasValue)
                newAssetSpec.ENDMEASURE = Convert.ToDouble(assetSpec.ENDMEASURE);
            if (assetSpec.ENDOFFSET.HasValue)
                newAssetSpec.ENDOFFSET = Convert.ToDouble(assetSpec.ENDOFFSET);
            if (assetSpec.ENDYOFFSET.HasValue)
                newAssetSpec.ENDYOFFSET = Convert.ToDouble(assetSpec.ENDYOFFSET);
            newAssetSpec.ENDYOFFSETREF = assetSpec.ENDYOFFSETREF;
            if (assetSpec.ENDZOFFSET.HasValue)
                newAssetSpec.ENDZOFFSET = Convert.ToDouble(assetSpec.ENDZOFFSET);
            newAssetSpec.ENDZOFFSETREF = assetSpec.ENDZOFFSETREF;
            newAssetSpec.LINKEDTOATTRIBUTE = assetSpec.LINKEDTOATTRIBUTE;
            newAssetSpec.LINKEDTOSECTION = assetSpec.LINKEDTOSECTION;
            newAssetSpec.MANDATORY = assetSpec.MANDATORY;
            if (assetSpec.STARTMEASURE.HasValue)
                newAssetSpec.STARTMEASURE = Convert.ToDouble(assetSpec.STARTMEASURE);
            if (assetSpec.STARTOFFSET.HasValue)
                newAssetSpec.STARTOFFSET = Convert.ToDouble(assetSpec.STARTOFFSET);
            if (assetSpec.STARTYOFFSET.HasValue)
                newAssetSpec.STARTYOFFSET = Convert.ToDouble(assetSpec.STARTYOFFSET);
            newAssetSpec.STARTYOFFSETREF = assetSpec.STARTYOFFSETREF;
            if (assetSpec.STARTZOFFSET.HasValue)
                newAssetSpec.STARTZOFFSET = Convert.ToDouble(assetSpec.STARTZOFFSET);
            newAssetSpec.STARTZOFFSETREF = assetSpec.STARTZOFFSETREF;
            newAssetSpec.TABLEVALUE = assetSpec.TABLEVALUE;
            newAssetSpec.BASEMEASUREUNITID = assetSpec.BASEMEASUREUNITID;
            if (assetSpec.STARTBASEMEASURE.HasValue)
                newAssetSpec.STARTBASEMEASURE = Convert.ToDouble(assetSpec.STARTBASEMEASURE);
            if (assetSpec.ENDBASEMEASURE.HasValue)
                newAssetSpec.ENDBASEMEASURE = Convert.ToDouble(assetSpec.ENDBASEMEASURE);
            newAssetSpec.STARTMEASUREUNITID = assetSpec.STARTMEASUREUNITID;
            newAssetSpec.ENDMEASUREUNITID = assetSpec.ENDMEASUREUNITID;
            newAssetSpec.STARTASSETFEATUREID = assetSpec.STARTASSETFEATUREID;
            newAssetSpec.ENDASSETFEATUREID = assetSpec.ENDASSETFEATUREID;
            newAssetSpec.STARTOFFSETUNITID = assetSpec.STARTOFFSETUNITID;
            newAssetSpec.ENDOFFSETUNITID = assetSpec.ENDOFFSETUNITID;
            newAssetSpec.LINEARASSETSPECID = assetSpec.LINEARASSETSPECID;
            newAssetSpec.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateWorkorder(WORKORDER localWorkorder, WORKORDERMbo refWorkorder)
        {
            localWorkorder.C_record_state_ = (long)LocalState.Original;
            localWorkorder.WONUM = refWorkorder.WONUM;
            localWorkorder.PARENT = refWorkorder.PARENT;
            if (refWorkorder.STATUS != null)
               localWorkorder.STATUS = refWorkorder.STATUS.Value;
            localWorkorder.STATUSDATE = refWorkorder.STATUSDATE;
            localWorkorder.WORKTYPE = refWorkorder.WORKTYPE;
            localWorkorder.LEADCRAFT = refWorkorder.LEADCRAFT;
            localWorkorder.DESCRIPTION = refWorkorder.DESCRIPTION;
            localWorkorder.LOCATION = refWorkorder.LOCATION;
            localWorkorder.JPNUM = refWorkorder.JPNUM;
            localWorkorder.FAILDATE = refWorkorder.FAILDATE;
            localWorkorder.CHANGEBY = refWorkorder.CHANGEBY;
            localWorkorder.CHANGEDATE = refWorkorder.CHANGEDATE;
            localWorkorder.ESTDUR = Convert.ToDouble(refWorkorder.ESTDUR);
            localWorkorder.ESTLABHRS = Convert.ToDouble(refWorkorder.ESTLABHRS);
            localWorkorder.ESTMATCOST = Convert.ToDouble(refWorkorder.ESTMATCOST);
            localWorkorder.ESTLABCOST = Convert.ToDouble(refWorkorder.ESTLABCOST);
            localWorkorder.ESTTOOLCOST = Convert.ToDouble(refWorkorder.ESTTOOLCOST);
            localWorkorder.PMNUM = refWorkorder.PMNUM;
            localWorkorder.ACTLABHRS = Convert.ToDouble(refWorkorder.ACTLABHRS);
            localWorkorder.ACTMATCOST = Convert.ToDouble(refWorkorder.ACTMATCOST);
            localWorkorder.ACTLABCOST = Convert.ToDouble(refWorkorder.ACTLABCOST);
            localWorkorder.ACTTOOLCOST = Convert.ToDouble(refWorkorder.ACTTOOLCOST);
            localWorkorder.HASCHILDREN = refWorkorder.HASCHILDREN;
            localWorkorder.OUTLABCOST = Convert.ToDouble(refWorkorder.OUTLABCOST);
            localWorkorder.OUTMATCOST = Convert.ToDouble(refWorkorder.OUTMATCOST);
            localWorkorder.OUTTOOLCOST = Convert.ToDouble(refWorkorder.OUTTOOLCOST);
            localWorkorder.HISTORYFLAG = refWorkorder.HISTORYFLAG;
            localWorkorder.CONTRACT = refWorkorder.CONTRACT;
            localWorkorder.WOPRIORITY = refWorkorder.WOPRIORITY;
            localWorkorder.TARGCOMPDATE = refWorkorder.TARGCOMPDATE;
            localWorkorder.TARGSTARTDATE = refWorkorder.TARGSTARTDATE;
            localWorkorder.WOEQ1 = refWorkorder.WOEQ1;
            localWorkorder.WOEQ2 = refWorkorder.WOEQ2;
            localWorkorder.WOEQ3 = refWorkorder.WOEQ3;
            localWorkorder.WOEQ4 = refWorkorder.WOEQ4;
            if (refWorkorder.WOEQ5.HasValue)
              localWorkorder.WOEQ5 = Convert.ToDouble(refWorkorder.WOEQ5.Value);
            localWorkorder.WOEQ6 = refWorkorder.WOEQ6;
            localWorkorder.WOEQ7 = refWorkorder.WOEQ7;
            localWorkorder.WOEQ8 = refWorkorder.WOEQ8;
            localWorkorder.WOEQ9 = refWorkorder.WOEQ9;
            localWorkorder.WOEQ10 = refWorkorder.WOEQ10;
            localWorkorder.WOEQ11 = refWorkorder.WOEQ11;
            localWorkorder.WOEQ12 = refWorkorder.WOEQ12;
            localWorkorder.WO1 = refWorkorder.WO1;
            localWorkorder.WO3 = refWorkorder.WO3;
            localWorkorder.WO4 = refWorkorder.WO4;
            localWorkorder.WO7 = refWorkorder.WO7;
            localWorkorder.WO9 = refWorkorder.WO9;
            localWorkorder.WO10 = refWorkorder.WO10;
            localWorkorder.REPORTEDBY = refWorkorder.REPORTEDBY;
            localWorkorder.REPORTDATE = refWorkorder.REPORTDATE;
            localWorkorder.PHONE = refWorkorder.PHONE;
            localWorkorder.PROBLEMCODE = refWorkorder.PROBLEMCODE;
            localWorkorder.CALENDAR = refWorkorder.CALENDAR;
            localWorkorder.DOWNTIME = refWorkorder.DOWNTIME;
            localWorkorder.ACTSTART = refWorkorder.ACTSTART;
            localWorkorder.ACTFINISH = refWorkorder.ACTFINISH;
            localWorkorder.SCHEDSTART = refWorkorder.SCHEDSTART;
            localWorkorder.SCHEDFINISH = refWorkorder.SCHEDFINISH;
            if (refWorkorder.REMDUR.HasValue)
              localWorkorder.REMDUR = Convert.ToDouble(refWorkorder.REMDUR);
            localWorkorder.CREWID = refWorkorder.CREWID;
            localWorkorder.SUPERVISOR = refWorkorder.SUPERVISOR;
            localWorkorder.WOEQ13 = refWorkorder.WOEQ13;
            if (refWorkorder.WOEQ14.HasValue)
                localWorkorder.WOEQ14 = Convert.ToDouble(refWorkorder.WOEQ14);
            localWorkorder.WOJP1 = refWorkorder.WOJP1;
            localWorkorder.WOJP2 = refWorkorder.WOJP2;
            localWorkorder.WOJP3 = refWorkorder.WOJP3;
            if (refWorkorder.WOJP4.HasValue)
                localWorkorder.WOJP4 = Convert.ToDouble(refWorkorder.WOJP4);
            localWorkorder.WOJP5 = refWorkorder.WOJP5;
            localWorkorder.WOL1 = refWorkorder.WOL1;
            localWorkorder.WOL2 = refWorkorder.WOL2;
            if (refWorkorder.WOL3.HasValue)
                localWorkorder.WOL3 = Convert.ToDouble(refWorkorder.WOL3);
            localWorkorder.WOL4 = refWorkorder.WOL4;
            localWorkorder.WOLABLNK = refWorkorder.WOLABLNK;
            localWorkorder.RESPONDBY = refWorkorder.RESPONDBY;
            localWorkorder.CALCPRIORITY = refWorkorder.CALCPRIORITY;
            localWorkorder.CHARGESTORE = refWorkorder.CHARGESTORE;
            localWorkorder.FAILURECODE = refWorkorder.FAILURECODE;
            localWorkorder.WOLO1 = refWorkorder.WOLO1;
            localWorkorder.WOLO2 = refWorkorder.WOLO2;
            localWorkorder.WOLO3 = refWorkorder.WOLO3;
            localWorkorder.WOLO4 = refWorkorder.WOLO4;
            localWorkorder.WOLO5 = refWorkorder.WOLO5;
            if (refWorkorder.WOLO6.HasValue)
                localWorkorder.WOLO6 = Convert.ToDouble(refWorkorder.WOLO6);
            localWorkorder.WOLO7 = refWorkorder.WOLO7;
            if (refWorkorder.WOLO8.HasValue)
                localWorkorder.WOLO8 = Convert.ToDouble(refWorkorder.WOLO8);
            localWorkorder.WOLO9 = refWorkorder.WOLO9;
            localWorkorder.WOLO10 = refWorkorder.WOLO10;
            if (refWorkorder.GLACCOUNT != null)
                localWorkorder.GLACCOUNT = refWorkorder.GLACCOUNT.VALUE;
            localWorkorder.ESTSERVCOST = Convert.ToDouble(refWorkorder.ESTSERVCOST);
            localWorkorder.ACTSERVCOST = Convert.ToDouble(refWorkorder.ACTSERVCOST);
            localWorkorder.DISABLED = refWorkorder.DISABLED;
            localWorkorder.ESTATAPPRLABHRS = Convert.ToDouble(refWorkorder.ESTATAPPRLABHRS);
            localWorkorder.ESTATAPPRLABCOST = Convert.ToDouble(refWorkorder.ESTATAPPRLABCOST);
            localWorkorder.ESTATAPPRMATCOST = Convert.ToDouble(refWorkorder.ESTATAPPRMATCOST);
            localWorkorder.ESTATAPPRTOOLCOST = Convert.ToDouble(refWorkorder.ESTATAPPRTOOLCOST);
            localWorkorder.ESTATAPPRSERVCOST = Convert.ToDouble(refWorkorder.ESTATAPPRSERVCOST);
            localWorkorder.WOSEQUENCE = refWorkorder.WOSEQUENCE;
            localWorkorder.HASFOLLOWUPWORK = refWorkorder.HASFOLLOWUPWORK;
            localWorkorder.WORTS1 = refWorkorder.WORTS1;
            localWorkorder.WORTS2 = refWorkorder.WORTS2;
            localWorkorder.WORTS3 = refWorkorder.WORTS3;
            localWorkorder.WORTS4 = refWorkorder.WORTS4;
            if (refWorkorder.WORTS5.HasValue)
              localWorkorder.WORTS5 = Convert.ToDouble(refWorkorder.WORTS5);
            localWorkorder.SOURCESYSID = refWorkorder.SOURCESYSID;
            localWorkorder.OWNERSYSID = refWorkorder.OWNERSYSID;
            localWorkorder.PMDUEDATE = refWorkorder.PMDUEDATE;
            localWorkorder.PMEXTDATE = refWorkorder.PMEXTDATE;
            localWorkorder.PMNEXTDUEDATE = refWorkorder.PMNEXTDUEDATE;
            localWorkorder.WORKLOCATION = refWorkorder.WORKLOCATION;
            localWorkorder.WO11 = refWorkorder.WO11;
            localWorkorder.WO13 = refWorkorder.WO13;
            localWorkorder.WO14 = refWorkorder.WO14;
            localWorkorder.WO15 = refWorkorder.WO15;
            localWorkorder.WO16 = refWorkorder.WO16;
            localWorkorder.WO17 = refWorkorder.WO17;
            localWorkorder.WO18 = refWorkorder.WO18;
            localWorkorder.WO19 = refWorkorder.WO19;
            localWorkorder.WO20 = refWorkorder.WO20;
            localWorkorder.EXTERNALREFID = refWorkorder.EXTERNALREFID;
            localWorkorder.SENDERSYSID = refWorkorder.SENDERSYSID;
            localWorkorder.FINCNTRLID = refWorkorder.FINCNTRLID;
            localWorkorder.GENERATEDFORPO = refWorkorder.GENERATEDFORPO;
            localWorkorder.GENFORPOLINEID = refWorkorder.GENFORPOLINEID;
            localWorkorder.ORGID = refWorkorder.ORGID;
            localWorkorder.SITEID = refWorkorder.SITEID;
            localWorkorder.TASKID = refWorkorder.TASKID;
            localWorkorder.INSPECTOR = refWorkorder.INSPECTOR;
            if (refWorkorder.MEASUREMENTVALUE.HasValue)
                localWorkorder.MEASUREMENTVALUE = Convert.ToDouble(refWorkorder.MEASUREMENTVALUE);
            localWorkorder.MEASUREDATE = refWorkorder.MEASUREDATE;
            localWorkorder.OBSERVATION = refWorkorder.OBSERVATION;
            localWorkorder.POINTNUM = refWorkorder.POINTNUM;
            localWorkorder.WOJO1 = refWorkorder.WOJO1;
            localWorkorder.WOJO2 = refWorkorder.WOJO2;
            localWorkorder.WOJO3 = refWorkorder.WOJO3;
            if (refWorkorder.WOJO4.HasValue)
              localWorkorder.WOJO4 =  Convert.ToDouble(refWorkorder.WOJO4);
            localWorkorder.WOJO5 = refWorkorder.WOJO5;
            localWorkorder.WOJO6 = refWorkorder.WOJO6;
            localWorkorder.WOJO7 = refWorkorder.WOJO7;
            localWorkorder.WOJO8 = refWorkorder.WOJO8;
            localWorkorder.ISTASK = refWorkorder.ISTASK;
            localWorkorder.SERVICE = refWorkorder.SERVICE;
            localWorkorder.ORIGPROBLEMTYPE = refWorkorder.ORIGPROBLEMTYPE;
            localWorkorder.CISNUM = refWorkorder.CISNUM;
            localWorkorder.MISSUTILITYDATE = refWorkorder.MISSUTILITYDATE;
            localWorkorder.MISSUTILITYNUM = refWorkorder.MISSUTILITYNUM;
            localWorkorder.MISSUTILITYEMERG = refWorkorder.MISSUTILITYEMERG;
            localWorkorder.MAPNUM = refWorkorder.MAPNUM;
            localWorkorder.RECEIVEDVIA = refWorkorder.RECEIVEDVIA;
            localWorkorder.LOCATIONDETAILS = refWorkorder.LOCATIONDETAILS;
            localWorkorder.OTHERCONTACT = refWorkorder.OTHERCONTACT;
            localWorkorder.WATERDISCOLORED = refWorkorder.WATERDISCOLORED;
            localWorkorder.WATERCOLOR = refWorkorder.WATERCOLOR;
            localWorkorder.DISCOLORHOTCOLD = refWorkorder.DISCOLORHOTCOLD;
            localWorkorder.RUN15MINUTES = refWorkorder.RUN15MINUTES;
            localWorkorder.PARTICLESINWATER = refWorkorder.PARTICLESINWATER;
            localWorkorder.PARTICLECOLOR = refWorkorder.PARTICLECOLOR;
            localWorkorder.WATERCLOUDY = refWorkorder.WATERCLOUDY;
            localWorkorder.WATERODOR = refWorkorder.WATERODOR;
            localWorkorder.TYPEODOR = refWorkorder.TYPEODOR;
            localWorkorder.WATERCAUSERASH = refWorkorder.WATERCAUSERASH;
            localWorkorder.PERSONSEENDOCTOR = refWorkorder.PERSONSEENDOCTOR;
            localWorkorder.MEDICALREPORT = refWorkorder.MEDICALREPORT;
            localWorkorder.CONNECTIONTYPE = refWorkorder.CONNECTIONTYPE;
            localWorkorder.PROBLEMBEGAN = refWorkorder.PROBLEMBEGAN;
            localWorkorder.PROBLEMLOC = refWorkorder.PROBLEMLOC;
            localWorkorder.PROBLEMTHRUOUT = refWorkorder.PROBLEMTHRUOUT;
            localWorkorder.LOCALIZEDWHERE = refWorkorder.LOCALIZEDWHERE;
            localWorkorder.WATERTREATMENT = refWorkorder.WATERTREATMENT;
            localWorkorder.TYPETREATMENT = refWorkorder.TYPETREATMENT;
            if (refWorkorder.MEASUREMENTVALUE2.HasValue)
                localWorkorder.MEASUREMENTVALUE2 = Convert.ToDouble(refWorkorder.MEASUREMENTVALUE2);
            if (refWorkorder.MEASUREMENTVALUE3.HasValue)
                localWorkorder.MEASUREMENTVALUE3 = Convert.ToDouble(refWorkorder.MEASUREMENTVALUE3);
            localWorkorder.SAMPLELOCTYPE = refWorkorder.SAMPLELOCTYPE;
            localWorkorder.PETROLEUMODOR = refWorkorder.PETROLEUMODOR;
            localWorkorder.CUTNUM = refWorkorder.CUTNUM;
            localWorkorder.DISTANCE = refWorkorder.DISTANCE;
            localWorkorder.FINALPOSITION = refWorkorder.FINALPOSITION;
            if (refWorkorder.NUMBEROFTURNS.HasValue)
              localWorkorder.NUMBEROFTURNS = Convert.ToDouble(refWorkorder.NUMBEROFTURNS);
            localWorkorder.WATERTASTE = refWorkorder.WATERTASTE;
            localWorkorder.WATERTASTEDESC = refWorkorder.WATERTASTEDESC;
            localWorkorder.FUND = refWorkorder.FUND;
            localWorkorder.OUTLETDIA = refWorkorder.OUTLETDIA;
            if (refWorkorder.VELOCITYPRES.HasValue)
                localWorkorder.VELOCITYPRES = Convert.ToDouble(refWorkorder.VELOCITYPRES);
            localWorkorder.SNAKELINE = refWorkorder.SNAKELINE;
            localWorkorder.JETLINE = refWorkorder.JETLINE;
            localWorkorder.PROBLEMSIDE = refWorkorder.PROBLEMSIDE;
            if (refWorkorder.MEASUREMENTVALUE4.HasValue)
              localWorkorder.MEASUREMENTVALUE4 = Convert.ToDouble(refWorkorder.MEASUREMENTVALUE4);
            localWorkorder.VALIDATED = refWorkorder.VALIDATED;
            localWorkorder.CUSTOMERSTREET = refWorkorder.CUSTOMERSTREET;
            localWorkorder.CUSTOMERCITY = refWorkorder.CUSTOMERCITY;
            localWorkorder.CUSTOMERSTATE = refWorkorder.CUSTOMERSTATE;
            localWorkorder.CUSTOMERZIP = refWorkorder.CUSTOMERZIP;
            localWorkorder.CUSTOMEREMAIL = refWorkorder.CUSTOMEREMAIL;
            localWorkorder.ALTPHONEFAX = refWorkorder.ALTPHONEFAX;
            localWorkorder.OTHERCOMPANY = refWorkorder.OTHERCOMPANY;
            localWorkorder.PLUMBERNAME = refWorkorder.PLUMBERNAME;
            localWorkorder.PLUMBERLICNUM = refWorkorder.PLUMBERLICNUM;
            localWorkorder.SEWERRELIEVED = refWorkorder.SEWERRELIEVED;
            localWorkorder.SNAKELOC = refWorkorder.SNAKELOC;
            localWorkorder.SNAKETOSEWER = refWorkorder.SNAKETOSEWER;
            localWorkorder.CLEANOUT = refWorkorder.CLEANOUT;
            localWorkorder.CLEANOUTLOC = refWorkorder.CLEANOUTLOC;
            localWorkorder.RUNNINGTRAP = refWorkorder.RUNNINGTRAP;
            localWorkorder.RUNNINGTRAPLOC = refWorkorder.RUNNINGTRAPLOC;
            localWorkorder.EQUIPMENTUSED = refWorkorder.EQUIPMENTUSED;
            localWorkorder.JUSTIFICATION = refWorkorder.JUSTIFICATION;
            localWorkorder.DEBRIS = refWorkorder.DEBRIS;
            localWorkorder.DEBRISDESC = refWorkorder.DEBRISDESC;
            localWorkorder.WEATHERCOND = refWorkorder.WEATHERCOND;
            localWorkorder.WINDS = refWorkorder.WINDS;
            localWorkorder.TEMPERATURE = refWorkorder.TEMPERATURE;
            localWorkorder.PRECIPITATION = refWorkorder.PRECIPITATION;
            localWorkorder.ENGINEERCOMPANY = refWorkorder.ENGINEERCOMPANY;
            localWorkorder.DEVELOPERCOMPANY = refWorkorder.DEVELOPERCOMPANY;
            localWorkorder.DEVELOPERCONTACT = refWorkorder.DEVELOPERCONTACT;
            localWorkorder.DEVELOPERPHONE = refWorkorder.DEVELOPERPHONE;
            localWorkorder.AGENCYID = refWorkorder.AGENCYID;
            localWorkorder.RECEIVEDAT = refWorkorder.RECEIVEDAT;
            localWorkorder.CONTRACTORCONTACT = refWorkorder.CONTRACTORCONTACT;
            localWorkorder.ENUM = refWorkorder.ENUM;
            localWorkorder.PIPETYPE = refWorkorder.PIPETYPE;
            localWorkorder.PERMITDATE = refWorkorder.PERMITDATE;
            localWorkorder.ASBUILTREQD = refWorkorder.ASBUILTREQD;
            localWorkorder.ASBUILTRECD = refWorkorder.ASBUILTRECD;
            localWorkorder.CONTRACTORPHONE = refWorkorder.CONTRACTORPHONE;
            localWorkorder.PROJECTTYPE = refWorkorder.PROJECTTYPE;
            localWorkorder.ASSETLOCPRIORITY = refWorkorder.ASSETLOCPRIORITY;
            localWorkorder.ASSETNUM = refWorkorder.ASSETNUM;
            localWorkorder.BACKOUTPLAN = refWorkorder.BACKOUTPLAN;
            localWorkorder.CLASSSTRUCTUREID = refWorkorder.CLASSSTRUCTUREID;
            localWorkorder.COMMODITY = refWorkorder.COMMODITY;
            localWorkorder.COMMODITYGROUP = refWorkorder.COMMODITYGROUP;
            localWorkorder.ENVIRONMENT = refWorkorder.ENVIRONMENT;
            localWorkorder.HASLD = refWorkorder.HASLD;
            localWorkorder.INTERRUPTIBLE = refWorkorder.INTERRUPTIBLE;
            localWorkorder.JUSTIFYPRIORITY = refWorkorder.JUSTIFYPRIORITY;
            localWorkorder.LANGCODE = refWorkorder.LANGCODE;
            localWorkorder.LEAD = refWorkorder.LEAD;
            localWorkorder.ONBEHALFOF = refWorkorder.ONBEHALFOF;
            localWorkorder.ORIGRECORDCLASS = refWorkorder.ORIGRECORDCLASS;
            localWorkorder.ORIGRECORDID = refWorkorder.ORIGRECORDID;
            localWorkorder.OWNER = refWorkorder.OWNER;
            localWorkorder.OWNERGROUP = refWorkorder.OWNERGROUP;
            localWorkorder.PARENTCHGSSTATUS = refWorkorder.PARENTCHGSSTATUS;
            localWorkorder.PERSONGROUP = refWorkorder.PERSONGROUP;
            localWorkorder.REASONFORCHANGE = refWorkorder.REASONFORCHANGE;
            localWorkorder.RISK = refWorkorder.RISK;
            localWorkorder.VENDOR = refWorkorder.VENDOR;
            localWorkorder.VERIFICATION = refWorkorder.VERIFICATION;
            localWorkorder.WHOMISCHANGEFOR = refWorkorder.WHOMISCHANGEFOR;
            localWorkorder.WOACCEPTSCHARGES = refWorkorder.WOACCEPTSCHARGES;
            if (refWorkorder.WOCLASS != null)
              localWorkorder.WOCLASS = refWorkorder.WOCLASS.Value;
            localWorkorder.WOGROUP = refWorkorder.WOGROUP;
            localWorkorder.WORKORDERID = refWorkorder.WORKORDERID;
            localWorkorder.BKPCONTRACT = refWorkorder.BKPCONTRACT;
            localWorkorder.CINUM = refWorkorder.CINUM;
            localWorkorder.FLOWACTION = refWorkorder.FLOWACTION;
            localWorkorder.FLOWACTIONASSIST = refWorkorder.FLOWACTIONASSIST;
            localWorkorder.FLOWCONTROLLED = refWorkorder.FLOWCONTROLLED;
            localWorkorder.JOBTASKID = refWorkorder.JOBTASKID;
            localWorkorder.LAUNCHENTRYNAME = refWorkorder.LAUNCHENTRYNAME;
            localWorkorder.NEWCHILDCLASS = refWorkorder.NEWCHILDCLASS;
            localWorkorder.ROUTE = refWorkorder.ROUTE;
            localWorkorder.ROUTESTOPID = refWorkorder.ROUTESTOPID;
            localWorkorder.SUSPENDFLOW = refWorkorder.SUSPENDFLOW;
            localWorkorder.TARGETDESC = refWorkorder.TARGETDESC;
            localWorkorder.WOISSWAP = refWorkorder.WOISSWAP;
            localWorkorder.FIRSTAPPRSTATUS = refWorkorder.FIRSTAPPRSTATUS;
            localWorkorder.PMCOMTYPE = refWorkorder.PMCOMTYPE;
            localWorkorder.PMCOMSTATE = refWorkorder.PMCOMSTATE;
            localWorkorder.PMCOMBPELACTNAME = refWorkorder.PMCOMBPELACTNAME;
            localWorkorder.PMCOMBPELENABLED = refWorkorder.PMCOMBPELENABLED;
            localWorkorder.PMCOMBPELINPROG = refWorkorder.PMCOMBPELINPROG;
            localWorkorder.CONPERMITNUM = refWorkorder.CONPERMITNUM;
            localWorkorder.OCCPERMITNUM = refWorkorder.OCCPERMITNUM;
            localWorkorder.CALCORGID = refWorkorder.CALCORGID;
            localWorkorder.CALCCALENDAR = refWorkorder.CALCCALENDAR;
            localWorkorder.CALCSHIFT = refWorkorder.CALCSHIFT;
            localWorkorder.RESTORATIONREQD = refWorkorder.RESTORATIONREQD;
            localWorkorder.CONTR_REL_NUM = refWorkorder.CONTR_REL_NUM;
            localWorkorder.DCW_LWBUDGETCHECK = refWorkorder.DCW_LWBUDGETCHECK;
            localWorkorder.DCW_SENDMATL2LW = refWorkorder.DCW_SENDMATL2LW;
            localWorkorder.DCW_SNAKEDIST2BLCKG = refWorkorder.DCW_SNAKEDIST2BLCKG;
            localWorkorder.CONTRACTORJUSTIFICATION = refWorkorder.CONTRACTORJUSTIFICATION;
            if (refWorkorder.COMPLEXITY.HasValue)
                localWorkorder.COMPLEXITY = Convert.ToDouble(refWorkorder.COMPLEXITY);
            localWorkorder.DCW_UTILITYSTRIKE = refWorkorder.DCW_UTILITYSTRIKE;
            localWorkorder.DCW_REVISEDPRIORITY = refWorkorder.DCW_REVISEDPRIORITY;
            localWorkorder.REPFACSITEID = refWorkorder.REPFACSITEID;
            localWorkorder.REPAIRFACILITY = refWorkorder.REPAIRFACILITY;
            localWorkorder.GENFORPOREVISION = refWorkorder.GENFORPOREVISION;
            localWorkorder.STOREROOMMTLSTATUS = refWorkorder.STOREROOMMTLSTATUS;
            localWorkorder.DIRISSUEMTLSTATUS = refWorkorder.DIRISSUEMTLSTATUS;
            localWorkorder.WORKPACKMTLSTATUS = refWorkorder.WORKPACKMTLSTATUS;
            localWorkorder.IGNORESRMAVAIL = refWorkorder.IGNORESRMAVAIL;
            localWorkorder.IGNOREDIAVAIL = refWorkorder.IGNOREDIAVAIL;
            localWorkorder.ESTINTLABCOST = refWorkorder.ESTINTLABCOST;
            localWorkorder.ESTINTLABHRS = refWorkorder.ESTINTLABHRS;
            localWorkorder.ESTOUTLABHRS = refWorkorder.ESTOUTLABHRS;
            localWorkorder.ESTOUTLABCOST = refWorkorder.ESTOUTLABCOST;
            localWorkorder.ACTINTLABCOST = refWorkorder.ACTINTLABCOST;
            localWorkorder.ACTINTLABHRS = refWorkorder.ACTINTLABHRS;
            localWorkorder.ACTOUTLABHRS = refWorkorder.ACTOUTLABHRS;
            localWorkorder.ACTOUTLABCOST = refWorkorder.ACTOUTLABCOST;
            localWorkorder.ESTATAPPRINTLABCOST = refWorkorder.ESTATAPPRINTLABCOST;
            localWorkorder.ESTATAPPRINTLABHRS = refWorkorder.ESTATAPPRINTLABHRS;
            localWorkorder.ESTATAPPROUTLABHRS = refWorkorder.ESTATAPPROUTLABHRS;
            localWorkorder.ESTATAPPROUTLABCOST = refWorkorder.ESTATAPPROUTLABCOST;
            localWorkorder.ASSIGNEDOWNERGROUP = refWorkorder.ASSIGNEDOWNERGROUP;
            localWorkorder.AVAILSTATUSDATE = refWorkorder.AVAILSTATUSDATE;
            localWorkorder.LASTCOPYLINKDATE = refWorkorder.LASTCOPYLINKDATE;
            localWorkorder.NESTEDJPINPROCESS = refWorkorder.NESTEDJPINPROCESS;
            localWorkorder.PLUSCFREQUENCY = refWorkorder.PLUSCFREQUENCY;
            localWorkorder.PLUSCFREQUNIT = refWorkorder.PLUSCFREQUNIT;
            localWorkorder.PLUSCISMOBILE = refWorkorder.PLUSCISMOBILE;
            localWorkorder.PLUSCJPREVNUM = refWorkorder.PLUSCJPREVNUM;
            localWorkorder.PLUSCLOOP = refWorkorder.PLUSCLOOP;
            localWorkorder.PLUSCNEXTDATE = refWorkorder.PLUSCNEXTDATE;
            localWorkorder.PLUSCOVERDUEDATE = refWorkorder.PLUSCOVERDUEDATE;
            localWorkorder.PLUSCPHYLOC = refWorkorder.PLUSCPHYLOC;
            localWorkorder.INCTASKSINSCHED = refWorkorder.INCTASKSINSCHED;
            localWorkorder.SNECONSTRAINT = refWorkorder.SNECONSTRAINT;
            localWorkorder.FNLCONSTRAINT = refWorkorder.FNLCONSTRAINT;
            localWorkorder.AMCREW = refWorkorder.AMCREW;
            localWorkorder.CREWWORKGROUP = refWorkorder.CREWWORKGROUP;
            localWorkorder.REQASSTDWNTIME = refWorkorder.REQASSTDWNTIME;
            localWorkorder.APPTREQUIRED = refWorkorder.APPTREQUIRED;
            localWorkorder.AOS = refWorkorder.AOS;
            localWorkorder.AMS = refWorkorder.AMS;
            localWorkorder.LOS = refWorkorder.LOS;
            localWorkorder.LMS = refWorkorder.LMS;
            localWorkorder.PLUSSFEATURECLASS = refWorkorder.PLUSSFEATURECLASS;
            localWorkorder.PLUSSISGIS = refWorkorder.PLUSSISGIS;
            localWorkorder.DCW_CBASSIGNED = refWorkorder.DCW_CBASSIGNED;
        }

        internal static void PopulateWorkorderSpec(WORKORDERSPEC localWorkorderSpec, WORKORDERSPECMboSetWORKORDERSPEC refWorkorderSpec)
        {
            localWorkorderSpec.ALNVALUE = refWorkorderSpec.ALNVALUE;
            localWorkorderSpec.ASSETATTRID = refWorkorderSpec.ASSETATTRID;
            localWorkorderSpec.CHANGEBY = refWorkorderSpec.CHANGEBY;
            localWorkorderSpec.CHANGEDATE = refWorkorderSpec.CHANGEDATE;
            localWorkorderSpec.CLASSSPECID = refWorkorderSpec.CLASSSPECID;
            localWorkorderSpec.CLASSSTRUCTUREID = refWorkorderSpec.CLASSSTRUCTUREID;
            localWorkorderSpec.DISPLAYSEQUENCE = refWorkorderSpec.DISPLAYSEQUENCE;
            localWorkorderSpec.LINKEDTOATTRIBUTE = refWorkorderSpec.LINKEDTOATTRIBUTE;
            localWorkorderSpec.LINKEDTOSECTION = refWorkorderSpec.LINKEDTOSECTION;
            localWorkorderSpec.MANDATORY = refWorkorderSpec.MANDATORY;
            localWorkorderSpec.MEASUREUNITID = refWorkorderSpec.MEASUREUNITID;
            if (refWorkorderSpec.NUMVALUE.HasValue)
                localWorkorderSpec.NUMVALUE = Convert.ToDouble(refWorkorderSpec.NUMVALUE);
            localWorkorderSpec.ORGID = refWorkorderSpec.ORGID;
            localWorkorderSpec.REFOBJECTID = refWorkorderSpec.REFOBJECTID;
            localWorkorderSpec.REFOBJECTNAME = refWorkorderSpec.REFOBJECTNAME;
            localWorkorderSpec.SECTION = refWorkorderSpec.SECTION;
            localWorkorderSpec.SITEID = refWorkorderSpec.SITEID;
            localWorkorderSpec.TABLEVALUE = refWorkorderSpec.TABLEVALUE;
            localWorkorderSpec.WONUM = refWorkorderSpec.WONUM;
            localWorkorderSpec.WORKORDERSPECID = refWorkorderSpec.WORKORDERSPECID;
            localWorkorderSpec.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateFailureReport(FAILUREREPORT localFailureReport, FAILUREREPORTMboSetFAILUREREPORT refFailureReport)
        {
            localFailureReport.WONUM = refFailureReport.WONUM;
            localFailureReport.FAILURECODE = refFailureReport.FAILURECODE;
            localFailureReport.LINENUM = refFailureReport.LINENUM;
            localFailureReport.TYPE = refFailureReport.TYPE;
            localFailureReport.ORGID = refFailureReport.ORGID;
            localFailureReport.SITEID = refFailureReport.SITEID;
            localFailureReport.ASSETNUM = refFailureReport.ASSETNUM;
            localFailureReport.FAILUREREPORTID = refFailureReport.FAILUREREPORTID;
            localFailureReport.TICKETCLASS = refFailureReport.TICKETCLASS;
            localFailureReport.TICKETID = refFailureReport.TICKETID;
            localFailureReport.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateFailureRemark(FAILUREREMARK localFailureRemark, FAILUREREMARKMboSetFAILUREREMARK refFailureRemark)
        {
            localFailureRemark.WONUM = refFailureRemark.WONUM;
            localFailureRemark.DESCRIPTION = refFailureRemark.DESCRIPTION;
            if (refFailureRemark.ENTERDATE.HasValue)
                localFailureRemark.ENTERDATE = refFailureRemark.ENTERDATE;
            localFailureRemark.ORGID = refFailureRemark.ORGID;
            localFailureRemark.SITEID = refFailureRemark.SITEID;
            localFailureRemark.FAILUREREMARKID = refFailureRemark.FAILUREREMARKID;
            localFailureRemark.HASLD = refFailureRemark.HASLD;
            localFailureRemark.LANGCODE = refFailureRemark.LANGCODE;
            localFailureRemark.TICKETCLASS = refFailureRemark.TICKETCLASS;
            localFailureRemark.TICKETID = refFailureRemark.TICKETID;  
            localFailureRemark.C_record_state_ = (long) LocalState.Original;
        }

        internal static void PopulateWoStatus(WOSTATUS localWoStatus, WOSTATUSMboSetWOSTATUS refWoStatus)
        {
            localWoStatus.WONUM = refWoStatus.WONUM;
            localWoStatus.STATUS = refWoStatus.STATUS;
            localWoStatus.CHANGEDATE = refWoStatus.CHANGEDATE;
            localWoStatus.CHANGEBY = refWoStatus.CHANGEBY;
            localWoStatus.MEMO = refWoStatus.MEMO;
            if (refWoStatus.GLACCOUNT != null)
              localWoStatus.GLACCOUNT = refWoStatus.GLACCOUNT.VALUE;
            localWoStatus.FINCNTRLID = refWoStatus.FINCNTRLID;
            localWoStatus.ORGID = refWoStatus.ORGID;
            localWoStatus.SITEID = refWoStatus.SITEID;
            localWoStatus.WOSTATUSID = refWoStatus.WOSTATUSID;
            localWoStatus.PARENT = refWoStatus.PARENT;
            localWoStatus.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateDocLink(DOCLINK localDocLink, DOCLINKSMboSetDOCLINKS refDocLink)
        {
            localDocLink.DOCUMENT = refDocLink.DOCUMENT;
            localDocLink.REFERENCE = refDocLink.REFERENCE;
            localDocLink.DOCTYPE = refDocLink.DOCTYPE;
            localDocLink.DOCVERSION = refDocLink.DOCVERSION;
            localDocLink.GETLATESTVERSION = refDocLink.GETLATESTVERSION;
            localDocLink.CREATEBY = refDocLink.CREATEBY;
            localDocLink.CREATEDATE = refDocLink.CREATEDATE;
            localDocLink.CHANGEBY = refDocLink.CHANGEBY;
            localDocLink.CHANGEDATE = refDocLink.CHANGEDATE;
            localDocLink.PRINTTHRULINK = refDocLink.PRINTTHRULINK;
            localDocLink.COPYLINKTOWO = refDocLink.COPYLINKTOWO;
            localDocLink.DOCINFOID = refDocLink.DOCINFOID;
            localDocLink.DOCLINKSID = refDocLink.DOCLINKSID;
            localDocLink.OWNERID = refDocLink.OWNERID;
            localDocLink.OWNERTABLE = refDocLink.OWNERTABLE;
            localDocLink.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateDocInfo(DOCINFO localDocInfo, DOCINFOMboSetDOCINFO refDocInfo)
        {
            localDocInfo.DOCUMENT = refDocInfo.DOCUMENT;
            localDocInfo.DESCRIPTION = refDocInfo.DESCRIPTION;
            localDocInfo.APPLICATION = refDocInfo.APPLICATION;
            localDocInfo.STATUS = refDocInfo.STATUS;
            localDocInfo.STATUSDATE = refDocInfo.STATUSDATE;
            localDocInfo.CREATEDATE = refDocInfo.CREATEDATE;
            localDocInfo.REVISION = refDocInfo.REVISION;
            localDocInfo.EXTRA1 = refDocInfo.EXTRA1;
            localDocInfo.CHANGEBY = refDocInfo.CHANGEBY;
            localDocInfo.CHANGEDATE = refDocInfo.CHANGEDATE;
            localDocInfo.DOCLOCATION = refDocInfo.DOCLOCATION;
            localDocInfo.DOCTYPE = refDocInfo.DOCTYPE;
            localDocInfo.CREATEBY = refDocInfo.CREATEBY;
            if (refDocInfo.URLTYPE != null)
              localDocInfo.URLTYPE = refDocInfo.URLTYPE.Value;
            localDocInfo.DMSNAME = refDocInfo.DMSNAME;
            localDocInfo.URLNAME = refDocInfo.URLNAME;
            localDocInfo.URLPARAM1 = refDocInfo.URLPARAM1;
            localDocInfo.URLPARAM2 = refDocInfo.URLPARAM2;
            localDocInfo.URLPARAM3 = refDocInfo.URLPARAM3;
            localDocInfo.URLPARAM4 = refDocInfo.URLPARAM4;
            localDocInfo.URLPARAM5 = refDocInfo.URLPARAM5;
            localDocInfo.PRINTTHRULINKDFLT = refDocInfo.PRINTTHRULINKDFLT;
            localDocInfo.USEDEFAULTFILEPATH = refDocInfo.USEDEFAULTFILEPATH;
            localDocInfo.SHOW = refDocInfo.SHOW;
            localDocInfo.DOCINFOID = refDocInfo.DOCINFOID;
            localDocInfo.HASLD = refDocInfo.HASLD;
            localDocInfo.LANGCODE = refDocInfo.LANGCODE;
            localDocInfo.CONTENTUID = refDocInfo.CONTENTUID;
            localDocInfo.C_URLNAME_LOCAL_ = null;
            
            localDocInfo.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateToolTran(TOOLTRAN localToolTran, TOOLTRANSMboSetTOOLTRANS refToolTran)
        {
            localToolTran.TRANSDATE = refToolTran.TRANSDATE;
            localToolTran.TOOLRATE = Convert.ToDouble( refToolTran.TOOLRATE);
            localToolTran.TOOLQTY = refToolTran.TOOLQTY;
            localToolTran.TOOLHRS = Convert.ToDouble(refToolTran.TOOLHRS);
            localToolTran.ENTERDATE = refToolTran.ENTERDATE;
            localToolTran.ENTERBY = refToolTran.ENTERBY;
            localToolTran.OUTSIDE = refToolTran.OUTSIDE;
            localToolTran.ROLLUP = refToolTran.ROLLUP;
            localToolTran.GLDEBITACCT = refToolTran.GLDEBITACCT;
            localToolTran.LINECOST = Convert.ToDouble(refToolTran.LINECOST);
            localToolTran.GLCREDITACCT = refToolTran.GLCREDITACCT;
            localToolTran.FINANCIALPERIOD = refToolTran.FINANCIALPERIOD;
            localToolTran.LOCATION = refToolTran.LOCATION;
            localToolTran.EXCHANGERATE2 = Convert.ToDouble(refToolTran.EXCHANGERATE2);
            localToolTran.LINECOST2 = Convert.ToDouble(refToolTran.LINECOST2);
            localToolTran.SOURCESYSID = refToolTran.SOURCESYSID;
            localToolTran.OWNERSYSID = refToolTran.OWNERSYSID;
            localToolTran.EXTERNALREFID = refToolTran.EXTERNALREFID;
            localToolTran.SENDERSYSID = refToolTran.SENDERSYSID;
            localToolTran.FINCNTRLID = refToolTran.FINCNTRLID;
            localToolTran.ORGID = refToolTran.ORGID;
            localToolTran.SITEID = refToolTran.SITEID;
            localToolTran.REFWO = refToolTran.REFWO;
            localToolTran.ENTEREDASTASK = refToolTran.ENTEREDASTASK;
            localToolTran.ASSETNUM = refToolTran.ASSETNUM;
            localToolTran.ITEMNUM = refToolTran.ITEMNUM;
            localToolTran.ITEMSETID = refToolTran.ITEMSETID;
            localToolTran.ROTASSETNUM = refToolTran.ROTASSETNUM;
            localToolTran.ROTASSETSITE = refToolTran.ROTASSETSITE;
            localToolTran.TOOLTRANSID = refToolTran.TOOLTRANSID;
            localToolTran.PLUSCCOMMENT = refToolTran.PLUSCCOMMENT;
            localToolTran.PLUSCDUEDATE = refToolTran.PLUSCDUEDATE;
            localToolTran.PLUSCEXPIRYDATE = refToolTran.PLUSCEXPIRYDATE;
            localToolTran.PLUSCLOTNUM = refToolTran.PLUSCLOTNUM;
            localToolTran.PLUSCMANUFACTURER = refToolTran.PLUSCMANUFACTURER;
            localToolTran.PLUSCTECHNICIAN = refToolTran.PLUSCTECHNICIAN;
            localToolTran.PLUSCTOOLUSEDATE = refToolTran.PLUSCTOOLUSEDATE;
            localToolTran.PLUSCTYPE = refToolTran.PLUSCTYPE;
            localToolTran.HASLD = refToolTran.HASLD;
            localToolTran.LANGCODE = refToolTran.LANGCODE;
            localToolTran.AMCREW = refToolTran.AMCREW;
            localToolTran.TOOLSQ = refToolTran.TOOLSQ;

            localToolTran.C_record_state_ = (long)LocalState.Original;
        }

        internal static void PopulateLabTran(LABTRAN localLabTran, LABTRANSMboSetLABTRANS refLabTran)
        {
            localLabTran.TRANSDATE = refLabTran.TRANSDATE;
            localLabTran.LABORCODE = refLabTran.LABORCODE;
            localLabTran.CRAFT = refLabTran.CRAFT;
            localLabTran.PAYRATE = Convert.ToDouble(refLabTran.PAYRATE);
            localLabTran.REGULARHRS = Convert.ToDouble(refLabTran.REGULARHRS);
            localLabTran.ENTERBY = refLabTran.ENTERBY;
            localLabTran.ENTERDATE = refLabTran.ENTERDATE;
            localLabTran.LTWO1 = refLabTran.LTWO1;
            localLabTran.LT7 = refLabTran.LT7;
            localLabTran.STARTDATE = refLabTran.STARTDATE;
            localLabTran.STARTTIME = refLabTran.STARTTIME;
            localLabTran.FINISHDATE = refLabTran.FINISHDATE;
            localLabTran.FINISHTIME = refLabTran.FINISHTIME;
            if (refLabTran.TRANSTYPE != null)
              localLabTran.TRANSTYPE = refLabTran.TRANSTYPE.Value;
            localLabTran.OUTSIDE = refLabTran.OUTSIDE;
            localLabTran.MEMO = refLabTran.MEMO;
            localLabTran.ROLLUP = refLabTran.ROLLUP;
            if (refLabTran.GLDEBITACCT != null)
              localLabTran.GLDEBITACCT = refLabTran.GLDEBITACCT.VALUE;
            localLabTran.LINECOST = Convert.ToDouble(refLabTran.LINECOST);
            localLabTran.GLCREDITACCT = refLabTran.GLCREDITACCT;
            localLabTran.FINANCIALPERIOD = refLabTran.FINANCIALPERIOD;
            localLabTran.PONUM = refLabTran.PONUM;
            localLabTran.POLINENUM = refLabTran.POLINENUM;
            localLabTran.LOCATION = refLabTran.LOCATION;
            localLabTran.GENAPPRSERVRECEIPT = refLabTran.GENAPPRSERVRECEIPT;
            localLabTran.PAYMENTTRANSDATE = refLabTran.PAYMENTTRANSDATE;
            if (refLabTran.EXCHANGERATE2.HasValue)
              localLabTran.EXCHANGERATE2 = Convert.ToDouble(refLabTran.EXCHANGERATE2);
            localLabTran.LINECOST2 =  Convert.ToDouble(refLabTran.LINECOST2);
            localLabTran.LABTRANSID = refLabTran.LABTRANSID;
            localLabTran.SERVRECTRANSID = refLabTran.SERVRECTRANSID;
            localLabTran.SOURCESYSID = refLabTran.SOURCESYSID;
            localLabTran.OWNERSYSID = refLabTran.OWNERSYSID;
            localLabTran.EXTERNALREFID = refLabTran.EXTERNALREFID;
            localLabTran.SENDERSYSID = refLabTran.SENDERSYSID;
            localLabTran.FINCNTRLID = refLabTran.FINCNTRLID;
            localLabTran.ORGID = refLabTran.ORGID;
            localLabTran.SITEID = refLabTran.SITEID;
            localLabTran.REFWO = refLabTran.REFWO;
            localLabTran.ENTEREDASTASK = refLabTran.ENTEREDASTASK;
            localLabTran.ASSETNUM = refLabTran.ASSETNUM;
            localLabTran.CONTRACTNUM = refLabTran.CONTRACTNUM;
            localLabTran.INVOICELINENUM = refLabTran.INVOICELINENUM;
            localLabTran.INVOICENUM = refLabTran.INVOICENUM;
            localLabTran.PREMIUMPAYCODE = refLabTran.PREMIUMPAYCODE;
            localLabTran.PREMIUMPAYHOURS =  Convert.ToDouble(refLabTran.PREMIUMPAYHOURS);
            localLabTran.PREMIUMPAYRATE =  Convert.ToDouble(refLabTran.PREMIUMPAYRATE);
            if (refLabTran.PREMIUMPAYRATETYPE != null)
              localLabTran.PREMIUMPAYRATETYPE =  refLabTran.PREMIUMPAYRATETYPE.Value;
            localLabTran.REVISIONNUM = refLabTran.REVISIONNUM;
            localLabTran.SKILLLEVEL = refLabTran.SKILLLEVEL;
            localLabTran.TICKETCLASS = refLabTran.TICKETCLASS;
            localLabTran.TICKETID = refLabTran.TICKETID;
            localLabTran.TIMERSTATUS = refLabTran.TIMERSTATUS;
            localLabTran.VENDOR = refLabTran.VENDOR;

            localLabTran.POREVISIONNUM = refLabTran.POREVISIONNUM;
            localLabTran.CREWWORKGROUP = refLabTran.CREWWORKGROUP;
            localLabTran.AMCREW = refLabTran.AMCREW;
            localLabTran.AMCREWTYPE = refLabTran.AMCREWTYPE;
            localLabTran.POSITION = refLabTran.POSITION;

            localLabTran.DCW_TRUCKLEAD = refLabTran.DCW_TRUCKLEAD;
            localLabTran.DCW_TRUCKSECOND = refLabTran.DCW_TRUCKSECOND;
            localLabTran.DCW_TRUCKDRIVER = refLabTran.DCW_TRUCKDRIVER;
            localLabTran.DCW_TRUCKNUM = refLabTran.DCW_TRUCKNUM;
            localLabTran.C_record_state_ = (long)LocalState.Original;
        }
    }
}
