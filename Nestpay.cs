﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Nestpay {
    public enum MODE {
        PROD,
        TEST
    }
    public enum BANK {
        Asseco,
        Anadolu,
        Akbank,
        Isbank,
        Ziraat,
        Halkbank,
        Finansbank,
        Teb
    }
    public class Nestpay {
        public string Mode { set; get; }
        public string Endpoint { get; set; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string ClientId { set; get; }
        internal void SetClientId(string clientid) {
            ClientId = clientid;
        }
        internal void SetUsername(string username) {
            Username = username;
        }
        internal void SetPassword(string password) {
            Password = password;
        }
        public Nestpay(MODE mode, BANK bank) {
            Mode = mode switch {
                MODE.PROD => "P",
                MODE.TEST => "T",
                _ => null
            };
            Endpoint = bank switch {
                BANK.Asseco => "https://entegrasyon.asseco-see.com.tr",
                BANK.Akbank => "https://www.sanalakpos.com",
                BANK.Anadolu => "https://anadolusanalpos.est.com.tr",
                BANK.Isbank => "https://spos.isbank.com.tr",
                BANK.Ziraat => "https://sanalpos2.ziraatbank.com.tr",
                BANK.Halkbank => "https://sanalpos.halkbank.com.tr",
                BANK.Finansbank => "https://www.fbwebpos.com",
                BANK.Teb => "https://sanalpos.teb.com.tr",
                _ => null
            };
        }
        [Serializable, XmlRoot("CC5Request")]
        public class CC5Request {
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { set; get; }
            [XmlElement("Type", IsNullable = false)]
            public string Type { set; get; }
            [XmlElement("Name", IsNullable = false)]
            public string Username { set; get; }
            [XmlElement("Password", IsNullable = false)]
            public string Password { set; get; }
            [XmlElement("ClientId", IsNullable = false)]
            public string ClientId { set; get; }
            [XmlElement("OrderId", IsNullable = false)]
            public string OrderId { set; get; }
            [XmlElement("GroupId", IsNullable = false)]
            public string GroupId { set; get; }
            [XmlElement("TransId", IsNullable = false)]
            public string TransId { set; get; }
            [XmlElement("UserId", IsNullable = false)]
            public string UserId { set; get; }
            [XmlElement("IPAddress", IsNullable = false)]
            public string IPAddress { set; get; }
            [XmlElement("Email", IsNullable = false)]
            public string Email { set; get; }
            [XmlElement("Number", IsNullable = false)]
            public string CardNumber { set; get; }
            [XmlElement("Expires", IsNullable = false)]
            public string CardExpiry { set; get; }
            [XmlElement("Cvv2Val", IsNullable = false)]
            public string CardCode { set; get; }
            [XmlElement("Total", IsNullable = false)]
            public string Amount { set; get; }
            [XmlElement("Currency", IsNullable = false)]
            public string Currency { set; get; }
            [XmlElement("Instalment", IsNullable = false)]
            public string Installment { set; get; }
            [XmlElement("PayerTxnId", IsNullable = false)]
            public string PayerTxnId { set; get; }
            [XmlElement("PayerSecurityLevel", IsNullable = false)]
            public string PayerSecurityLevel { set; get; }
            [XmlElement("PayerAuthenticationCode", IsNullable = false)]
            public string PayerAuthenticationCode { set; get; }
            [XmlElement("CardholderPresentCode", IsNullable = false)]
            public string CardholderPresentCode { set; get; }
            [XmlElement("BillTo", IsNullable = false)]
            public To BillTo { set; get; }
            [XmlElement("ShipTo", IsNullable = false)]
            public To ShipTo { set; get; }
            internal void SetIPv4(string ipv4) {
                IPAddress = ipv4;
            }
            internal void SetOrderId(string orderid) {
                OrderId = orderid;
            }
            internal void SetAmount(string amount, string currency) {
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
            internal void SetInstallment(string installment) {
                Installment = installment;
            }
            internal void SetCardNumber(string cardnumber) {
                CardNumber = cardnumber;
            }
            internal void SetCardExpiry(string cardmonth, string cardyear) {
                CardExpiry = cardmonth + "/" + cardyear;
            }
            internal void SetCardCode(string cardcode) {
                CardCode = cardcode;
            }
        }
        public class To {
            [XmlElement("Name", IsNullable = false)]
            public string Name { set; get; }
            [XmlElement("Company", IsNullable = false)]
            public string Company { set; get; }
            [XmlElement("Street1", IsNullable = false)]
            public string Street1 { set; get; }
            [XmlElement("Street2", IsNullable = false)]
            public string Street2 { set; get; }
            [XmlElement("Street3", IsNullable = false)]
            public string Street3 { set; get; }
            [XmlElement("City", IsNullable = false)]
            public string City { set; get; }
            [XmlElement("StateProv", IsNullable = false)]
            public string StateProv { set; get; }
            [XmlElement("PostalCode", IsNullable = false)]
            public string PostalCode { set; get; }
            [XmlElement("Country", IsNullable = false)]
            public string Country { set; get; }
            [XmlElement("TelVoice", IsNullable = false)]
            public string TelVoice { set; get; }
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
        public CC5Response Auth(CC5Request data) {
            data.Type = "Auth";
            data.Mode = Mode;
            data.ClientId = ClientId;
            data.Username = Username;
            data.Password = Password;
            return Transaction(data);
        }
        public CC5Response Refund(CC5Request data) {
            data.Type = "Credit";
            data.Mode = Mode;
            data.ClientId = ClientId;
            data.Username = Username;
            data.Password = Password;
            return Transaction(data);
        }
        public CC5Response Cancel(CC5Request data) {
            data.Type = "Void";
            data.Mode = Mode;
            data.ClientId = ClientId;
            data.Username = Username;
            data.Password = Password;
            return Transaction(data);
        }
        public CC5Response Transaction(CC5Request data) {
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