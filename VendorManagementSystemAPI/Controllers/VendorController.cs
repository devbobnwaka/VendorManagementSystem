using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Services.Interfaces;
using VendorManagementSystemAPI.Utils;

namespace VendorManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private IVendorService<VendorDto> _vendorService;

        public VendorController(IVendorService<VendorDto> vendorService) 
        {
            this._vendorService = vendorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VendorDto>>> GetVendors()
        {
            List<VendorDto> vendorsDto = await _vendorService.GetVendorsAsync();
            return Ok(vendorsDto);
        }

        [HttpGet("{vendor_id:int}", Name="GetVendor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<VendorDto>>> GetVendorById(int vendor_id)
        {
            VendorDto? vendorDto = await _vendorService.GetVendorByIdAsync(vendor_id);
            if (vendorDto == null) return NotFound();
            return Ok(vendorDto);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VendorDto>> CreateVendorAsync([FromBody]VendorDto vendorDto)
        {
            if (vendorDto == null) return BadRequest(vendorDto);
            VendorDto newVendorDto = await _vendorService.CreateVendorAsync(vendorDto);
            return CreatedAtRoute("GetVendor", new { id = newVendorDto.Id }, newVendorDto);
        }

        [HttpPut("{vendor_id:int}", Name = "UpdateVendor")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVendorAsync(int vendor_id, [FromBody] VendorDto vendorDto)
        {
            try
            {
                if (vendor_id != vendorDto.Id) return BadRequest(vendorDto);
                VendorDto newVendorDto = await _vendorService.UpdateVendorAsync(vendorDto);
                if (newVendorDto.Id == null) return NotFound();
            }
            catch (Exception ex)
            {
                Errors errorDetails = new Errors();
                errorDetails.ErrorMessages.Add(ex.Message);
                return BadRequest(errorDetails);
            }
            return NoContent();
        }


        [HttpDelete("{vendor_id:int}", Name = "DeleteVendor")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteVendorAsync(int vendor_id)
        {
            try
            {
                if(!await _vendorService.RemoveVendorAsync(vendor_id))  NotFound();
            }
            catch (Exception ex)
            {
                Errors errorDetails = new Errors();
                errorDetails.ErrorMessages.Add(ex.Message);
                return BadRequest(errorDetails);
            }
            return NoContent();
        }
    }
}
