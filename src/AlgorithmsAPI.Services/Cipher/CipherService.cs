using System;
using System.Linq;
using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Cipher
{
    public class CipherService : ICipherService
    {
        private const string L_ALPHABET = "HXUCZVAMDSLKPEFJRIGTWOBNYQ";
        private const string R_ALPHABET = "PTLNBQDEOYSFAVZKGJRIHWXUMC";

        public string ExecCaesarCipher(Mode mode, CipherCaesarDto dto)
        {
            return mode == Mode.Encrypt
                ? new string(dto.Input.Select(ch => Encrypt(ch, dto.Code)).ToArray())
                : new string(dto.Input.Select(ch => Encrypt(ch, 26 - dto.Code)).ToArray());
        }

        public string ExecChaoCipher(Mode mode, string input)
        {
            char[] left = L_ALPHABET.ToCharArray();
            char[] right = R_ALPHABET.ToCharArray();
            char[] eText = new char[input.Length];
            char[] temp = new char[26];

            for (var i = 0; i < input.Length; i++)
            {
                var index = 0;
                if (mode == Mode.Encrypt)
                {
                    index = Array.IndexOf(right, input[i]);
                    eText[i] = left[index];
                }
                else
                {
                    index = Array.IndexOf(left, input[i]);
                    eText[i] = right[index];
                }

                if (i == input.Length - 1)
                    break;

                for (int j = index; j < 26; ++j) temp[j - index] = left[j];
                for (var j = 0; j < index; ++j) temp[26 - index + j] = left[j];
                char store = temp[1];
                for (var j = 2; j < 14; ++j) temp[j - 1] = temp[j];
                temp[13] = store;
                temp.CopyTo(left, 0);

                for (int j = index; j < 26; ++j) temp[j - index] = right[j];
                for (var j = 0; j < index; ++j) temp[26 - index + j] = right[j];
                store = temp[0];
                for (var j = 1; j < 26; ++j) temp[j - 1] = temp[j];
                temp[25] = store;
                store = temp[2];
                for (var j = 3; j < 14; ++j) temp[j - 1] = temp[j];
                temp[13] = store;
                temp.CopyTo(right, 0);
            }

            return new string(eText);
        }

        public string ExecVigenereCipher(Mode mode, CipherVigenereDto dto)
        {
            int d = mode == Mode.Encrypt ? 1 : -1;
            int pwi = 0, tmp;
            var ns = "";
            dto.Input = dto.Input.ToUpper();
            dto.Key = dto.Key.ToUpper();
            foreach (char t in dto.Input)
            {
                if (t < 65) continue;
                tmp = t - 65 + d * (dto.Key[pwi] - 65);
                if (tmp < 0) tmp += 26;
                ns += Convert.ToChar(65 + tmp % 26);
                if (++pwi == dto.Key.Length) pwi = 0;
            }

            return ns;
        }

        private char Encrypt(char ch, int code)
        {
            if (!char.IsLetter(ch)) return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char) ((ch + code - offset) % 26 + offset);
        }
    }
}