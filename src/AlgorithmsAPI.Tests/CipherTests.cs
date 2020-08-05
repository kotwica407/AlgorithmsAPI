using AlgorithmsAPI.Core.Dto;
using AlgorithmsAPI.Services.Cipher;
using NUnit.Framework;

namespace AlgorithmsAPI.Tests
{
    [TestFixture]
    public class CipherTests
    {
        [Test]
        [TestCase("Pack my box with five dozen liquor jugs.",
            5,
            "Ufhp rd gtc bnym knaj itejs qnvztw ozlx.",
            Mode.Encrypt)]
        [TestCase("Ufhp rd gtc bnym knaj itejs qnvztw ozlx.",
            5,
            "Pack my box with five dozen liquor jugs.",
            Mode.Decrypt)]
        public void CheckIfCaesarCipherWorksCorrectly(string input, int code, string encryptedInput, Mode mode)
        {
            var service = new CipherService();
            var dto = new CipherCaesarDto
            {
                Input = input,
                Code = code
            };
            string actual = service.ExecCaesarCipher(mode, dto);
            Assert.AreEqual(encryptedInput, actual);
        }

        [Test]
        [TestCase("WELLDONEISBETTERTHANWELLSAID",
            "OAHQHCNYNXTSZJRRHJBYHQKSOUJY",
            Mode.Encrypt)]
        [TestCase("OAHQHCNYNXTSZJRRHJBYHQKSOUJY",
            "WELLDONEISBETTERTHANWELLSAID",
            Mode.Decrypt)]
        public void CheckIfChaoCipherWorksCorrectly(string input, string encryptedInput, Mode mode)
        {
            var service = new CipherService();
            string actual = service.ExecChaoCipher(mode, input);
            Assert.AreEqual(encryptedInput, actual);
        }

        [Test]
        [TestCase("Beware the Jabberwock, my son! The jaws that bite, the claws that catch!",
            "VIGENERECIPHER",
            "WMCEEIKLGRPIFVMEUGXQPWQVIOIAVEYXUEKFKBTALVXTGAFXYEVKPAGY",
            Mode.Encrypt)]
        [TestCase("WMCEEIKLGRPIFVMEUGXQPWQVIOIAVEYXUEKFKBTALVXTGAFXYEVKPAGY",
            "VIGENERECIPHER",
            "BEWARETHEJABBERWOCKMYSONTHEJAWSTHATBITETHECLAWSTHATCATCH",
            Mode.Decrypt)]
        public void CheckIfVigenereCipherWorksCorrectly(string input, string key, string encryptedInput, Mode mode)
        {
            var service = new CipherService();
            var dto = new CipherVigenereDto
            {
                Input = input,
                Key = key
            };
            string actual = service.ExecVigenereCipher(mode, dto);
            Assert.AreEqual(encryptedInput, actual);
        }
    }
}