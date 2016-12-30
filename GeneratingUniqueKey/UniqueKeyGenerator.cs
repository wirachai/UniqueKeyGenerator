using System.Security.Cryptography;
using System.Text;

namespace GeneratingUniqueKey
{
    public class UniqueKeyGenerator
    {
        private RNGCryptoServiceProvider randomer;
        private readonly string characters;

        public UniqueKeyGenerator() : this("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        {

        }

        public UniqueKeyGenerator(string characters)
        {
            this.characters = characters;
            this.randomer = new RNGCryptoServiceProvider();
        }

        public string Get(int size)
        {
            char[] chars = characters.ToCharArray();
            byte[] data = new byte[size];
            randomer.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
    }
}
