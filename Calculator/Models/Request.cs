using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public class Request
    {
        //Primary Key
        public int Id { get; set; }
        public string IpAddress { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RequestDateTime { get; set; }

    }
}
