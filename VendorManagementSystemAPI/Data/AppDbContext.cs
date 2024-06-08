using Microsoft.EntityFrameworkCore;
using VendorManagementSystemAPI.Models.Entities;

namespace VendorManagementSystemAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<HistoricalPerformance> HistoricalPerformances { get; set; }
    }
}
