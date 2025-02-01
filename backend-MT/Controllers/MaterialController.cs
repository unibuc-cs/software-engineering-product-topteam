using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Service.MaterialeService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // GET: api/material
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllMaterials()
        {
            var materiale = await _materialService.GetAllMaterialsAsync();
            return Ok(materiale);
        }

        // GET: api/material/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterialById(int id)
        {
            var material = await _materialService.GetMaterialByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        // POST: api/material
        [HttpPost]
        public async Task<ActionResult> AddMaterial(MaterialDTO material)
        {
            if (await _materialService.AddMaterialAsync(material))
                return Ok();
            return BadRequest();
        }

        // PUT: api/material/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, MaterialDTO material)
        {
            await _materialService.UpdateMaterialAsync(id, material);
            return NoContent();
        }

        // DELETE: api/material/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _materialService.GetMaterialByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }
    }
}
