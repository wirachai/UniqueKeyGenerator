using System.Security.Cryptography;
using System.Text;

namespace GeneratingUniqueKey
{
    public class UniqueKeyGenerator
    {
        private RNGCryptoServiceProvider randomer;
        private readonly char[] characters;

        public UniqueKeyGenerator() : this("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        {

        }

        public UniqueKeyGenerator(string characters)
        {
            this.randomer = new RNGCryptoServiceProvider();
            this.characters = characters.ToCharArray();
        }

        public string Get(int size)
        {
            byte[] data = new byte[size];
            randomer.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(characters[b % (characters.Length - 1)]);
            }
            return result.ToString();
        }
    }
}
