using System.Linq;
using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Cipher
{
    public class CipherService : ICipherService
    {
        public string EncryptWithCaesarCipher(CipherCaesarDto dto) =>
            new string(dto.Input.Select(ch => Encrypt(ch, dto.Code)).ToArray());

        public string DecryptWithCaesarCipher(CipherCaesarDto dto) =>
            new string(dto.Input.Select(ch => Encrypt(ch, 26 - dto.Code)).ToArray());

        private char Encrypt(char ch, int code)
        {
            if (!char.IsLetter(ch)) return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char) ((ch + code - offset) % 26 + offset);
        }
    }
}