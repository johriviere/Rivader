using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> Get(int id)
        {
            var result = await _translationsService.GetById(id);
            return new JsonResult(result);
        }
    }
}
