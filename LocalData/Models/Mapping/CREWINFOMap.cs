using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class CREWINFOMap : EntityTypeConfiguration<CREWINFO>
    {
        public CREWINFOMap()
        {
            // Primary Key
            this.HasKey(t => t.LOGINID);

            // Properties
            this.Property(t => t.LOGINID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LOGINPERSONID)
                .HasMaxLength(30);

            this.Property(t => t.CREWID)
                .HasMaxLength(15);

            this.Property(t => t.LEADMAN)
                .HasMaxLength(30);

            this.Property(t => t.SECONDMAN)
                .HasMaxLength(30);

            this.Property(t => t.VEHICLEID)
                .HasMaxLength(10);

            this.Property(t => t.DRIVERID)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("CREWINFO");
            this.Property(t => t.LOGINID).HasColumnName("LOGINID");
            this.Property(t => t.LOGINPERSONID).HasColumnName("LOGINPERSONID");
            this.Property(t => t.CREWID).HasColumnName("CREWID");
            this.Property(t => t.LEADMAN).HasColumnName("LEADMAN");
            this.Property(t => t.SECONDMAN).HasColumnName("SECONDMAN");
            this.Property(t => t.VEHICLEID).HasColumnName("VEHICLEID");
            this.Property(t => t.DRIVERID).HasColumnName("DRIVERID");
        }
    }
}
