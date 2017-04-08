using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.ViewModels
{
    public class VMKira
    {
        public int AracID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public DateTime AlisTarihi { get; set; }
        public int KiralamaSuresi { get; set; }
        public double AlinanUcret { get; set; }
        public double ToplamUcret { get; set; }
    }
}