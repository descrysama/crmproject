using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class readAddress
    {
        public int Id { get; set; }

        public String? street { get; set; }

        public String? postalCode { get; set; }

        public String? city { get; set; }

        public ReadCountry country { get; set; }

        public int accessLevel { get; set; }

        public int createdBy { get; set; }

        public DateTime createdAt { get; set; }
    }
}
