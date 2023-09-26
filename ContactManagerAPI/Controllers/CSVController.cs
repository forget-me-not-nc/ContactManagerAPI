using BLL.DTOs.ContacInfoDTOs;
using BLL.Services.ImportServices;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSVController: ControllerBase
    {
        private readonly ICSVImporter _csvImporter;

        public CSVController(ICSVImporter csvImporter)
        {
            _csvImporter = csvImporter;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ContactResponse>>> ImportCSV([FromForm] IFormCollection form)
        {
            try
            {
                return Ok(await _csvImporter.Import(form.Files["file"]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
