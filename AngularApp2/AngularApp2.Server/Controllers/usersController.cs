using AngularApp2.Server.GeneralIDataService;
using AngularApp2.Server.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class usersController : ControllerBase
    {
        private readonly IDataService _data;
        public usersController(IDataService data)
        {
            _data = data;
        }




        [HttpGet ("Login/{Email}/{Password}")] //هيك مبعوت بال URL 
        public IActionResult Login(string Email, string Password)
        {
            if (Email == null || Password==null)
            {
                return BadRequest();
            }

            var exits = _data.LoginUser(Email,Password);
            if (exits)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromForm] LoginUserDto Userdto)
        {
            if (Userdto != null)
            {
                var result = _data.LoginUser(Userdto);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }




        [ProducesResponseType(202)]
        [ProducesResponseType(207)]
        [ProducesResponseType(400)]
        [ProducesResponseType(402)]

        [HttpGet("ShowUsers")]
        public IActionResult ShowUsers()
        {
            var users = _data.ShowUsers();
            return Ok(users);

        }


        [HttpPost("Register")]
        public IActionResult Register ([FromForm]RegestrationDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

           bool data = _data.Register(user);
            if (data==false)
                return BadRequest("A user with this email already exists.");
            else 
            return Ok();
        }

    }
}
