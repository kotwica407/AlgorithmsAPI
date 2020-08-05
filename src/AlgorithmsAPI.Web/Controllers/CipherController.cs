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
            string result = _cipherService.ExecCaesarCipher(Mode.Encrypt, dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("caesar/decode")]
        public async Task<IActionResult> GetCaesarCipherDecode([FromQuery] CipherCaesarDto dto)
        {
            string result = _cipherService.ExecCaesarCipher(Mode.Decrypt, dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("chao/encode")]
        public async Task<IActionResult> GetChaoCipherEncode([FromQuery] string input)
        {
            string result = _cipherService.ExecChaoCipher(Mode.Encrypt, input);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("chao/decode")]
        public async Task<IActionResult> GetChaoCipherDecode([FromQuery] string input)
        {
            string result = _cipherService.ExecChaoCipher(Mode.Decrypt, input);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("vigenere/encode")]
        public async Task<IActionResult> GetVigenereCipherEncode([FromQuery] CipherVigenereDto dto)
        {
            string result = _cipherService.ExecVigenereCipher(Mode.Encrypt, dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("vigenere/decode")]
        public async Task<IActionResult> GetVigenereCipherDecode([FromQuery] CipherVigenereDto dto)
        {
            string result = _cipherService.ExecVigenereCipher(Mode.Decrypt, dto);
            return Ok(result);
        }
    }
}