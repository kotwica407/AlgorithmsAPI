using System.Net;
using System.Threading.Tasks;
using AlgorithmsAPI.Core.Dto;
using AlgorithmsAPI.Services.Ranking;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("")]
        public async Task<IActionResult> GetRanking([FromBody] RankingDto dto)
        {
            string[] result = _rankingService.GetRanking(dto);
            return Ok(result);
        }
    }
}