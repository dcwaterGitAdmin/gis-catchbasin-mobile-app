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
        public SyncronizationStatus syncronizationStatus { get; set; } = SyncronizationStatus.SYNCED;

    }

    public enum SyncronizationStatus
    {
	    SYNCED = 0,
	    MODIFIED = 1,
	    CREATED = 2,
	    CONFLICTED = 3,
	    COMPLETED = 4,
    }
}