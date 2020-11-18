using System.Threading.Tasks;
using Articles.Api.Security;
using Articles.Application.Interfaces;
using Articles.Application.Validation;
using Articles.Application.Validation.Util;
using Articles.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserApplication _user;
        private readonly IConfiguration _configuration;

        public LoginController(IUserApplication user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel model)
        {
            if (model == null)
                return NoContent();

            var validation = new LoginValidation(_user).Validate(model);

            if (!validation.IsValid)
                return BadRequest(new Validator(validation));

            var user = await _user.Authenticate(model.Login, model.Password);

            if (user == null)
                return NotFound();
            else
                return Ok(new { token = new JWTToken(_configuration).Generate(user) });
        }
    }
}
