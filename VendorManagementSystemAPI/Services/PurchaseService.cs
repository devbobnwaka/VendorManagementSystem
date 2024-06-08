using System.ComponentModel.DataAnnotations;
using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Models.Entities;
using VendorManagementSystemAPI.Services.Interfaces;
using System.Text.Json;
using VendorManagementSystemAPI.Repositories.Interfaces;
using VendorManagementSystemAPI.Repositories;

namespace VendorManagementSystemAPI.Services
{
    public class PurchaseService(IPurchaseRepository<PurchaseOrder> purchaseOrderRepository) : IPurchaseService<PurchaseDto>
    {
        private readonly IPurchaseRepository<PurchaseOrder> _purchaseOrderRepository = purchaseOrderRepository;

        public async Task<PurchaseDto> CreatePurchaseOrderAsync(PurchaseDto purchaseOrderDto)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                VendorId = purchaseOrderDto.VendorId,
                PoNumber = Guid.NewGuid(),
                OrderDate = DateTime.Today,
                DeliveryDate = purchaseOrderDto.DeliveryDate,
                Items = JsonSerializer.Serialize(purchaseOrderDto.Items),
                Quantity = purchaseOrderDto.Quantity,
                Status = purchaseOrderDto.Status,
                QualityRating = purchaseOrderDto.QualityRating,
                IssueDate = purchaseOrderDto.IssueDate != null ? DateTime.Parse(purchaseOrderDto.IssueDate) : null,
                AcknowledgmentDate = purchaseOrderDto.AcknowledgmentDate != null ? DateTime.Parse(purchaseOrderDto.AcknowledgmentDate) : null,
            };
            await _purchaseOrderRepository.CreatePurchaseOrderAsync(purchaseOrder);
            return purchaseOrderDto;
        }

        public async Task<PurchaseDto?> GetPurchaseOrderByIdAsync(int id)
        {
            PurchaseOrder? pOrder = await _purchaseOrderRepository.GetPurchaseOrderByIdAsync(id);
            if (pOrder == null) return null;
            return new PurchaseDto
            {
                Id = pOrder.Id,
                VendorId = pOrder.VendorId,
                PoNumber = pOrder.PoNumber.ToString(),
                //OrderDate = pOrder.OrderDate.ToString(),
                DeliveryDate = pOrder.DeliveryDate,
                Items = pOrder.Items != null ? JsonSerializer.Deserialize<List<string>>(pOrder.Items) : [],
                Quantity = pOrder.Quantity,
                Status = pOrder.Status,
                QualityRating = pOrder.QualityRating,
                IssueDate = pOrder.IssueDate.ToString(),
                AcknowledgmentDate = pOrder.AcknowledgmentDate.ToString(),
            };
        }

        public Task<List<PurchaseDto>> GetPurchaseOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePurchaseOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseDto> UpdatePurchaseOrderAsync(PurchaseDto vendorDto)
        {
            throw new NotImplementedException();
        }

        //public 
    }
}
