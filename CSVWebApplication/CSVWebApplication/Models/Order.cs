using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVWebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public DateTime Datecreated { get;set; }
        public Decimal Total { get; set; }
        public int CustomerId { get; set; }
        public string CouierCompany { get; set; }
        public string WayBillNo { get; set; }
    }
}
