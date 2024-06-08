namespace VendorManagementSystemAPI.Repositories.Interfaces
{
    public interface IPurchaseRepository<T>
    {
        Task<T> CreatePurchaseOrderAsync(T purchaseOrder);
        Task<List<T>> GetPurchaseOrdersAsync();
        Task<T?> GetPurchaseOrderByIdAsync(int id);
        Task<T> UpdatePurchaseOrderAsync(T purchaseOrder);
        Task RemovePurchaseOrderAsync(T purchaseOrder);
    }
}
