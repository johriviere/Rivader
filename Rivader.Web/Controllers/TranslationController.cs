using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivader.Domain.Core;
using Rivader.Domain.Core.Exceptions;
using Rivader.Domain.Models;
using Rivader.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Rivader.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITranslationsService _translationsService;

        public TranslationController(IUnitOfWork unitOfWork, ITranslationsService translationsService)
        {
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
            _translationsService = translationsService ?? throw new System.ArgumentNullException(nameof(translationsService));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> Delete(int id)
        {
            await _translationsService.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Translation translation)
        {
            var result = await _translationsService.Create(translation);
            await _unitOfWork.SaveChangesAsync();

            string location = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.Path}/{result.Id}";
            return new CreatedResult(location, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Translation translation)
        {
            if (translation == null)
            {
                throw new BadRequestException($"translation is null.");
            }
            if (translation.CulturedLabels == null)
            {
                throw new BadRequestException($"translation does not contain any cultured label.");
            }
            if (translation.CulturedLabels.Any(x => x.Id == default))
            {
                throw new BadRequestException($"translation contains cultured label with invalid id.");
            }

            await _translationsService.Update(id, translation);
            await _unitOfWork.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
