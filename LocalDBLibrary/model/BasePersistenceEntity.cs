using Newtonsoft.Json;

namespace LocalDBLibrary.model
{
    /*
	 * This class was created use for be base class.
	 * All Maximo classes must extend from this class.
	 */
    public class BasePersistenceEntity
    {
        // it use by LiteDB.
		[JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        private SyncronizationStatus syncStatus = SyncronizationStatus.SYNCED;

        [JsonIgnore] 
        public SyncronizationStatus syncronizationStatus
        {
        get { return syncStatus; }
            set {
                //  CREATED not set MODIFIED
                if (!(syncStatus == SyncronizationStatus.CREATED && value == SyncronizationStatus.MODIFIED)) {
                    syncStatus = value;
                }
                }
        }

    }

    public enum SyncronizationStatus
    {
	    SYNCED = 6,
	    MODIFIED = 1,
	    CREATED = 2,
	    CONFLICTED = 3,
	    COMPLETED = 4,
        FAILURE =5
    }
}