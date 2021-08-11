using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.UserApi.Model;

namespace UserBackEnd.UserApi.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get user By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _userService.Get(id); 
            
            // Don't like this
            if (model == null)
                return NotFound();
            
            return Ok(model);
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]UserCreateModelView form)
        {
            var model = await _userService.Add(new User
            {
                Email = form.Email,
                Password = form.Password,
                IdentificationTypeId = form.IdentificationTypeId,
                IdentificationNumber = form.IdentificationNumber,
                LastName = form.LastName,
                Name = form.Name
            });

            return Ok(model);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id">Id User to update</param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UserCreateModelView form)
        {
            var model = await _userService.Update(new User
            {
                Email = form.Email,
                Password = form.Password,
                IdentificationTypeId = form.IdentificationTypeId,
                IdentificationNumber = form.IdentificationNumber,
                LastName = form.LastName,
                Name = form.Name,
                UserId = id
            });

            return NoContent();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">Id User to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
