using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public enum AracTip
    {
        Otomobil = 0,
        Motosiklet = 1,
        Ticari = 2
    }

    public class Arac
    {
        public int AracID { get; set; }
        public string PlakaNo { get; set; }
        public int Yas { get; set; }
        public AracTip Tip { get; set; }
        public double GunlukUcret { get; set; }
        public bool Kiralandimi { get; set; }
        public bool Silindimi { get; set; }
        public int AracMarkaID { get; set; }
        public int AracModelID { get; set; }

        public virtual AracMarka AracMarka { get; set; }
        public virtual AracModel AracModel { get; set; }
    }
}