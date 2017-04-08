using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class Model
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public int MarkaID { get; set; }

        public virtual Marka Marka { get; set; }
    }
}