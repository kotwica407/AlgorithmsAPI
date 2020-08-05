using System.Net;
using System.Threading.Tasks;
using AlgorithmsAPI.Core.Dto;
using AlgorithmsAPI.Services.Cipher;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CipherController : ControllerBase
    {
        private readonly ICipherService _cipherService;

        public CipherController(ICipherService cipherService)
        {
            _cipherService = cipherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hello world");
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("caesar/encode")]
        public async Task<IActionResult> GetCaesarCipherEncode([FromQuery] CipherCaesarDto dto)
        {
            string result = _cipherService.EncryptWithCaesarCipher(dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("caesar/decode")]
        public async Task<IActionResult> GetCaesarCipherDecode([FromQuery] CipherCaesarDto dto)
        {
            string result = _cipherService.DecryptWithCaesarCipher(dto);
            return Ok(result);
        }
    }
}