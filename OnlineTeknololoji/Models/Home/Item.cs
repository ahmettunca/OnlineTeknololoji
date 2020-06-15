using OnlineTeknololoji.DAL1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTeknololoji.Models.Home
{
    public class Item
    {
        public UrunTablo Product { set; get; }
        public int Miktar { get; set; }
    }
}