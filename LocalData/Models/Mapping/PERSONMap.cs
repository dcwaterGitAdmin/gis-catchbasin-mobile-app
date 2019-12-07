using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class PERSONMap : EntityTypeConfiguration<PERSON>
    {
        public PERSONMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PERSONUID });

            // Properties
            this.Property(t => t.ADDRESSLINE1)
                .HasMaxLength(55);

            this.Property(t => t.ADDRESSLINE2)
                .HasMaxLength(55);

            this.Property(t => t.ADDRESSLINE3)
                .HasMaxLength(55);

            this.Property(t => t.BILLTOADDRESS)
                .HasMaxLength(30);

            this.Property(t => t.CITY)
                .HasMaxLength(36);

            this.Property(t => t.COUNTRY)
                .HasMaxLength(36);

            this.Property(t => t.COUNTY)
                .HasMaxLength(36);

            this.Property(t => t.DELEGATE)
                .HasMaxLength(30);

            this.Property(t => t.DEPARTMENT)
                .HasMaxLength(30);

            this.Property(t => t.DISPLAYNAME)
                .HasMaxLength(62);

            this.Property(t => t.DROPPOINT)
                .HasMaxLength(50);

            this.Property(t => t.EMPLOYEETYPE)
                .HasMaxLength(10);

            this.Property(t => t.EXTERNALREFID)
                .HasMaxLength(10);

            this.Property(t => t.FIRSTNAME)
                .HasMaxLength(30);

            this.Property(t => t.JOBCODE)
                .HasMaxLength(10);

            this.Property(t => t.LANGCODE)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.LANGUAGE)
                .HasMaxLength(4);

            this.Property(t => t.LASTNAME)
                .HasMaxLength(50);

            this.Property(t => t.LOCALE)
                .HasMaxLength(10);

            this.Property(t => t.LOCATION)
                .HasMaxLength(12);

            this.Property(t => t.LOCATIONORG)
                .HasMaxLength(8);

            this.Property(t => t.LOCATIONSITE)
                .HasMaxLength(8);

            this.Property(t => t.OWNERSYSID)
                .HasMaxLength(10);

            this.Property(t => t.PCARDEXPDATE)
                .HasMaxLength(7);

            this.Property(t => t.PCARDNUM)
                .HasMaxLength(30);

            this.Property(t => t.PCARDTYPE)
                .HasMaxLength(20);

            this.Property(t => t.PCARDVERIFICATION)
                .HasMaxLength(4);

            this.Property(t => t.PERSONID)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.POSTALCODE)
                .HasMaxLength(12);

            this.Property(t => t.REGIONDISTRICT)
                .HasMaxLength(36);

            this.Property(t => t.SENDERSYSID)
                .HasMaxLength(50);

            this.Property(t => t.SHIPTOADDRESS)
                .HasMaxLength(30);

            this.Property(t => t.SOURCESYSID)
                .HasMaxLength(10);

            this.Property(t => t.STATEPROVINCE)
                .HasMaxLength(36);

            this.Property(t => t.STATUS)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.SUPERVISOR)
                .HasMaxLength(30);

            this.Property(t => t.TIMEZONE)
                .HasMaxLength(28);

            this.Property(t => t.TITLE)
                .HasMaxLength(45);

            this.Property(t => t.TRANSEMAILELECTION)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.WFMAILELECTION)
                .HasMaxLength(15);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            this.Property(t => t.PRIMARYSMS)
                .HasMaxLength(128);

            this.Property(t => t.OWNERGROUP)
                .HasMaxLength(60);

            this.Property(t => t.IM_ID)
                .HasMaxLength(50);

            this.Property(t => t.CALTYPE)
                .HasMaxLength(10);

            this.Property(t => t.DFLTAPP)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PERSON");
            this.Property(t => t.ACCEPTINGWFMAIL).HasColumnName("ACCEPTINGWFMAIL");
            this.Property(t => t.ADDRESSLINE1).HasColumnName("ADDRESSLINE1");
            this.Property(t => t.ADDRESSLINE2).HasColumnName("ADDRESSLINE2");
            this.Property(t => t.ADDRESSLINE3).HasColumnName("ADDRESSLINE3");
            this.Property(t => t.BILLTOADDRESS).HasColumnName("BILLTOADDRESS");
            this.Property(t => t.BIRTHDATE).HasColumnName("BIRTHDATE");
            this.Property(t => t.CITY).HasColumnName("CITY");
            this.Property(t => t.COUNTRY).HasColumnName("COUNTRY");
            this.Property(t => t.COUNTY).HasColumnName("COUNTY");
            this.Property(t => t.DELEGATE).HasColumnName("DELEGATE");
            this.Property(t => t.DELEGATEFROMDATE).HasColumnName("DELEGATEFROMDATE");
            this.Property(t => t.DELEGATETODATE).HasColumnName("DELEGATETODATE");
            this.Property(t => t.DEPARTMENT).HasColumnName("DEPARTMENT");
            this.Property(t => t.DISPLAYNAME).HasColumnName("DISPLAYNAME");
            this.Property(t => t.DROPPOINT).HasColumnName("DROPPOINT");
            this.Property(t => t.EMPLOYEETYPE).HasColumnName("EMPLOYEETYPE");
            this.Property(t => t.EXTERNALREFID).HasColumnName("EXTERNALREFID");
            this.Property(t => t.FIRSTNAME).HasColumnName("FIRSTNAME");
            this.Property(t => t.HASLD).HasColumnName("HASLD");
            this.Property(t => t.HIREDATE).HasColumnName("HIREDATE");
            this.Property(t => t.JOBCODE).HasColumnName("JOBCODE");
            this.Property(t => t.LANGCODE).HasColumnName("LANGCODE");
            this.Property(t => t.LANGUAGE).HasColumnName("LANGUAGE");
            this.Property(t => t.LASTEVALDATE).HasColumnName("LASTEVALDATE");
            this.Property(t => t.LASTNAME).HasColumnName("LASTNAME");
            this.Property(t => t.LOCALE).HasColumnName("LOCALE");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.LOCATIONORG).HasColumnName("LOCATIONORG");
            this.Property(t => t.LOCATIONSITE).HasColumnName("LOCATIONSITE");
            this.Property(t => t.LOCTOSERVREQ).HasColumnName("LOCTOSERVREQ");
            this.Property(t => t.NEXTEVALDATE).HasColumnName("NEXTEVALDATE");
            this.Property(t => t.OWNERSYSID).HasColumnName("OWNERSYSID");
            this.Property(t => t.PCARDEXPDATE).HasColumnName("PCARDEXPDATE");
            this.Property(t => t.PCARDNUM).HasColumnName("PCARDNUM");
            this.Property(t => t.PCARDTYPE).HasColumnName("PCARDTYPE");
            this.Property(t => t.PCARDVERIFICATION).HasColumnName("PCARDVERIFICATION");
            this.Property(t => t.PERSONID).HasColumnName("PERSONID");
            this.Property(t => t.PERSONUID).HasColumnName("PERSONUID");
            this.Property(t => t.POSTALCODE).HasColumnName("POSTALCODE");
            this.Property(t => t.REGIONDISTRICT).HasColumnName("REGIONDISTRICT");
            this.Property(t => t.SENDERSYSID).HasColumnName("SENDERSYSID");
            this.Property(t => t.SHIPTOADDRESS).HasColumnName("SHIPTOADDRESS");
            this.Property(t => t.SOURCESYSID).HasColumnName("SOURCESYSID");
            this.Property(t => t.STATEPROVINCE).HasColumnName("STATEPROVINCE");
            this.Property(t => t.STATUS).HasColumnName("STATUS");
            this.Property(t => t.STATUSDATE).HasColumnName("STATUSDATE");
            this.Property(t => t.SUPERVISOR).HasColumnName("SUPERVISOR");
            this.Property(t => t.TERMINATIONDATE).HasColumnName("TERMINATIONDATE");
            this.Property(t => t.TIMEZONE).HasColumnName("TIMEZONE");
            this.Property(t => t.TITLE).HasColumnName("TITLE");
            this.Property(t => t.TRANSEMAILELECTION).HasColumnName("TRANSEMAILELECTION");
            this.Property(t => t.VIP).HasColumnName("VIP");
            this.Property(t => t.WFMAILELECTION).HasColumnName("WFMAILELECTION");
            this.Property(t => t.WOPRIORITY).HasColumnName("WOPRIORITY");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.PRIMARYSMS).HasColumnName("PRIMARYSMS");
            this.Property(t => t.OWNERGROUP).HasColumnName("OWNERGROUP");
            this.Property(t => t.IM_ID).HasColumnName("IM_ID");
            this.Property(t => t.CALTYPE).HasColumnName("CALTYPE");
            this.Property(t => t.DFLTAPP).HasColumnName("DFLTAPP");
            this.Property(t => t.DEVICECLASS).HasColumnName("DEVICECLASS");
        }
    }

}
