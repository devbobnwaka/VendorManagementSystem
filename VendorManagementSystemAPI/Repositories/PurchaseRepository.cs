using Microsoft.EntityFrameworkCore;
using System.Numerics;
using VendorManagementSystemAPI.Data;
using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Models.Entities;
using VendorManagementSystemAPI.Repositories.Interfaces;

namespace VendorManagementSystemAPI.Repositories
{
    public class PurchaseRepository(AppDbContext dbContext) : IPurchaseRepository<PurchaseOrder>
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<PurchaseOrder> CreatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            await _dbContext.PurchaseOrders.AddAsync(purchaseOrder);
            await _dbContext.SaveChangesAsync();
            return purchaseOrder;
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrders.FindAsync(id);
        }

        public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
        {
            return await _dbContext.PurchaseOrders.ToListAsync();
        }

        public Task RemovePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseOrder> UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }
    }
}
