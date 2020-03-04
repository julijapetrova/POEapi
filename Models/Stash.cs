using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POEapi.Models
{
    public class Stash
    {

        public string id { get; set; }
        public bool isPublic { get; set; }
        public object accountName { get; set; }
        public object lastCharacterName { get; set; }
        /// <summary>
        /// stash represents the Stash Name. It often shows the price
        /// </summary>
        public object stash { get; set; }
        public string stashType { get; set; }
        public string league { get; set; }
        public List<Item> items { get; set; }
        //     {
        //  "id": "3c8f1dc99dabab14f888755f133dfb532dee09edb2058dd7138d4409c6923f72",
        //  "public": false,
        //  "accountName": null,
        //  "lastCharacterName": null,
        //  "stash": null,
        //  "stashType": "PremiumStash",
        //  "league": "Standard",
        //  "items": [
        //  ]
        //},
    }
    public class StashRootObject
    {
        public string next_change_id { get; set; }
        public List<Stash> stashes { get; set; }
    }
}
