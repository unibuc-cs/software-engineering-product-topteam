using backend_MT.Models;
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
        public async Task<ActionResult<IEnumerable<Material>>> GetAllMaterials()
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
        public async Task<ActionResult<Material>> AddMaterial(Material material)
        {
            await _materialService.AddMaterialAsync(material);
            return CreatedAtAction(nameof(GetMaterialById), new { id = material.IdMaterial }, material); // Asumând că Material are o proprietate Id
        }

        // PUT: api/material/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, Material material)
        {
            if (id != material.IdMaterial) // Verifică dacă ID-urile se potrivesc
            {
                return BadRequest();
            }

            await _materialService.UpdateMaterialAsync(material);
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
