using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSVWebApplication.Models
{
    public class Customer
    {
        [Key]
        public string CUST_CODE { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_CITY { get; set; }
        public string WORKING_AREA { get; set; }
        public string CUST_COUNTRY { get; set; }
        public decimal GRADE { get; set; }
        public decimal OPENING_AMT { get; set; }
        public decimal RECEIVE_AMT { get; set; }
        public decimal PAYMENT_AMT { get; set; }
        public decimal OUTSTANDING_AMT { get; set; }
        public string PHONE_NO { get; set; }
    }
}
