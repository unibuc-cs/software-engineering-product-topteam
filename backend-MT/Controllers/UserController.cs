// using backend_MT.Models;
// using backend_MT.Service.ElevService;
// using backend_MT.Service.ProfesorService;
// using Microsoft.AspNetCore.Mvc;
//
// namespace backend_MT.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private readonly IElevService _elevService;
//         private readonly IProfesorService _profesorService;
//
//         public UserController(IElevService elevService, IProfesorService profesorService)
//         {
//             _elevService = elevService;
//             _profesorService = profesorService;
//         }
//
//         // GET: api/user/students
//         [HttpGet("students")]
//         public async Task<ActionResult<IEnumerable<User>>> GetAllStudents()
//         {
//             var students = await _elevService.GetAllStudentsAsync();
//             return Ok(students);
//         }
//
//         // GET: api/user/teachers
//         [HttpGet("teachers")]
//         public async Task<ActionResult<IEnumerable<User>>> GetAllTeachers()
//         {
//             var teachers = await _profesorService.GetAllTeachersAsync();
//             return Ok(teachers);
//         }
//
//         // GET: api/user/students/{id}
//         [HttpGet("students/{id}")]
//         public async Task<ActionResult<User>> GetStudentById(string id)
//         {
//             var student = await _elevService.GetStudentByIdAsync(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return Ok(student);
//         }
//
//         // GET: api/user/teachers/{id}
//         [HttpGet("teachers/{id}")]
//         public async Task<ActionResult<User>> GetTeacherById(int id)
//         {
//             var teacher = await _profesorService.GetTeacherByIdAsync(id);
//             if (teacher == null)
//             {
//                 return NotFound();
//             }
//             return Ok(teacher);
//         }
//
//         // POST: api/user/students
//         [HttpPost("students")]
//         public async Task<ActionResult<User>> AddStudent(User student)
//         {
//             await _elevService.AddStudentAsync(student);
//             return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
//         }
//
//         // POST: api/user/teachers
//         [HttpPost("teachers")]
//         public async Task<ActionResult<User>> AddTeacher(User teacher)
//         {
//             await _profesorService.AddTeacherAsync(teacher);
//             return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
//         }
//
//         // PUT: api/user/students/{id}
//         [HttpPut("students/{id}")]
//         public async Task<IActionResult> UpdateStudent(int id, User student)
//         {
//             if (id != student.Id)
//             {
//                 return BadRequest();
//             }
//
//             await _elevService.UpdateStudentAsync(student);
//             return NoContent();
//         }
//
//         // PUT: api/user/teachers/{id}
//         [HttpPut("teachers/{id}")]
//         public async Task<IActionResult> UpdateTeacher(int id, User teacher)
//         {
//             if (id != teacher.Id)
//             {
//                 return BadRequest();
//             }
//
//             await _profesorService.UpdateTeacherAsync(teacher);
//             return NoContent();
//         }
//
//         // DELETE: api/user/students/{id}
//         [HttpDelete("students/{id}")]
//         public async Task<IActionResult> DeleteStudent(string id)
//         {
//             var student = await _elevService.GetStudentByIdAsync(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//
//             await _elevService.DeleteStudentAsync(id);
//             return NoContent();
//         }
//
//         // DELETE: api/user/teachers/{id}
//         [HttpDelete("teachers/{id}")]
//         public async Task<IActionResult> DeleteTeacher(int id)
//         {
//             var teacher = await _profesorService.GetTeacherByIdAsync(id);
//             if (teacher == null)
//             {
//                 return NotFound();
//             }
//
//             await _profesorService.DeleteTeacherAsync(id);
//             return NoContent();
//         }
//     }
// }
