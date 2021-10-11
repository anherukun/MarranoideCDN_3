using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Models.Minecraft
{
    public class Item
    {
        [Key] public string IDItem { get; set; }
        [Required] public int ItemIndex { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string DisplayName { get; set; }
        [Required] public int Stacksize { get; set; }
        public List<EnchantCategory> EnchantCategories { get; set; }
        public List<Item> FixedWith { get; set; }
    }

    public class EnchantCategory
    {
        [Key] public string IDEnchantCategory { get; set; }
        [Required] public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
