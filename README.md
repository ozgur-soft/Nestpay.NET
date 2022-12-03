# Nestpay.NET
NestPay (EST) (Asseco, Akbank, İş Bankası, Ziraat Bankası, Halkbank, Finansbank, TEB) Virtual POS API with .NET

# Installation
```bash
dotnet add package Nestpay --version 1.2.0
```

# Sanalpos satış işlemi
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(""); // Banka adı : "Akbank","Isbank","Ziraatbank","Halkbank","Finansbank","Teb"
            nestpay.SetClientID(""); // Müşteri no
            nestpay.SetUsername(""); // Kullanıcı adı
            nestpay.SetPassword(""); // Kullanıcı şifresi
            nestpay.SetCardNumber("4242424242424242"); // Kart numarası
            nestpay.SetCardExpiry("02", "20"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            nestpay.SetCardCode("123"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            nestpay.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            nestpay.SetInstallment(""); // Taksit sayısı (varsa)
            nestpay.SetCardHolder(""); // Kart sahibi
            nestpay.SetPhoneNumber(""); // Müşteri telefon numarası
            nestpay.SetIPv4("1.2.3.4"); // Müşteri IP adresi (zorunlu)
            var response = nestpay.Pay();
            if (response != null) {
                Console.WriteLine(Nestpay.JsonString<Nestpay.CC5Response>(response));
            }
        }
    }
}
```

# Sanalpos iade işlemi
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(""); // Banka adı : "Akbank","Isbank","Ziraatbank","Halkbank","Finansbank","Teb"
            nestpay.SetClientID(""); // Müşteri no
            nestpay.SetUsername(""); // Kullanıcı adı
            nestpay.SetPassword(""); // Kullanıcı şifresi
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

# Sanalpos iptal işlemi
```c#
namespace Nestpay {
    internal class Program {
        static void Main(string[] args) {
            var nestpay = new Nestpay(""); // Banka adı : "Akbank","Isbank","Ziraatbank","Halkbank","Finansbank","Teb"
            nestpay.SetClientID(""); // Müşteri no
            nestpay.SetUsername(""); // Kullanıcı adı
            nestpay.SetPassword(""); // Kullanıcı şifresi
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