using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class CaesarCipherTests
    {
        [Theory]
        [InlineData("There's-a-starman-waiting-in-the-sky", 3, "Wkhuh'v-d-vwdupdq-zdlwlqj-lq-wkh-vnb")]
        [InlineData("There's-a-starman-waiting-in-the-sky", 26, "There's-a-starman-waiting-in-the-sky")]
        [InlineData("Hello_World!", 4, "Lipps_Asvph!")]
        public void CaesarCipherTesT(string input, int k, string expectedResult)
        {
            var caesarCipher = new CaesarCipherSolution();
            Assert.Equal(expectedResult, caesarCipher.EncryptString(input, k));
        }
    }
}