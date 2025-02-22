﻿using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Service.NotificareService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificareController : ControllerBase
    {
        private readonly INotificareService _notificareService;

        public NotificareController(INotificareService notificareService)
        {
            _notificareService = notificareService;
        }

        // GET: api/notificare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificareDTO>>> GetAllNotifications()
        {
            var notificari = await _notificareService.GetAllNotificationsAsync();
            return Ok(notificari);
        }

        // GET: api/notificare/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificare>> GetNotificationById(int id)
        {
            var notificare = await _notificareService.GetNotificationByIdAsync(id);
            if (notificare == null)
            {
                return NotFound();
            }
            return Ok(notificare);
        }

        // POST: api/notificare
        [HttpPost]
        public async Task<ActionResult> AddNotification(NotificareDTO notificare)
        {
            if (await _notificareService.AddNotificationAsync(notificare))
                return Ok();
            return BadRequest();
        }

        // PUT: api/notificare/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, NotificareDTO notificare)
        {
            await _notificareService.UpdateNotificationAsync(id, notificare);
            return NoContent();
        }

        // DELETE: api/notificare/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notificare = await _notificareService.GetNotificationByIdAsync(id);
            if (notificare == null)
            {
                return NotFound();
            }

            await _notificareService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
