using System.ComponentModel.DataAnnotations;

namespace VendorManagementSystemAPI.Models.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        [Required]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public Guid PoNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public string? Items { get; set; } // JSONField can be stored as string

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Status { get; set; }

        public float? QualityRating { get; set; } // Nullable float

        [Required]
        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AcknowledgmentDate { get; set; }

 
    }
}
