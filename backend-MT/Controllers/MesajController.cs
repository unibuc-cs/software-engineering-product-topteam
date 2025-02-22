﻿using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Service.MesajService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesajController : ControllerBase
    {
        private readonly IMesajService _mesajService;

        public MesajController(IMesajService mesajService)
        {
            _mesajService = mesajService;
        }

        // GET: api/mesaj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesajDTO>>> GetAllMessages()
        {
            var mesaje = await _mesajService.GetAllMessagesAsync();
            return Ok(mesaje);
        }

        // GET: api/mesaj/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesaj>> GetMessageById(int id)
        {
            var mesaj = await _mesajService.GetMessageByIdAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }
            return Ok(mesaj);
        }

        // POST: api/mesaj
        [HttpPost]
        public async Task<ActionResult> AddMessage(MesajDTO mesaj)
        {
            if (await _mesajService.AddMessageAsync(mesaj))
                return Ok();
            return BadRequest();
        }

        // PUT: api/mesaj/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, MesajDTO mesaj)
        {
            await _mesajService.UpdateMessageAsync(id, mesaj);
            return NoContent();
        }

        // DELETE: api/mesaj/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var mesaj = await _mesajService.GetMessageByIdAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }

            await _mesajService.DeleteMessageAsync(id);
            return NoContent();
        }
    }
}
