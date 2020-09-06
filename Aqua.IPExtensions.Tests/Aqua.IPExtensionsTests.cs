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


        [Theory]
        [InlineData("0.0.0.0")]
        public void IsIPv4IsZero_Valid(string ip)
        {
            Assert.True(ip.IsIPv4IsZero());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        public void IsIPv4IsZero_InValid(string ip)
        {
            Assert.False(ip.IsIPv4IsZero());
        }

        [Theory]
        [InlineData("192.168.5.85/10")]
        [InlineData("10.200.240.50/20")]
        [InlineData("10.200.240.50/24")]
        public void IsValidSubnetIPv4Mask_Valid(string ip)
        {
            Assert.True(ip.IsValidSubnetIPv4Mask());
        }

        [Theory]
        [InlineData("192.168.5.85/400")]
        [InlineData("10.200.240.50/300")]
        [InlineData("10.200.240.500/24")]
        public void IsValidSubnetIPv4Mask_InValid(string ip)
        {
            Assert.False(ip.IsValidSubnetIPv4Mask());
        }

        [Theory]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334")]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e::5")]
        [InlineData("2001:0db8:85a3:0000:0000::2:7335")]
        [InlineData("::1234:5678")]
        [InlineData("2001:db8::")]
        [InlineData("1::5")]
        [InlineData("::")]
        [InlineData("::1")]
        public void IsValidIPv6_Valid(string ip)
        {
            Assert.True(ip.IsValidIPv6());
        }

        [Theory]
        [InlineData("259.168.4.254")]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370")]
        [InlineData("1200:0000:AB00:1234:O000:2552:7777:1313")]
        [InlineData("0.0.0.5")]
        [InlineData("Foo")]
        [InlineData("7")]
        public void IsValidIPv6_InValid(string ip)
        {
            Assert.False(ip.IsValidIPv6());
        }

        [Theory]
        [InlineData("fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("febf:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsIPv6LinkLocalAddress_Valid(string ip)
        {
            Assert.True(ip.IsIPv6LinkLocalAddress());
        }

        [Theory]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsIPv6LinkLocalAddress_InValid(string ip)
        {
            Assert.False(ip.IsIPv6LinkLocalAddress());
        }

        [Theory]
        [InlineData("::1")]
        public void IsIPv6LoopBack_Valid(string ip)
        {
            Assert.True(ip.IsIPv6LoopBack());
        }

        [Theory]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsIPv6LoopBack_InValid(string ip)
        {
            Assert.False(ip.IsIPv6LoopBack());
        }

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
        [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334")]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e::5")]
        [InlineData("2001:0db8:85a3:0000:0000::2:7335")]
        [InlineData("::1234:5678")]
        [InlineData("2001:db8::")]
        [InlineData("1::5")]
        [InlineData("::")]
        [InlineData("::1")]
        public void IsValidIPv4Orv6_Valid(string ip)
        {
            Assert.True(ip.IsValidIPv4Orv6());
        }

        [Theory]
        [InlineData("259.168.4.254")]
        [InlineData("-1.168.4.55")]
        [InlineData("444.168.4.1")]
        [InlineData("-11.-99.9.1")]
        [InlineData("Foo")]
        [InlineData("127.0.0.333")]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370")]
        [InlineData("1200:0000:AB00:1234:O000:2552:7777:1313")]
        public void IsValidIPv4Orv6_InValid(string ip)
        {
            Assert.False(ip.IsValidIPv4Orv6());
        }

        [Theory]
        [InlineData("127.0.0.1")]
        [InlineData("::1")]
        public void IsLoopBack_Valid(string ip)
        {
            Assert.True(ip.IsLoopBack());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsLoopBack_InValid(string ip)
        {
            Assert.False(ip.IsLoopBack());
        }


    }
}
