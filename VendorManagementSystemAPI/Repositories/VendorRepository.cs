using Microsoft.EntityFrameworkCore;
using VendorManagementSystemAPI.Data;
using VendorManagementSystemAPI.Models.Entities;
using VendorManagementSystemAPI.Repositories.Interfaces;

namespace VendorManagementSystemAPI.Repositories
{
    public class VendorRepository(AppDbContext dbContext) : IVendorRepository<Vendor>
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Vendor> CreateVendorAsync(Vendor vendor)
        {
            await _dbContext.Vendors.AddAsync(vendor);
            await _dbContext.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor?> GetVendorByIdAsync(int id)
        {
            return await _dbContext.Vendors.FindAsync(id);
        }

        public async Task<List<Vendor>> GetVendorsAsync()
        {
            return await _dbContext.Vendors.ToListAsync();
        }

        public async Task RemoveVendorAsync(Vendor vendor)
        {
            _dbContext.Vendors.Remove(vendor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Vendor> UpdateVendorAsync(Vendor vendor)
        {
            _dbContext.Entry(vendor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return vendor;
        }
    }
}
