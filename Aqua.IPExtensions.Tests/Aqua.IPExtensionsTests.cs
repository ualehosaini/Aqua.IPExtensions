using Xunit;

namespace Aqua.IPExtensions.Tests
{
    public class IPExtensionsTests
    {
        [Theory]
        [InlineData("192.168.4.254")]
        [InlineData("192.168.4.55")]
        [InlineData("192.168.4.1")]
        [InlineData("191.168.5.254")]
        [InlineData("191.168.5.33")]
        [InlineData("191.168.5.1")]
        [InlineData("10.0.0.254")]
        [InlineData("10.0.0.1")]
        [InlineData("169.254.1.1")]
        [InlineData("127.0.0.1")]
        [InlineData("0.0.0.0")]
        [InlineData("7")]
        public void IsValidIPv4_Valid(string ip)
        {
            Assert.True(ip.IsValidIPv4());
        }

        [Theory]
        [InlineData("259.168.4.254")]
        [InlineData("-1.168.4.55")]
        [InlineData("444.168.4.1")]
        [InlineData("-11.-99.9.1")]
        [InlineData("Foo")]
        [InlineData("127.0.0.333")]
        public void IsValidIPv4_InValid(string ip)
        {
            Assert.False(ip.IsValidIPv4());
        }

        [Theory]
        [InlineData("169.254.1.99")]
        [InlineData("169.254.0.88")]
        public void IsIPv4LinkLocalAddress_Valid(string ip)
        {
            Assert.True(ip.IsIPv4LinkLocalAddress());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        public void IsIPv4LinkLocalAddress_InValid(string ip)
        {
            Assert.False(ip.IsIPv4LinkLocalAddress());
        }

        [Theory]
        [InlineData("127.0.0.1")]
        public void IsIPv4LoopBack_Valid(string ip)
        {
            Assert.True(ip.IsIPv4LoopBack());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        public void IsIPv4LoopBack_InValid(string ip)
        {
            Assert.False(ip.IsIPv4LoopBack());
        }

        [Theory]
        [InlineData("127.0.0.1")]
        public void IsLocalHostv4_Valid(string ip)
        {
            Assert.True(ip.IsLocalHostv4());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        public void IsLocalHostv4_InValid(string ip)
        {
            Assert.False(ip.IsLocalHostv4());
        }
    }
}
