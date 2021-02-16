using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSVWebApplication.Models;

namespace CSVWebApplication.Data
{
    public class CSVWebApplicationContext : DbContext
    {
        public CSVWebApplicationContext (DbContextOptions<CSVWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CSVWebApplication.Models.Customer> Customer { get; set; }
    }
}
