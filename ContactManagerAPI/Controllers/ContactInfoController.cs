using BLL.DTOs.ContacInfoDTOs;
using BLL.Services.ContactInfoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ContactManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoController: ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;
        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponse>>> GetAll()
        {
            try
            {
                return Ok(await _contactInfoService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponse>> GetById(int id)
        {
            try
            {
                return Ok(await _contactInfoService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ContactResponse>> Create([FromBody] CreateContactRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _contactInfoService.CreateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ContactResponse>> Update([FromBody] UpdateContactRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _contactInfoService.UpdateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _contactInfoService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
