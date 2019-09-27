using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace envelweb.Models
{
    public class dados
    {

        public int id { get; set; }
        public string categoria { get; set; }

        [DataType(DataType.Date)]
        public DateTime data { get; set; }
        public string pagrec { get; set; }
        public string banco { get; set; }
        public decimal valor { get; set; }
        public decimal juros { get; set; }
        public decimal desconto { get; set; }
        public string nota { get; set; }
    }
}
