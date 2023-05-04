# Nestpay.NET
NestPay (EST) (Asseco, Akbank, İş Bankası, Ziraat Bankası, Halkbank, Finansbank, TEB) Virtual POS API with .NET

# Installation
```bash
dotnet add package Nestpay --version 1.2.0
```

# Satış
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(Bank.Asseco); // Banka adı
            nestpay.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            nestpay.SetClientID("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            nestpay.SetCardNumber("4355084355084358"); // Kart numarası
            nestpay.SetCardExpiry("12", "30"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            nestpay.SetCardCode("000"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            nestpay.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            nestpay.SetInstallment(""); // Taksit sayısı (varsa)
            nestpay.SetCardHolder(""); // Kart sahibi
            nestpay.SetIPv4("1.2.3.4"); // Müşteri IP adresi (zorunlu)
            var response = nestpay.Pay();
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```

# İade
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(Bank.Asseco); // Banka adı
            nestpay.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            nestpay.SetClientID("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            nestpay.SetAmount("1.00", "TRY"); // İade tutarı ve para birimi
            nestpay.SetOrderID("ORDER-"); // Sipariş numarası
            var response = nestpay.Refund();
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```

# İptal
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(Bank.Asseco); // Banka adı
            nestpay.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            nestpay.SetClientID("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            nestpay.SetAmount("1.00", "TRY"); // İptal tutarı ve para birimi
            nestpay.SetOrderID("ORDER-"); // Sipariş numarası
            var response = nestpay.Cancel();
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```