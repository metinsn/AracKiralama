using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.ViewModels
{
    public class VMArac
    {
        public int AracID { get; set; }
        public string PlakaNo { get; set; }
        public int Yas { get; set; }
        public AracTip Tip { get; set; }
        public double GunlukUcret { get; set; }
        public bool Kiralandimi { get; set; }

        //public bool Silindimi { get; set; }

        public string MarkaIsim { get; set; }
        public string ModelIsim { get; set; }
    }
}