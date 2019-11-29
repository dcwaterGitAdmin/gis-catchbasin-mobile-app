namespace LocalDBLibrary.model
{
    /*
	 * This class was created use for be base class.
	 * All Maximo classes must extend from this class.
	 */
    public class BasePersistenceEntity
    {
        // it use by LiteDB.
        public int Id { get; set; }

        // it use to find edited data by developers.
        public bool editedFromApp { get; set; }
        
        public SyncronizationStatus? syncronizationStatus { get; set; }
        
    }

    public enum SyncronizationStatus
    {
	    SYNCED = 0,
	    MODIFIED = 1,
	    CREATED = 2,
	    CONFLICTED = 3
    }
}