using VendorManagementSystemAPI.Models.Entities;

namespace VendorManagementSystemAPI.Repositories.Interfaces
{
    public interface IVendorRepository<T>
    {
        Task<List<T>> GetVendorsAsync();
        Task<T?> GetVendorByIdAsync(int id);
        Task<T> CreateVendorAsync(T vendor);
        Task<T> UpdateVendorAsync(T vendor);
        Task RemoveVendorAsync(T vendor);
    }
}
