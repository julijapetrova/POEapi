using POEapi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POEapi.Models
{

    public class Extended
    {
        public string category { get; set; }
        public int prefixes { get; set; }
        public int suffixes { get; set; }
    }

    public class Item
    {
        public bool verified { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public string icon { get; set; }
        public string league { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string typeLine { get; set; }
        public bool identified { get; set; }
        public int ilvl { get; set; }
        public List<Property> properties { get; set; }
        public List<Requirement> requirements { get; set; }
        public List<string> explicitMods { get; set; }
        public string descrText { get; set; }
        public int frameType { get; set; }
        public Extended extended { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string inventoryId { get; set; }
    }
}
