using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivader.Domain.Models;
using Rivader.Domain.Services;
using System.Threading.Tasks;

namespace Rivader.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationsService _translationsService;

        public TranslationController(ITranslationsService translationsService)
        {
            _translationsService = translationsService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _translationsService.Get(id);
            if (result == null)
            {
                return new NotFoundResult();
            }
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await _translationsService.Delete(id);
            return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromBody] Translation translation)
        {
            var result = await _translationsService.Create(translation);
            return new CreatedResult(string.Empty, result); // todo : location
        }
    }
}
