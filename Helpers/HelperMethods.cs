using POEapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POEapi.Helpers
{
    public class HelperMethods
    {
        private static HelperMethods helperMethods;

        // private constructor to force use of 
        // getInstance() to create Singleton object 
        private HelperMethods() { }

        public static HelperMethods getInstance()
        {
            if (helperMethods == null)
                helperMethods = new HelperMethods();
            return helperMethods;
        }
        // INPUT
        // ~b/o 1 fuse
        // ~price 10 exa
        // ~b / o 0 alt
        // ~price 10 chaos
        // ~b / o 5 alt
        // ~b / o 7 exa
        // ~b / o 2 chaos | tali
        // ~b / o 2 chaos | 75 +
        // ~b / o 3 divine
        // ~price 3 chaos
        public Price InterpretItemPrice(string itemPrice)
        {
            Price price = new Price();
            price.Value = getPriceValue(itemPrice);
            price.Currency = getPriceCurrency(itemPrice);
            price.Details = itemPrice;
            return price;
        }
        int getPriceValue(string itemPrice)
        {
            var result = 0;
            Regex regex = new Regex(@"(\d.*?)+");
            if (itemPrice != null)
            {
                result = int.Parse(regex.Match(itemPrice).Value);
            }
            return result;
        }
        string getPriceCurrency(string itemPrice)
        {
            var result = "";
            Regex regex = new Regex(@"(?<=\b\s)([^\d]\w+)");
            if (itemPrice != null)
            {
                result = regex.Split(itemPrice)[1];
            }
            return result;
        }

        enum Currency
        {
            divine,// Divine Orb
            chaos,// Chaos Orb
            alt,// Orb of Alteration
            exa,// Exalted Orb
            fuse // Orb of Fusing
        }
        public ItemDTO MapToDTO(Item from)
        {
            ItemDTO to = new ItemDTO();
            to.price = HelperMethods.getInstance().InterpretItemPrice(from.note);
            to.name = from.name;
            to.description = from.descrText;
            to.icon = from.icon;
            return to;
        }
    }
}
