using VendorManagementSystemAPI.Models.DTO;

namespace VendorManagementSystemAPI.Services.Interfaces
{
    public interface IVendorService<T>
    {
        Task<List<T>> GetVendorsAsync();
        Task<T?> GetVendorByIdAsync(int id);
        Task<T> CreateVendorAsync(T vendorDto);
        Task<T> UpdateVendorAsync(T vendorDto);
        Task<bool> RemoveVendorAsync(int id);
    }
}
