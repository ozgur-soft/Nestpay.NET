[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Nestpay.NET/blob/master/LICENSE.md)

# Nestpay.NET
NestPay (EST) (Asseco, Akbank, İş Bankası, Ziraat Bankası, Halkbank, Finansbank, TEB) Sanal POS API with .NET

# Installation
```bash
dotnet add package Nestpay --version 1.0.5
```

```c#
using Nestpay;

var nestpay = new Nestpay("Akbank"); // "Akbank","Isbank","Ziraatbank","Halkbank","Finansbank","Teb"
nestpay.SetClientId("API clientid");
nestpay.SetUsername("API username");
nestpay.SetPassword("API password");
nestpay.SetIPv4("Customer IPv4 address");
nestpay.Pay(
    "Credit card number (Eg: 4321432143214321)",
    "Card month (Eg: 02)",
    "Card year (Eg: 22)",
    "Card security code: (Eg: 123)",
    "Customer firstname",
    "Customer lastname",
    "Customer phone number",
    "Amount (Eg: 1.00)",
    "Currency code ( $: 840 || €: 978 || ₺: 949 )"
);
```
