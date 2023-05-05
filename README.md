# Nestpay.NET
Nestpay (EST) (Asseco) POS API with .NET

# Installation
```bash
dotnet add package Nestpay --version 1.2.0
```

# Satış
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(MODE.TEST, BANK.Asseco); // Çalışma ortamı ve Banka adı
            nestpay.SetClientId("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            var request = new Nestpay.CC5Request();
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
            var nestpay = new Nestpay(MODE.TEST, BANK.Asseco); // Çalışma ortamı ve Banka adı
            nestpay.SetClientId("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            var request = new Nestpay.CC5Request();
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
            var nestpay = new Nestpay(MODE.TEST, BANK.Asseco); // Çalışma ortamı ve Banka adı
            nestpay.SetClientId("100100000"); // Müşteri no
            nestpay.SetUsername("AKTESTAPI"); // Kullanıcı adı
            nestpay.SetPassword("AKBANK01"); // Kullanıcı şifresi
            var request = new Nestpay.CC5Request();
            request.SetOrderId("ORDER-"); // Sipariş numarası
            var response = nestpay.Cancel(request);
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```