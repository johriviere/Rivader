using Microsoft.AspNetCore.Mvc;
using Rivader.Domain.Services;
using System.Threading.Tasks;

namespace Rivader.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaceInvaderController : ControllerBase
    {
        private readonly ISpaceInvadersService _spaceInvadersService;

        public SpaceInvaderController(ISpaceInvadersService spaceInvadersService)
        {
            _spaceInvadersService = spaceInvadersService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _spaceInvadersService.GetAll();
            return new JsonResult(result);
        }
    }
}
