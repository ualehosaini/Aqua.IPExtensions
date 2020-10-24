using System.Net;
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

        [Theory]
        [InlineData("::")]
        [InlineData("0000:0000:0000:0000:0000:0000:0000:0000")]
        public void IsIPv6IsZero_Valid(string ip)
        {
            Assert.True(ip.IsIPv6IsZero());
        }

        [Theory]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsIPv6IsZero_InValid(string ip)
        {
            Assert.False(ip.IsIPv6IsZero());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        [InlineData("fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("febf:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsLinkLocalAddress_Valid(string ip)
        {
            Assert.True(ip.IsLinkLocalAddress());
        }

        [Theory]
        [InlineData("169.254.1.99")]
        [InlineData("169.254.0.88")]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsLinkLocalAddress_InValid(string ip)
        {
            Assert.False(ip.IsLinkLocalAddress());
        }

        [Theory]
        [InlineData("::1")]
        public void IsLocalHostv6_Valid(string ip)
        {
            Assert.True(ip.IsLocalHostv6());
        }

        [Theory]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsLocalHostv6_InValid(string ip)
        {
            Assert.False(ip.IsLocalHostv6());
        }

        [Theory]
        [InlineData("127.0.0.1")]
        [InlineData("::1")]
        public void IsLocalHost_Valid(string ip)
        {
            Assert.True(ip.IsLocalHost());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsLocalHost_InValid(string ip)
        {
            Assert.False(ip.IsLocalHost());
        }

        [Theory]
        [InlineData("0.0.0.0")]
        [InlineData("::")]
        [InlineData("0000:0000:0000:0000:0000:0000:0000:0000")]
        public void IsIPisZero_Valid(string ip)
        {
            Assert.True(ip.IsIPisZero());
        }

        [Theory]
        [InlineData("200.254.1.99")]
        [InlineData("10.10.0.88")]
        [InlineData("fe79:ffff:ffff:ffff:ffff:ffff:1111:ffff")]
        [InlineData("fe55:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
        public void IsIPisZero_InValid(string ip)
        {
            Assert.False(ip.IsIPisZero());
        }

        [Theory]
        [InlineData("2001:db8:abcd:0012::0/10")]
        [InlineData("2001:db8:abcd:0012::0/24")]
        [InlineData("2001:db8:abcd:0012::0/30")]
        [InlineData("2001:db8:abcd:0012::0/64")]
        [InlineData("2001:db8:abcd:0012::0/120")]
        public void IsValidSubnetIPv6Mask_Valid(string ip)
        {
            Assert.True(ip.IsValidSubnetIPv6Mask());
        }

        [Theory]
        [InlineData("z001:db8:abcd:0012::0/10")]
        [InlineData("2001:db8:abcd:0012::0/2400")]
        [InlineData("mmmm:db8:abcd:0012::0/30")]
        [InlineData("tttt:db8:abcd:0012::0/64")]
        [InlineData("2001:db8:abcd:0012::0/600")]
        public void IsValidSubnetIPv6Mask_InValid(string ip)
        {
            Assert.False(ip.IsValidSubnetIPv6Mask());
        }

        [Theory]
        [InlineData("192.168.5.85/10")]
        [InlineData("10.200.240.50/20")]
        [InlineData("10.200.240.50/24")]
        [InlineData("2001:db8:abcd:0012::0/10")]
        [InlineData("2001:db8:abcd:0012::0/24")]
        [InlineData("2001:db8:abcd:0012::0/30")]
        [InlineData("2001:db8:abcd:0012::0/64")]
        [InlineData("2001:db8:abcd:0012::0/120")]
        public void IsValidSubnetMask_Valid(string ip)
        {
            Assert.True(ip.IsValidSubnetMask());
        }

        [Theory]
        [InlineData("192.168.5.85/400")]
        [InlineData("10.200.240.50/300")]
        [InlineData("10.200.240.500/24")]
        [InlineData("z001:db8:abcd:0012::0/10")]
        [InlineData("2001:db8:abcd:0012::0/2400")]
        [InlineData("mmmm:db8:abcd:0012::0/30")]
        [InlineData("tttt:db8:abcd:0012::0/64")]
        [InlineData("2001:db8:abcd:0012::0/600")]
        public void IsValidSubnetMask_InValid(string ip)
        {
            Assert.False(ip.IsValidSubnetMask());
        }

        [Theory]
        [InlineData("192.168.5.1", "192.168.5.85/10")]
        [InlineData("192.168.5.11", "192.168.5.85/10")]
        [InlineData("10.200.240.5", "10.200.240.50/20")]
        [InlineData("10.200.240.32", "10.200.240.50/24")]
        [InlineData("10.200.240.22", "10.200.240.50/24")]
        [InlineData("10.200.240.1", "10.200.240.50/24")]
        [InlineData("2001:0DB8:DDDD:0012:0000:1111:0000:0000", "2001:db8:abcd:0012::0/10")]
        [InlineData("2001:0DB8:ABCD:0012:1111:FFFF:FFFF:FFFF", "2001:db8:abcd:0012::0/24")]
        [InlineData("2001:0DB8:ABCD:1111:1111:0000:0000:0001", "2001:db8:abcd:0012::0/30")]
        [InlineData("2001:0DB8:ABCD:0012:FFFF:FFFF:FFFF:FFF1", "2001:db8:abcd:0012::0/64")]
        [InlineData("2001:0DB8:ABCD:0012:0000:0000:0000:0001", "2001:db8:abcd:0012::0/120")]
        public void IsBelongsToSubnet_Valid(string ip, string mask)
        {
            Assert.True(IPAddress.Parse(ip).IsBelongsToSubnet(mask));
        }

        [Theory]
        [InlineData("192.168.3.200", "192.168.5.85/24")]
        [InlineData("192.168.6.0", "192.168.5.85/24")]
        [InlineData("10.0.0.1", "10.128.240.50/30")]
        [InlineData("10.4.4.42", "10.128.240.50/30")]
        [InlineData("10.128.239.20", "10.128.240.50/30")]
        [InlineData("10.127.245.53", "10.128.240.50/30")]
        [InlineData("2001:0DB8:ABCD:0000:0000:FFFF:0011:FFFF", "2001:db8:abcd:0011::0/64")]
        [InlineData("2001:0DB8:ABCD:0013:0000:0000:0000:BBBB", "2001:db8:abcd:0011::0/80")]
        [InlineData("2001:0DB8:ABCD:0013:0001:1111:0000:0000", "2001:db8:abcd:0011::0/80")]
        [InlineData("2001:0DB8:ABCD:0000:0011:FFFF:1111:FFF0", "2001:db8:abcd:0011::0/64")]
        [InlineData("2001:0DB8:ABCD:0012:0000:0000:1111:0001", "2001:db8:abcd:0011::0/128")]
        public void IsBelongsToSubnet_InValid(string ip, string mask)
        {
            Assert.False(IPAddress.Parse(ip).IsBelongsToSubnet(mask));
        }

    }
}
