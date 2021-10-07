using System;
using System.Linq;
using System.Threading.Tasks;
using AspJwt.Data;
using AspJwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspJwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IUserRepo _userRepo;

        public AuthController(IJwtAuthManager jwtAuthManager
            , IUserRepo userRepo
        )
        {
            this._jwtAuthManager = jwtAuthManager;
            this._userRepo = userRepo;
        }


        [HttpGet]
        public String GetInformation()
        {
            var currentUser = HttpContext.User;
            var data = currentUser.Claims.FirstOrDefault(c => c.Type == "userid").Value;
            System.Console.WriteLine(data);
            return "Something";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> AuthenticateAsync([FromBody] IdToken idToken)
        {
            var user = _jwtAuthManager.GoogleVerification(idToken);
            if (user == null)
            {
                return BadRequest();
            }

            user.Name = idToken.User;
            await _userRepo.CreateUser(user);

            var jwtToken = _jwtAuthManager.Authenticate(user.Sub, user.Email);
            if (jwtToken == null)
            {
                return Unauthorized();
            }

            return Ok(jwtToken);
        }
    }
}