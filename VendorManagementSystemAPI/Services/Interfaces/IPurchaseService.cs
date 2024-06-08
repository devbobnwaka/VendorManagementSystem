namespace VendorManagementSystemAPI.Services.Interfaces
{
    public interface IPurchaseService<T>
    {
        Task<T> CreatePurchaseOrderAsync(T purchaseOrderDto);
        Task<List<T>> GetPurchaseOrdersAsync();
        Task<T?> GetPurchaseOrderByIdAsync(int id);
        Task<T> UpdatePurchaseOrderAsync(T vendorDto);
        Task<bool> RemovePurchaseOrderAsync(int id);



    }
}
