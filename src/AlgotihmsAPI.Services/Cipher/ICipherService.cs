using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Cipher
{
    public interface ICipherService
    {
        string EncryptWithCaesarCipher(CipherCaesarDto dto);
        string DecryptWithCaesarCipher(CipherCaesarDto dto);
    }
}