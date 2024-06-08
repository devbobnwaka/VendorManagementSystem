using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Services;
using VendorManagementSystemAPI.Services.Interfaces;

namespace VendorManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseService<PurchaseDto> _purchaseService;

        public PurchaseOrderController(IPurchaseService<PurchaseDto> purchaseService) 
        { 
            this._purchaseService = purchaseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PurchaseDto>> CreatePurchaseOrderAsync([FromBody]PurchaseDto purchaseDto)
        {
            if (purchaseDto == null) return BadRequest(purchaseDto);
            return new JsonResult(purchaseDto);
            //PurchaseDto newPoDto = await _purchaseService.CreatePurchaseOrderAsync(purchaseDto);
            //return CreatedA tRoute("GetPurchaseOrder", new { id = newPoDto.Id }, newPoDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrderByIdAsync(int id)
        {
            PurchaseDto? purchaseDto = await _purchaseService.GetPurchaseOrderByIdAsync(id);
            if (purchaseDto == null) return NotFound();
            return Ok(purchaseDto);
        }
    }
}
