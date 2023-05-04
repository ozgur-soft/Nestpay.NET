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
            var request = new Nestpay.CC5Request();
            request.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            request.SetClientId("100100000"); // Müşteri no
            request.SetUsername("AKTESTAPI"); // Kullanıcı adı
            request.SetPassword("AKBANK01"); // Kullanıcı şifresi
            request.SetCardNumber("4355084355084358"); // Kart numarası
            request.SetCardExpiry("12", "30"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            request.SetCardCode("000"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            request.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            request.SetInstallment(""); // Taksit sayısı (varsa)
            request.SetIPv4("1.2.3.4"); // Müşteri IP adresi
            var response = nestpay.Auth(request);
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
            var request = new Nestpay.CC5Request();
            request.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            request.SetClientId("100100000"); // Müşteri no
            request.SetUsername("AKTESTAPI"); // Kullanıcı adı
            request.SetPassword("AKBANK01"); // Kullanıcı şifresi
            request.SetAmount("1.00", "TRY"); // İade tutarı ve para birimi
            request.SetOrderId("ORDER-"); // Sipariş numarası
            var response = nestpay.Refund(request);
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
            var request = new Nestpay.CC5Request();
            request.SetMode("TEST"); // Çalışma ortamı ("PROD" - "TEST")
            request.SetClientId("100100000"); // Müşteri no
            request.SetUsername("AKTESTAPI"); // Kullanıcı adı
            request.SetPassword("AKBANK01"); // Kullanıcı şifresi
            request.SetOrderId("ORDER-"); // Sipariş numarası
            var response = nestpay.Cancel(request);
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```