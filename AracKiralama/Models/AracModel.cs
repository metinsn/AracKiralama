using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class AracModel
    {
        public int AracModelID { get; set; }
        public string Isim { get; set; }
        public int MarkaID { get; set; }

        public AracMarka Marka { get; set; }
    }
}