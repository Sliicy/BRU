using System;

/**
 * Model used to store information about folder dates.
 * This is used when searching the Template Folder for sorting by the most recently modified date:
 */
namespace STAAC.Models {
    class FolderDates {

        // Each folder has a name:
        public string Name { get; set; }
        
        // Each folder has the last date it was modified:
        public DateTime Modified { get; set; }
    }
}
