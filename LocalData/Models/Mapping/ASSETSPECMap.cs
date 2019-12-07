using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCWaterMobile.LocalData.Models.Mapping
{
    public class ASSETSPECMap : EntityTypeConfiguration<ASSETSPEC>
    {
        public ASSETSPECMap()
        {
            // Primary Key
            this.HasKey(t => t.C_ASSETSPECID_LOCAL_);

            // Navigation
            this.HasRequired(t => t.Asset)
                .WithMany(a => a.AssetSpecs)
                .HasForeignKey(t => t.C_ASSETNUM_LOCAL_)
                .WillCascadeOnDelete(true);

            // Properties
            this.Property(t => t.ALNVALUE)
                .HasMaxLength(255);

            this.Property(t => t.ASSETATTRID)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.ASSETNUM)
                .HasMaxLength(12);

            this.Property(t => t.CHANGEBY)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.CLASSSTRUCTUREID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ES01)
                .HasMaxLength(10);

            this.Property(t => t.ES02)
                .HasMaxLength(10);

            this.Property(t => t.ES03)
                .HasMaxLength(10);

            this.Property(t => t.MEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.ORGID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SECTION)
                .HasMaxLength(10);

            this.Property(t => t.SITEID)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ENDYOFFSETREF)
                .HasMaxLength(30);

            this.Property(t => t.ENDZOFFSETREF)
                .HasMaxLength(30);

            this.Property(t => t.LINKEDTOATTRIBUTE)
                .HasMaxLength(300);

            this.Property(t => t.LINKEDTOSECTION)
                .HasMaxLength(10);

            this.Property(t => t.STARTYOFFSETREF)
                .HasMaxLength(30);

            this.Property(t => t.STARTZOFFSETREF)
                .HasMaxLength(30);

            this.Property(t => t.TABLEVALUE)
                .HasMaxLength(254);

            this.Property(t => t.BASEMEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.STARTMEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.ENDMEASUREUNITID)
                .HasMaxLength(18);

            this.Property(t => t.STARTOFFSETUNITID)
                .HasMaxLength(18);

            this.Property(t => t.ENDOFFSETUNITID)
                .HasMaxLength(18);

            this.Property(t => t.ROWSTAMP)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("ASSETSPEC");
            this.Property(t => t.C_ASSETSPECID_LOCAL_).HasColumnName("_ASSETSPECID_LOCAL_");
            this.Property(t => t.C_ASSETNUM_LOCAL_).HasColumnName("_ASSETNUM_LOCAL_");
            this.Property(t => t.ALNVALUE).HasColumnName("ALNVALUE");
            this.Property(t => t.ASSETATTRID).HasColumnName("ASSETATTRID");
            this.Property(t => t.ASSETNUM).HasColumnName("ASSETNUM");
            this.Property(t => t.ASSETSPECID).HasColumnName("ASSETSPECID");
            this.Property(t => t.CHANGEBY).HasColumnName("CHANGEBY");
            this.Property(t => t.CHANGEDATE).HasColumnName("CHANGEDATE");
            this.Property(t => t.CLASSSTRUCTUREID).HasColumnName("CLASSSTRUCTUREID");
            this.Property(t => t.DISPLAYSEQUENCE).HasColumnName("DISPLAYSEQUENCE");
            this.Property(t => t.ES01).HasColumnName("ES01");
            this.Property(t => t.ES02).HasColumnName("ES02");
            this.Property(t => t.ES03).HasColumnName("ES03");
            this.Property(t => t.ES04).HasColumnName("ES04");
            this.Property(t => t.ES05).HasColumnName("ES05");
            this.Property(t => t.INHERITEDFROMITEM).HasColumnName("INHERITEDFROMITEM");
            this.Property(t => t.ITEMSPECVALCHANGED).HasColumnName("ITEMSPECVALCHANGED");
            this.Property(t => t.MEASUREUNITID).HasColumnName("MEASUREUNITID");
            this.Property(t => t.NUMVALUE).HasColumnName("NUMVALUE");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.SECTION).HasColumnName("SECTION");
            this.Property(t => t.SITEID).HasColumnName("SITEID");
            this.Property(t => t.CONTINUOUS).HasColumnName("CONTINUOUS");
            this.Property(t => t.ENDMEASURE).HasColumnName("ENDMEASURE");
            this.Property(t => t.ENDOFFSET).HasColumnName("ENDOFFSET");
            this.Property(t => t.ENDYOFFSET).HasColumnName("ENDYOFFSET");
            this.Property(t => t.ENDYOFFSETREF).HasColumnName("ENDYOFFSETREF");
            this.Property(t => t.ENDZOFFSET).HasColumnName("ENDZOFFSET");
            this.Property(t => t.ENDZOFFSETREF).HasColumnName("ENDZOFFSETREF");
            this.Property(t => t.LINKEDTOATTRIBUTE).HasColumnName("LINKEDTOATTRIBUTE");
            this.Property(t => t.LINKEDTOSECTION).HasColumnName("LINKEDTOSECTION");
            this.Property(t => t.MANDATORY).HasColumnName("MANDATORY");
            this.Property(t => t.STARTMEASURE).HasColumnName("STARTMEASURE");
            this.Property(t => t.STARTOFFSET).HasColumnName("STARTOFFSET");
            this.Property(t => t.STARTYOFFSET).HasColumnName("STARTYOFFSET");
            this.Property(t => t.STARTYOFFSETREF).HasColumnName("STARTYOFFSETREF");
            this.Property(t => t.STARTZOFFSET).HasColumnName("STARTZOFFSET");
            this.Property(t => t.STARTZOFFSETREF).HasColumnName("STARTZOFFSETREF");
            this.Property(t => t.TABLEVALUE).HasColumnName("TABLEVALUE");
            this.Property(t => t.BASEMEASUREUNITID).HasColumnName("BASEMEASUREUNITID");
            this.Property(t => t.STARTBASEMEASURE).HasColumnName("STARTBASEMEASURE");
            this.Property(t => t.ENDBASEMEASURE).HasColumnName("ENDBASEMEASURE");
            this.Property(t => t.STARTMEASUREUNITID).HasColumnName("STARTMEASUREUNITID");
            this.Property(t => t.ENDMEASUREUNITID).HasColumnName("ENDMEASUREUNITID");
            this.Property(t => t.STARTASSETFEATUREID).HasColumnName("STARTASSETFEATUREID");
            this.Property(t => t.ENDASSETFEATUREID).HasColumnName("ENDASSETFEATUREID");
            this.Property(t => t.STARTOFFSETUNITID).HasColumnName("STARTOFFSETUNITID");
            this.Property(t => t.ENDOFFSETUNITID).HasColumnName("ENDOFFSETUNITID");
            this.Property(t => t.LINEARASSETSPECID).HasColumnName("LINEARASSETSPECID");
            this.Property(t => t.ROWSTAMP).HasColumnName("ROWSTAMP");
            this.Property(t => t.C_record_state_).HasColumnName("_record_state_");
        }
    }
}
