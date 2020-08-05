using AlgorithmsAPI.Core.Dto;
using AlgorithmsAPI.Services.Cipher;
using NUnit.Framework;

namespace AlgorithmsAPI.Tests
{
    [TestFixture]
    public class CipherTests
    {
        [Test]
        [TestCase("Pack my box with five dozen liquor jugs.", 5, "Ufhp rd gtc bnym knaj itejs qnvztw ozlx.")]
        public void CheckIfCaesarCipherWorksCorrectly(string input, int code, string encryptedInput)
        {
            var service = new CipherService();
            var dto = new CipherCaesarDto
            {
                Input = input,
                Code = code
            };
            string actual = service.EncryptWithCaesarCipher(dto);
            Assert.AreEqual(actual, encryptedInput);
        }
    }
}