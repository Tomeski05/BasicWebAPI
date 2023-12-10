using BasicWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebAPI.DtoModels.ContactDto
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
