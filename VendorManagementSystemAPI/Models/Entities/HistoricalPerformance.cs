using System.ComponentModel.DataAnnotations;

namespace VendorManagementSystemAPI.Models.Entities
{
    public class HistoricalPerformance
    {
        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float OnTimeDeliveryRate { get; set; }

        [Required]
        public float QualityRatingAvg { get; set; }

        [Required]
        public float AverageResponseTime { get; set; }

        [Required]
        public float FulfillmentRate { get; set; }
    }
}
