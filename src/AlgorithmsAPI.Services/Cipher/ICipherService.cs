using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Cipher
{
    public interface ICipherService
    {
        string ExecCaesarCipher(Mode mode, CipherCaesarDto dto);
        string ExecChaoCipher(Mode mode, string input);
        string ExecVigenereCipher(Mode mode, CipherVigenereDto dto);
    }
}