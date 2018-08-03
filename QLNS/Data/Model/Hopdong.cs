using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Hopdong
    { 
        public int id { get; set; }
        public string Sohopdong { get; set; }
        public string Ten { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaylap { get; set; }
        public DateTime? Batdau { get; set; }
        public DateTime? Ketthuc { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Kyhopdong Kyhopdong { get; set; }
    }
}
