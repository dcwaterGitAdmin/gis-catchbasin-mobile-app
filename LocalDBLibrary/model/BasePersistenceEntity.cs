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
        
    }
}