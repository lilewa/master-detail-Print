using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Print.Schema
{
    public  class JTMX
    {
        public int 清单 { get; set; } 
        public int 差异 { get; set; }
        public int 已退 { get; set; }
        public int 未退 { get; set; }
        public int 码洋 { get; set; }
        public string 书名 { get; set; }
        public string ISBN { get; set; }
        public double 定价 { get; set; }
        public string 原因 { get; set; }
        public string id { get; set; }
        public string 单号 { get; set; }

    }
}
