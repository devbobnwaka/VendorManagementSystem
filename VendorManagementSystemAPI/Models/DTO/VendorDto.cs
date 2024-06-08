﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VendorManagementSystemAPI.Models.DTO
{
    public class VendorDto
    {
        //[JsonIgnore]
        public int? Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string ContactDetails { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string VendorCode { get; set; } = null!;

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
