using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class Kira
    {
        public int KiraID { get; set; }
        public DateTime AlisTarihi { get; set; }
        public int KiralamaSuresi { get; set; }
        public double AlinanUcret { get; set; }
        public double ToplamUcret { get; set; }
        public int AracID { get; set; }
        public int MusteriID { get; set; }

        public Arac Arac { get; set; }
        public Musteri Musteri { get; set; }
    }
}