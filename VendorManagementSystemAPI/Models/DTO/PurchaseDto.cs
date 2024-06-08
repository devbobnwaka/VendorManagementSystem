using System.ComponentModel.DataAnnotations;
using VendorManagementSystemAPI.Models.Entities;

namespace VendorManagementSystemAPI.Models.DTO
{
    public class PurchaseDto
    {
        public int? Id { get; set; }
        [Required]
        public int VendorId { get; set; }

        [MaxLength(50)]
        public string? PoNumber { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public List<string>? Items { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Status { get; set; }

        public float? QualityRating { get; set; } // Nullable float

        public string? IssueDate { get; set; }
        public string? AcknowledgmentDate { get; set; }
    }
}
