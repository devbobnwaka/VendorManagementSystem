using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Models.Entities;
using VendorManagementSystemAPI.Repositories.Interfaces;
using VendorManagementSystemAPI.Services.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace VendorManagementSystemAPI.Services
{
    public class VendorService(IVendorRepository<Vendor> vendorRepository) : IVendorService<VendorDto>
    {
        private readonly IVendorRepository<Vendor> _vendorRepository = vendorRepository;

        public async Task<VendorDto> CreateVendorAsync(VendorDto vendorDto)
        {
            Vendor vendor = new Vendor()
            {
                Name = vendorDto.Name,
                ContactDetails = vendorDto.ContactDetails,
                Address = vendorDto.Address,
                VendorCode = vendorDto.VendorCode,
                OnTimeDeliveryRate = vendorDto.OnTimeDeliveryRate,
                AverageResponseTime = vendorDto.AverageResponseTime,
                QualityRatingAvg = vendorDto.QualityRatingAvg,
                FulfillmentRate = vendorDto.FulfillmentRate,
            };
            Vendor newVendor = await _vendorRepository.CreateVendorAsync(vendor);
            VendorDto newVendorDto = new VendorDto()
            {
                Id = newVendor.Id,
                Name = newVendor.Name,
                ContactDetails = newVendor.ContactDetails,
                Address = newVendor.Address,
                VendorCode = newVendor.VendorCode,
                OnTimeDeliveryRate = newVendor.OnTimeDeliveryRate,
                AverageResponseTime = newVendor.AverageResponseTime,
                QualityRatingAvg = newVendor.QualityRatingAvg,
                FulfillmentRate = newVendor.FulfillmentRate,
            };
            return newVendorDto;
        }

        public async Task<VendorDto?> GetVendorByIdAsync(int id)
        {
            Vendor? vendor = await _vendorRepository.GetVendorByIdAsync(id);
            if (vendor == null) return null;
            return new VendorDto
            {
                Id = vendor.Id,
                Name = vendor.Name,
                ContactDetails = vendor.ContactDetails,
                Address = vendor.Address,
                VendorCode = vendor.VendorCode,
                OnTimeDeliveryRate = vendor.OnTimeDeliveryRate,
                AverageResponseTime = vendor.AverageResponseTime,
                QualityRatingAvg = vendor.QualityRatingAvg,
                FulfillmentRate = vendor.FulfillmentRate,
            };
        }

        public async Task<List<VendorDto>> GetVendorsAsync()
        {
            List<Vendor> vendors = await _vendorRepository.GetVendorsAsync();
            List<VendorDto> vendorDtos = vendors.Select(vendor => new VendorDto
            {
                Id = vendor.Id,
                Name = vendor.Name,
                ContactDetails = vendor.ContactDetails,
                Address = vendor.Address,
                VendorCode = vendor.VendorCode,
                OnTimeDeliveryRate = vendor.OnTimeDeliveryRate,
                AverageResponseTime = vendor.AverageResponseTime,
                QualityRatingAvg = vendor.QualityRatingAvg,
                FulfillmentRate = vendor.FulfillmentRate,
            }).ToList();
            return vendorDtos;
        }

        public async Task<bool> RemoveVendorAsync(int id)
        {
            Vendor? vendor = await _vendorRepository.GetVendorByIdAsync(Convert.ToInt32(id));
            if (vendor == null) return false;
            await _vendorRepository.RemoveVendorAsync(vendor);
            return true;
        }

        public async Task<VendorDto> UpdateVendorAsync(VendorDto vendorDto)
        {
            Vendor? vendor = await _vendorRepository.GetVendorByIdAsync(Convert.ToInt32(vendorDto.Id));
            if ( vendor == null) return new VendorDto();
            vendor.Name = vendorDto.Name;
            vendor.ContactDetails = vendorDto.ContactDetails;
            vendor.Address = vendorDto.Address;
            vendor.VendorCode = vendorDto.VendorCode;
            vendor.OnTimeDeliveryRate = vendorDto.OnTimeDeliveryRate;
            vendor.AverageResponseTime = vendorDto.AverageResponseTime;
            vendor.QualityRatingAvg = vendorDto.QualityRatingAvg;
            vendor.FulfillmentRate = vendorDto.FulfillmentRate;
            Vendor newVendor = await _vendorRepository.UpdateVendorAsync(vendor);
            VendorDto newVendorDto = new VendorDto()
            {
                Id = newVendor.Id,
                Name = newVendor.Name,
                ContactDetails = newVendor.ContactDetails,
                Address = newVendor.Address,
                VendorCode = newVendor.VendorCode,
                OnTimeDeliveryRate = newVendor.OnTimeDeliveryRate,
                AverageResponseTime = newVendor.AverageResponseTime,
                QualityRatingAvg = newVendor.QualityRatingAvg,
                FulfillmentRate = newVendor.FulfillmentRate,
            };
            return newVendorDto;
        }
    }
}
