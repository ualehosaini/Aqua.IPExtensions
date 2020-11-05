# About Aqua IPExtensions:

Aqua IP Extensions is an Open Source and Free Software package consists of a set of utilities that facilitate the job of the developer and save his time while dealing with a both IP v4 and IP v6 addresses. Every developer could be a beneficiary of this library; however, those who deal with network and integration applications are likely the most potential beneficiaries.


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# List of Features and Methods
1. [IsValidIPv4](#IsValidIPv4)
2. [IsValidIPv6](#IsValidIPv6)
3. [IsValidIPv4Orv6](#IsValidIPv4Orv6)
4. [IsIPv4LinkLocalAddress](#IsIPv4LinkLocalAddress)
5. [IsIPv6LinkLocalAddress](#IsIPv6LinkLocalAddress)
6. [IsLinkLocalAddress](#IsLinkLocalAddress)
7. [IsIPv4LoopBack](#IsIPv4LoopBack)
8. [IsIPv6LoopBack](#IsIPv6LoopBack)
9. [IsLoopBack](#IsLoopBack)
10. [IsLocalHostv4](#IsLocalHostv4)
11. [IsLocalHostv6](#IsLocalHostv6)
12. [IsLocalHost](#IsLocalHost)
13. [IsIPv4IsZero](#IsIPv4IsZero)
14. [IsIPv6IsZero](#IsIPv6IsZero)
15. [IsIPisZero](#IsIPisZero)
16. [IsValidSubnetIPv4Mask](#IsValidSubnetIPv4Mask)
17. [IsValidSubnetIPv6Mask](#IsValidSubnetIPv6Mask)
18. [IsValidSubnetMask](#IsValidSubnetMask)
19. [IsBelongsToSubnet](#IsBelongsToSubnet)


# Features and Methods
### IsNullOrEmpty
IsNullOrEmpty is an extension method, equivalent for the traditional ``` string.IsNullOrEmpty() ``` static method. Returns true if the string examined is null or empty, otherwise returns false.

```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidIPv4();  // output = false

input = "192.168.1.5";
output = input.IsValidIPv4();  // output = true

input = "10.0.0.55";
output = input.IsValidIPv4();  // output = true

input = "231.111.12.10";
output = input.IsValidIPv4();  // output = true

input = "0.0.0.0";
output = input.IsValidIPv4();  // output = true

input = "127.0.0.1";
output = input.IsValidIPv4();  // output = true

input = "342";
output = input.IsValidIPv4();  // output = false

input = "300.1.1200";
output = input.IsValidIPv4();  // output = false

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidIPv6
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidIPv6();           // output = false

input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsValidIPv6();           // output = true

input = "2001:0db8:85a3:0000:0000::2:7335";
output = input.IsValidIPv6();           // output = true

input = "::1234:5678";
output = input.IsValidIPv6();           // output = true

input = "::";
output = input.IsValidIPv6();           // output = true

input = "::1";
output = input.IsValidIPv6();           // output = true

input = "::1ZXE";
output = input.IsValidIPv6();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsValidIPv6();           // output = false

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidIPv4Orv6
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidIPv4Orv6();           // output = false

input = "192.168.1.5";
output = input.IsValidIPv4Orv6();           // output = true

input = "2001:0db8:85a3:0000:0000::2:7335";
output = input.IsValidIPv4Orv6();           // output = true

input = "127.0.0.1";
output = input.IsValidIPv4Orv6();           // output = true

input = "::";
output = input.IsValidIPv4Orv6();           // output = true

input = "::1";
output = input.IsValidIPv4Orv6();           // output = true

input = "::1ZXE";
output = input.IsValidIPv4Orv6();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsValidIPv4Orv6();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv4LinkLocalAddress
```C#
 //using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv4LinkLocalAddress();           // output = false

input = "169.254.1.99";
output = input.IsIPv4LinkLocalAddress();           // output = true

input = "192.254.1.99";
output = input.IsIPv4LinkLocalAddress();           // output = false

input = "127.0.0.1";
output = input.IsIPv4LinkLocalAddress();           // output = false

input = "::";
output = input.IsIPv4LinkLocalAddress();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsIPv4LinkLocalAddress();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv6LinkLocalAddress
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv6LinkLocalAddress();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPv6LinkLocalAddress();           // output = true

input = "febf:ffff:ffff:1111:ffff:ffff:1111:1111";
output = input.IsIPv6LinkLocalAddress();           // output = true

input = "127.0.0.1";
output = input.IsIPv6LinkLocalAddress();           // output = false

input = "::";
output = input.IsIPv6LinkLocalAddress();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsIPv6LinkLocalAddress();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsLinkLocalAddress
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsLinkLocalAddress();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsLinkLocalAddress();           // output = true

input = "169.254.1.99";
output = input.IsLinkLocalAddress();           // output = true

input = "127.0.0.1";
output = input.IsLinkLocalAddress();           // output = false

input = "::";
output = input.IsLinkLocalAddress();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsLinkLocalAddress();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv4LoopBack
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv4LoopBack();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPv4LoopBack();           // output = false

input = "169.254.1.99";
output = input.IsIPv4LoopBack();           // output = false

input = "127.0.0.1";
output = input.IsIPv4LoopBack();           // output = true

input = "::";
output = input.IsIPv4LoopBack();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsIPv4LoopBack();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv6LoopBack
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv6LoopBack();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPv6LoopBack();           // output = false

input = "169.254.1.99";
output = input.IsIPv6LoopBack();           // output = false

input = "127.0.0.1";
output = input.IsIPv6LoopBack();           // output = false

input = "::1";
output = input.IsIPv6LoopBack();           // output = true

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsIPv6LoopBack();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsLoopBack
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsLoopBack();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsLoopBack();           // output = false

input = "169.254.1.99";
output = input.IsLoopBack();           // output = false

input = "127.0.0.1";
output = input.IsLoopBack();           // output = true

input = "::1";
output = input.IsLoopBack();           // output = true

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsLoopBack();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)
### IsLocalHostv4
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsLocalHostv4();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsLocalHostv4();           // output = false

input = "169.254.1.99";
output = input.IsLocalHostv4();           // output = false

input = "127.0.0.1";
output = input.IsLocalHostv4();           // output = true

input = "::";
output = input.IsLocalHostv4();           // output = false

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsLocalHostv4();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsLocalHostv6
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsLocalHostv6();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsLocalHostv6();           // output = false

input = "169.254.1.99";
output = input.IsLocalHostv6();           // output = false

input = "127.0.0.1";
output = input.IsLocalHostv6();           // output = false

input = "::1";
output = input.IsLocalHostv6();           // output = true

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsLocalHostv6();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsLocalHost
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsLocalHost();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsLocalHost();           // output = false

input = "169.254.1.99";
output = input.IsLocalHost();           // output = false

input = "127.0.0.1";
output = input.IsLocalHost();           // output = true

input = "::1";
output = input.IsLocalHost();           // output = true

input = "M11C:0db8:85a3:0000:0000:8a2e:0370:7334";
output = input.IsLocalHost();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv4IsZero
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv4IsZero();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPv4IsZero();           // output = false

input = "169.254.1.99";
output = input.IsIPv4IsZero();           // output = false

input = "0.0.0.0";
output = input.IsIPv4IsZero();           // output = true

input = "::";
output = input.IsIPv4IsZero();           // output = false

input = "0000:0000:0000:0000:0000:0000:0000:0000";
output = input.IsIPv4IsZero();           // output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPv6IsZero
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPv6IsZero();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPv6IsZero();           // output = false

input = "169.254.1.99";
output = input.IsIPv6IsZero();           // output = false

input = "0.0.0.0";
output = input.IsIPv6IsZero();           // output = false

input = "::";
output = input.IsIPv6IsZero();           // output = true

input = "0000:0000:0000:0000:0000:0000:0000:0000";
output = input.IsIPv6IsZero();           // output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsIPisZero
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsIPisZero();           // output = false

input = "fe81:ffff:ffff:ffff:ffff:ffff:1111:ffff";
output = input.IsIPisZero();           // output = false

input = "169.254.1.99";
output = input.IsIPisZero();           // output = false

input = "0.0.0.0";
output = input.IsIPisZero();           // output = true

input = "::";
output = input.IsIPisZero();           // output = true

input = "0000:0000:0000:0000:0000:0000:0000:0000";
output = input.IsIPisZero();           // output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidSubnetIPv4Mask
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidSubnetIPv4Mask();// output = false

input = "192.168.5.85/10";
output = input.IsValidSubnetIPv4Mask();// output = true

input = "192.168.5.85/40";
output = input.IsValidSubnetIPv4Mask();// output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidSubnetIPv6Mask
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidSubnetIPv6Mask();// output = false

input = "2001:db8:abcd:0012::0/64";
output = input.IsValidSubnetIPv6Mask();// output = true

input = "2001:db8:abcd:0012::0/640";
output = input.IsValidSubnetIPv6Mask();// output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidSubnetMask
```C#
//using Aqua.IPExtensions;

string input;
bool output;

input = null;
output = input.IsValidSubnetMask();// output = false

input = "2001:db8:abcd:0012::0/64";
output = input.IsValidSubnetMask();// output = true

input = "192.168.5.85/10";
output = input.IsValidSubnetMask();// output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsBelongsToSubnet

```C#
//using Aqua.IPExtensions;

IPAddress input;
bool output;

input = IPAddress.Parse("192.168.5.1");
output = input.IsBelongsToSubnet("192.168.5.85/10");    // output = true

input = IPAddress.Parse("192.168.5.1");
output = input.IsBelongsToSubnet("200.168.5.85/10");    // output = false

input = IPAddress.Parse("2001:0DB8:DDDD:0012:0000:1111:0000:0000"); 
output = input.IsBelongsToSubnet("2001:db8:abcd:0012::0/10");       // output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

# Build and Test
TODO: Describe and show how to build your code and run the tests. 



# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
