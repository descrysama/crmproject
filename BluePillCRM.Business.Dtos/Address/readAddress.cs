using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePillCRM.Business.Dtos
{
    public class readAddress
    {
        public String? street { get; set; }

        public String? postalCode { get; set; }

        public String? city { get; set; }

        public int countryId { get; set; }

        public int accessLevel { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public int modifiedBy { get; set; }

        public int createdBy { get; set; }
    }
}
