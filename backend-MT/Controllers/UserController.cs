﻿//using backend_MT.Models;
//using backend_MT.Service.ElevService;
//using Microsoft.AspNetCore.Mvc;

//namespace backend_MT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IElevService _elevService;

//        public UserController(IElevService elevService)
//        {
//            _elevService = elevService;
//        }

//        // GET: api/elev
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetAllStudents()
//        {
//            var elevi = await _elevService.GetAllStudentsAsync();
//            return Ok(elevi);
//        }

//        // GET: api/elev/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetStudentById(string id)
//        {
//            var elev = await _elevService.GetStudentByIdAsync(id);
//            if (elev == null)
//            {
//                return NotFound();
//            }
//            return Ok(elev);
//        }

//        // POST: api/elev
//        [HttpPost]
//        public async Task<ActionResult<User>> AddStudent(User elev)
//        {
//            await _elevService.AddStudentAsync(elev);
//            return CreatedAtAction(nameof(GetStudentById), new { id = elev.Id }, elev); // Asumând că Elev are o proprietate Id
//        }

//        // PUT: api/elev/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateStudent(string id, User elev)
//        {
//            if (id != elev.Id) // Verifică dacă ID-urile se potrivesc
//            {
//                return BadRequest();
//            }

//            await _elevService.UpdateStudentAsync(elev);
//            return NoContent();
//        }

//        // DELETE: api/elev/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudent(string id)
//        {
//            var elev = await _elevService.GetStudentByIdAsync(id);
//            if (elev == null)
//            {
//                return NotFound();
//            }

//            await _elevService.DeleteStudentAsync(id);
//            return NoContent();
//        }
//    }
//}