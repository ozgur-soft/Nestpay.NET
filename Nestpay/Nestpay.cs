﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Nestpay {
    public enum Bank {
        Asseco,
        Anadolu,
        Akbank,
        Isbank,
        Ziraat,
        Halkbank,
        Finansbank,
        Teb
    }
    public interface INestpay {
        void SetMode(string mode);
        void SetClientID(string clientid);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetIPv4(string ipv4);
        void SetOrderID(string orderid);
        void SetAmount(string amount, string currency);
        void SetInstallment(string installment);
        void SetCardHolder(string cardholder);
        void SetPhoneNumber(string phonenumber);
        void SetCardNumber(string cardnumber);
        void SetCardExpiry(string cardmonth, string cardyear);
        void SetCardCode(string cardcode);
        Nestpay.CC5Response Pay();
        Nestpay.CC5Response Refund();
        Nestpay.CC5Response Cancel();
    }
    public class Nestpay : INestpay {
        private string Endpoint { get; set; }
        private string Mode { get; set; }
        private string ClientID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string IPv4 { get; set; }
        private string OrderID { get; set; }
        private string Amount { get; set; }
        private string Currency { get; set; }
        private string Installment { get; set; }
        private string CardHolder { get; set; }
        private string PhoneNumber { get; set; }
        private string CardNumber { get; set; }
        private string CardMonth { get; set; }
        private string CardYear { get; set; }
        private string CardCode { get; set; }
        public Nestpay(Bank bank) {
            Endpoint = bank switch {
                Bank.Asseco => "https://entegrasyon.asseco-see.com.tr",
                Bank.Akbank => "https://www.sanalakpos.com",
                Bank.Anadolu => "https://anadolusanalpos.est.com.tr",
                Bank.Isbank => "https://spos.isbank.com.tr",
                Bank.Ziraat => "https://sanalpos2.ziraatbank.com.tr",
                Bank.Halkbank => "https://sanalpos.halkbank.com.tr",
                Bank.Finansbank => "https://www.fbwebpos.com",
                Bank.Teb => "https://sanalpos.teb.com.tr",
                _ => null
            };
        }
        [Serializable, XmlRoot("CC5Request")]
        public class CC5Request {
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { init; get; }
            [XmlElement("Type", IsNullable = false)]
            public string Type { init; get; }
            [XmlElement("Name", IsNullable = false)]
            public string Username { init; get; }
            [XmlElement("Password", IsNullable = false)]
            public string Password { init; get; }
            [XmlElement("ClientId", IsNullable = false)]
            public string ClientID { init; get; }
            [XmlElement("OrderId", IsNullable = false)]
            public string OrderID { init; get; }
            [XmlElement("GroupId", IsNullable = false)]
            public string GroupID { init; get; }
            [XmlElement("TransId", IsNullable = false)]
            public string TransID { init; get; }
            [XmlElement("UserId", IsNullable = false)]
            public string UserID { init; get; }
            [XmlElement("IPAddress", IsNullable = false)]
            public string IPAddress { init; get; }
            [XmlElement("Email", IsNullable = false)]
            public string Email { init; get; }
            [XmlElement("Number", IsNullable = false)]
            public string CardNumber { init; get; }
            [XmlElement("Expires", IsNullable = false)]
            public string CardExpiry { init; get; }
            [XmlElement("Cvv2Val", IsNullable = false)]
            public string CardCode { init; get; }
            [XmlElement("Total", IsNullable = false)]
            public string Amount { init; get; }
            [XmlElement("Currency", IsNullable = false)]
            public string Currency { init; get; }
            [XmlElement("Instalment", IsNullable = false)]
            public string Installment { init; get; }
            [XmlElement("PayerTxnId", IsNullable = false)]
            public string PayerTxnId { init; get; }
            [XmlElement("PayerSecurityLevel", IsNullable = false)]
            public string PayerSecurityLevel { init; get; }
            [XmlElement("PayerAuthenticationCode", IsNullable = false)]
            public string PayerAuthenticationCode { init; get; }
            [XmlElement("CardholderPresentCode", IsNullable = false)]
            public string CardholderPresentCode { init; get; }
            [XmlElement("BillTo", IsNullable = false)]
            public To BillTo { init; get; }
            [XmlElement("ShipTo", IsNullable = false)]
            public To ShipTo { init; get; }
        }
        public class To {
            [XmlElement("Name", IsNullable = false)]
            public string Name { init; get; }
            [XmlElement("Company", IsNullable = false)]
            public string Company { init; get; }
            [XmlElement("Street1", IsNullable = false)]
            public string Street1 { init; get; }
            [XmlElement("Street2", IsNullable = false)]
            public string Street2 { init; get; }
            [XmlElement("Street3", IsNullable = false)]
            public string Street3 { init; get; }
            [XmlElement("City", IsNullable = false)]
            public string City { init; get; }
            [XmlElement("StateProv", IsNullable = false)]
            public string StateProv { init; get; }
            [XmlElement("PostalCode", IsNullable = false)]
            public string PostalCode { init; get; }
            [XmlElement("Country", IsNullable = false)]
            public string Country { init; get; }
            [XmlElement("TelVoice", IsNullable = false)]
            public string TelVoice { init; get; }
        }
        [Serializable, XmlRoot("CC5Response")]
        public class CC5Response {
            [XmlElement("OrderId")]
            public string OrderId { init; get; }
            [XmlElement("GroupId")]
            public string GroupId { init; get; }
            [XmlElement("TransId")]
            public string TransId { init; get; }
            [XmlElement("Response")]
            public string Response { init; get; }
            [XmlElement("AuthCode")]
            public string AuthCode { init; get; }
            [XmlElement("HostRefNum")]
            public string HostRefNum { init; get; }
            [XmlElement("ProcReturnCode")]
            public string ProcReturnCode { init; get; }
            [XmlElement("ErrMsg")]
            public string ErrMsg { init; get; }
        }
        public class Writer : StringWriter {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public void SetMode(string mode) {
            Mode = mode switch {
                "TEST" => "T",
                "PROD" => "P",
                _ => mode
            };
        }
        public void SetClientID(string clientid) {
            ClientID = clientid;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void SetIPv4(string ipv4) {
            IPv4 = ipv4;
        }
        public void SetOrderID(string orderid) {
            OrderID = orderid;
        }
        public void SetAmount(string amount, string currency) {
            Amount = amount;
            Currency = currency switch {
                "TRY" => "949",
                "YTL" => "949",
                "TRL" => "949",
                "TL" => "949",
                "USD" => "840",
                "EUR" => "978",
                "GBP" => "826",
                "JPY" => "392",
                _ => currency
            };
        }
        public void SetInstallment(string installment) {
            Installment = installment;
        }
        public void SetCardHolder(string cardholder) {
            CardHolder = cardholder;
        }
        public void SetPhoneNumber(string phonenumber) {
            PhoneNumber = phonenumber;
        }
        public void SetCardNumber(string cardnumber) {
            CardNumber = cardnumber;
        }
        public void SetCardExpiry(string cardmonth, string cardyear) {
            CardMonth = cardmonth;
            CardYear = cardyear;
        }
        public void SetCardCode(string cardcode) {
            CardCode = cardcode;
        }
        public CC5Response Pay() {
            var data = new CC5Request {
                Mode = Mode ?? "P",
                Type = "Auth",
                ClientID = ClientID,
                Username = Username,
                Password = Password,
                IPAddress = IPv4,
                BillTo = new To { Name = CardHolder, TelVoice = PhoneNumber ?? "" },
                CardNumber = CardNumber,
                CardExpiry = CardMonth + "/" + CardYear,
                CardCode = CardCode,
                Amount = Amount,
                Currency = Currency,
                Installment = Installment,
            };
            var cc5request = new XmlSerializer(typeof(CC5Request));
            var cc5response = new XmlSerializer(typeof(CC5Response));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            cc5request.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + "/fim/api") { Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml") };
                using var response = http.Send(request);
                var result = (CC5Response)cc5response.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public CC5Response Refund() {
            var data = new CC5Request {
                Mode = Mode ?? "P",
                Type = "Credit",
                ClientID = ClientID,
                Username = Username,
                Password = Password,
                OrderID = OrderID,
                Amount = Amount,
                Currency = Currency,
            };
            var cc5request = new XmlSerializer(typeof(CC5Request));
            var cc5response = new XmlSerializer(typeof(CC5Response));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            cc5request.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + "/fim/api") { Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml") };
                using var response = http.Send(request);
                var result = (CC5Response)cc5response.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public CC5Response Cancel() {
            var data = new CC5Request {
                Mode = Mode ?? "P",
                Type = "Void",
                ClientID = ClientID,
                Username = Username,
                Password = Password,
                OrderID = OrderID,
                Amount = Amount,
                Currency = Currency,
            };
            var cc5request = new XmlSerializer(typeof(CC5Request));
            var cc5response = new XmlSerializer(typeof(CC5Response));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            cc5request.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + "/fim/api") { Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml") };
                using var response = http.Send(request);
                var result = (CC5Response)cc5response.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}