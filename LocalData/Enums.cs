using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.LocalData
{
    // Summary:
    //     Describes the state of data in the cache. Used for query or as properties
    //     or returned argument
    public enum LocalState
    {
        // Summary:
        //     The record is not defined in the cache. This value cannot be used for querying.
        NotDefined = -1,
        //
        // Summary:
        //     The record has never been modified, it's in its original state when pulled
        //     from the server. When used for a query, the query will returned records
        //     as when they were pulled from the server.
        Original = 0,
        //
        // Summary:
        //     When used in a query, all the current records: added, modified, or original
        //     that have not been modified or deleted.
        Current = 1,
        //
        // Summary:
        //     The record has been marked as deleted. 
        Deleted = 2,
        //
        // Summary:
        //     The record has been modified. 
        Modified = 3,
        //
        // Summary:
        //     The records has been added by the user on in the cache. 
        Added = 4
    }
}
