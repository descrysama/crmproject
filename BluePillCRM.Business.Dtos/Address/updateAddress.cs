using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePillCRM.Business.Dtos
{
    public class updateAddress
    {
        public int Id { get; set; }
        public String? Street { get; set; }

        public String? PostalCode { get; set; }

        public String? City { get; set; }

        public int CountryId { get; set; }

        public int AccessLevel { get; set; }

        public int ModifiedBy { get; set; }

    }
}
