using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBaybars.Helpers
{
    public class EnCokSatilanTablosu
    {
        public string Barkod { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<int> SatisAdeti { get; set; }

        public Nullable<Double> Fiyat { get; set; }

    }
}