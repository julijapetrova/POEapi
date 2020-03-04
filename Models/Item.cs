using POEapi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POEapi.Models
{
    public class Property
    {
        public string name { get; set; }
        public List<List<object>> values { get; set; }
        public int displayMode { get; set; }
        public int type { get; set; }
    }

    public class Requirement
    {
        public string name { get; set; }
        public List<List<object>> values { get; set; }
        public int displayMode { get; set; }
    }

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

        public ItemDTO MapToDTO()
        {
            ItemDTO itemDTO = new ItemDTO();
            itemDTO.price = HelperMethods.getInstance().InterpretItemPrice(this.note);
            itemDTO.name = this.name;
            itemDTO.description = this.descrText;

            return itemDTO;
        }
    }

}
