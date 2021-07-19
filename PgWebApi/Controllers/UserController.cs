using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PgWebApi.Data;
using PgWebApi.Models;

namespace PgWebApi.Controllers
{
	[ApiController]
	[Route("api/v1/user")]
	public class ItemsController : ControllerBase
	{
		private readonly IUserRepo _userRepo;

		public ItemsController(IUserRepo userRepo)
		{
			_userRepo = userRepo;
		}

		[HttpPost]
		public async Task<ActionResult<User>> CreateUserAsync(User user)
		{
			var newUser = await _userRepo.CreateUser(user);
			if (newUser == null)
			{
				return BadRequest();
			}

			return newUser;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<User>> GetUserByIdAsync(int userId)
		{
			// var result = await _userRepo.GetUserById(userId);            
			// return result;
			return await _userRepo.GetUserById(userId);
		}

		[HttpPut]
		public async Task<ActionResult<User>> UpdateUserPatchAsync(User user)
		{
			var updatedUser = await _userRepo.UpdateUser(user);
			return updatedUser;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteUserAsync(int id)
		{
			var result = await _userRepo.DeleteUser(id);
			return result;
		}

	}
}