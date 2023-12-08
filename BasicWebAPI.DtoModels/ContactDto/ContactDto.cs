using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DtoModels.ContactDto
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
