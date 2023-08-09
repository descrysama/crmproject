using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class ReadProduct
    {
        public int Id { get; set; }

        public String? ProductName { get; set; }

        public String? SerialNumber { get; set; }

        public decimal Price { get; set; }

        public String? Description { get; set; }

        public bool IsDisabled { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        public readUser? modifiedBy { get; set; }

        public readUser CreatedBy { get; set; }
    }
}
