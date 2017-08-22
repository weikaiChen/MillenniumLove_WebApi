using System;
using System.ComponentModel;

namespace MillenniumLove.Models
{
    public class EnumItem
    {
        public string FinalValue { get; set; }
        public string Description { get; set; }

        private EnumItem()
        {

        }
        public static EnumItem Get(Enum enumVal)
        {
            var item = new EnumItem();
            var final = enumVal.GetAttributeOfType<FinalValueAttribute>();
            if (final != null)
            {
                item.FinalValue = final.Value;
            }
            

            var desc = enumVal.GetAttributeOfType<DescriptionAttribute>();
            if (desc != null)
            {
                item.Description = desc.Description;
            }
            return item;
        }
        
    }
}
