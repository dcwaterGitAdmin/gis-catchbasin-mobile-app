using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DCWaterMobile.LocalData.Models.Mapping;

namespace DCWaterMobile.LocalData.Models
{
    public partial class MxLocalReferenceDataContext : BaseContext<MxLocalReferenceDataContext>
    {
        public DbSet<ALNDOMAIN> ALNDOMAINs { get; set; }
        public DbSet<ASSETATTRIBUTE> ASSETATTRIBUTEs { get; set; }
        public DbSet<CLASSSPEC> CLASSSPECs { get; set; }
        public DbSet<CREWINFO> CREWINFOs { get; set; }
        public DbSet<CROSSOVERDOMAIN> CROSSOVERDOMAINs { get; set; }
        public DbSet<DOCTYPE> DOCTYPES { get; set; }
        public DbSet<FAILURECODE> FAILURECODEs { get; set; }
        public DbSet<FAILURELIST> FAILURELISTs { get; set; }
        public DbSet<INVENTORY> INVENTORies { get; set; }
        public DbSet<LABORCRAFTRATE> LABORCRAFTRATEs { get; set; }
        public DbSet<MAXDOMAIN> MAXDOMAINs { get; set; }
        public DbSet<MAXROWSTAMP> MAXROWSTAMPs { get; set; }
        public DbSet<MAXTABLEDOMAIN> MAXTABLEDOMAINs { get; set; }
        public DbSet<PERSON> PERSONs { get; set; }
        public DbSet<PERSONGROUP> PERSONGROUPs { get; set; }
        public DbSet<PERSONGROUPTEAM> PERSONGROUPTEAMs { get; set; }
        public DbSet<SYNONYMDOMAIN> SYNONYMDOMAINs { get; set; }
        public DbSet<WORKTYPE> WORKTYPEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ALNDOMAINMap());
            modelBuilder.Configurations.Add(new ASSETATTRIBUTEMap());
            modelBuilder.Configurations.Add(new CLASSSPECMap());
            modelBuilder.Configurations.Add(new CREWINFOMap());
            modelBuilder.Configurations.Add(new CROSSOVERDOMAINMap());
            modelBuilder.Configurations.Add(new DOCTYPEMap());
            modelBuilder.Configurations.Add(new FAILURECODEMap());
            modelBuilder.Configurations.Add(new FAILURELISTMap());
            modelBuilder.Configurations.Add(new INVENTORYMap());
            modelBuilder.Configurations.Add(new LABORCRAFTRATEMap());
            modelBuilder.Configurations.Add(new MAXDOMAINMap());
            modelBuilder.Configurations.Add(new MAXROWSTAMPMap());
            modelBuilder.Configurations.Add(new MAXTABLEDOMAINMap());
            modelBuilder.Configurations.Add(new PERSONMap());
            modelBuilder.Configurations.Add(new PERSONGROUPMap());
            modelBuilder.Configurations.Add(new PERSONGROUPTEAMMap());
            modelBuilder.Configurations.Add(new SYNONYMDOMAINMap());
            modelBuilder.Configurations.Add(new WORKTYPEMap());
        }
    }

}
