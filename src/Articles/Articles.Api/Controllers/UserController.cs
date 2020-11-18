using Articles.Application.Interfaces;
using Articles.Application.Validation;
using Articles.Application.Validation.Util;
using Articles.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserApplication _user;

        public UserController(IUserApplication user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel model)
        {
            if (model == null)
                return NoContent();

            var validation = new CreateUserValidation(_user).Validate(model);

            if (!validation.IsValid)
                return BadRequest(new Validator(validation));

            await _user.Create(model);

            return Ok();
        }
    }
}
