

using NUnit.Framework;
using System.Collections.Generic;

namespace GeneratingUniqueKey.Test
{
    [TestFixture]
    public class UniqueKeyGeneratorTest
    {
        [Test]
        public void Get_ShouldReturn_ValidLength()
        {
            var generator = new UniqueKeyGenerator();
            var result = generator.Get(8);
            Assert.AreEqual(8, result.Length);

            result = generator.Get(20);
            Assert.AreEqual(20, result.Length);

            result = generator.Get(100);
            Assert.AreEqual(100, result.Length);
        }

        [Test]
        public void Get_ShouldReturn_UniqueValues()
        {
            //int round = 10000;
            int round = 1000000;    // million
            int size = 20;
            var generator = new UniqueKeyGenerator();
            var uniqueKeys = new List<string>();
            for (int i = 0; i < round; i++)
            {
                var result = generator.Get(size);
                Assert.IsFalse(uniqueKeys.Contains(result));

                uniqueKeys.Add(result);
            }
        }
    }
}
