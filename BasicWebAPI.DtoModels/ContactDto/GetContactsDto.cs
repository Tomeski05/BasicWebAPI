using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DtoModels.ContactDto
{
    public class GetContactsDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
    }
}
