using Articles.Application.Interfaces;
using Articles.Application.Validation;
using Articles.Application.Validation.Util;
using Articles.Application.ViewModel;
using Articles.Entities.Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleApplication _article;
        private readonly IUserApplication _user;

        public ArticleController(IArticleApplication article, IUserApplication user)
        {
            _article = article;
            _user = user;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        public async Task<IActionResult> Get() => Ok(await _article.GetAll());

        [HttpPost]
        [Authorize(Roles = nameof(RoleType.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateArticleViewModel model)
        {
            if (model == null)
                return NoContent();
            var validation = new CreateArticleValidation().Validate(model);

            if (!validation.IsValid)
                return BadRequest(new Validator(validation));

            var article = await _article.Create(model, User.FindFirst(ClaimTypes.Hash).Value);

            return Ok(article);
        }

        [HttpPost]
        [Route("Like")]
        [Authorize(Roles = nameof(RoleType.Admin))]
        public async Task<IActionResult> Like([FromBody]ArticleLikeViewModel model)
        {
            if (model == null)
                return NoContent();

            var user = await _user.GetByHash(User.FindFirst(ClaimTypes.Hash).Value);
            model.IdUser = user.Id;

            var validation = new ArticleLikeValidation(_article).Validate(model);

            if (!validation.IsValid)
                return BadRequest(new Validator(validation));

            return Ok(await _article.Like(model));
        }

        [HttpPost]
        [Route("Dislike")]
        [Authorize(Roles = nameof(RoleType.Admin))]
        public async Task<IActionResult> Dislike([FromBody] ArticleLikeViewModel model)
        {
            if (model == null)
                return NoContent();

            var user = await _user.GetByHash(User.FindFirst(ClaimTypes.Hash).Value);
            model.IdUser = user.Id;

            var validation = new ArticleDisLikeValidation(_article).Validate(model);

            if (!validation.IsValid)
                return BadRequest(new Validator(validation));

            return Ok(await _article.Dislike(model));
        }
    }
}
