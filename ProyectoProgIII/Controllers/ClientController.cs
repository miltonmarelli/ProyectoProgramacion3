using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.Services;
using Proyecto.Application.Models;
using Proyecto.Application.IServices;
using Proyecto.Application.Models.Request;
using Proyecto.Application.Models.Dtos;

namespace Proyecto.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUserService _userService;

        public ClientController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var user = _userService.GetByName(name);
            if (user == null)
            {
                return NotFound($"Usuario con nombre '{name}' no encontrado.");
            }
            return Ok(user);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Create(UserSaveRequest user)
        {
            try
            {
                var newUser = _userService.Create(user);
                return Ok(newUser.Name);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserSaveRequest user)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(id, user);
                return Ok(updatedUser);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}