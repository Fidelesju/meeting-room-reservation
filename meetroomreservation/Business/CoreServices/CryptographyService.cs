using meetroomreservation.CoreServices.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace meetroomreservation.CoreServices
{
    public class CryptographyService : ICryptographyService
    {
        public string GetMd5Crypto(string input)
        {
            MD5 md5; //Instância da classe MD5 para calcular o hash
            byte[] inputBytes; // Array de bytes que representa a entrada de texto
            byte[] hashBytes; // Array de bytes para armazenar o hash calculado
            StringBuilder stringBuilder; // Para construir a representação hexadecimal do hash
            int i; // Variavel de loop
            int length; // Comprimento do array de bytes
            string text; // Representação hexadecimal de um byte

            using (md5 = MD5.Create())
            {
                inputBytes = Encoding.ASCII.GetBytes(input); // Converte a entrada em bytes
                hashBytes = md5.ComputeHash(inputBytes); // Calcula o hash MD5
                stringBuilder = new StringBuilder();

                for (i = 0, length = hashBytes.Length; i < length; i++)
                {
                    text = hashBytes[i].ToString("X2"); // Converte um byte em representação hexadecimal
                    stringBuilder.Append(text); // Adiciona o byte ao resultado final
                }
            }
            return stringBuilder.ToString(); // Retorna o hash MD5 como uma string hexadecimal

        }
    }
}