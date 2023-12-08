using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Domain.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
