using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nestpay {
    public interface INestpay {
        void SetClientId(string clientid);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetMode(string mode);
        void SetType(string type);
        void SetIPv4(string ipv4);
        Nestpay.CC5Response Pay(string cardnumber, string cardmonth, string cardyear, string cardcode, string firstname, string lastname, string phone, string price, string currency);
    }
    public class Nestpay : INestpay {
        private string Endpoint { get; set; }
        private string ClientId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Mode { get; set; }
        private string Type { get; set; }
        private string IPv4 { get; set; }
        public Nestpay(string bank) {
            Endpoint = bank switch {
                "Akbank" => "https://www.sanalakpos.com/fim/api",
                "Isbank" => "https://spos.isbank.com.tr/fim/api",
                "Ziraatbank" => "https://sanalpos2.ziraatbank.com.tr/fim/api",
                "Halkbank" => "https://sanalpos.halkbank.com.tr/fim/api",
                "Finansbank" => "https://www.fbwebpos.com/fim/api",
                "Teb" => "https://sanalpos.teb.com.tr/fim/api",
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
            public string CardExpires { init; get; }
            [XmlElement("Cvv2Val", IsNullable = false)]
            public string CardCvc { init; get; }
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
        public void SetClientId(string clientid) {
            ClientId = clientid;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void SetMode(string mode) {
            Mode = mode;
        }
        public void SetType(string type) {
            Type = type;
        }
        public void SetIPv4(string ipv4) {
            IPv4 = ipv4;
        }
        public CC5Response Pay(string cardnumber, string cardmonth, string cardyear, string cardcode, string firstname, string lastname, string phone, string price, string currency) {
            var data = new CC5Request {
                Mode = Mode ?? "P",
                Type = Type ?? "Auth",
                ClientID = ClientId,
                Username = Username,
                Password = Password,
                IPAddress = IPv4,
                BillTo = new To { Name = firstname + " " + lastname, TelVoice = phone ?? "" },
                CardNumber = cardnumber,
                CardExpires = cardmonth + "/" + cardyear,
                CardCvc = cardcode,
                Amount = price,
                Currency = currency,
            };
            var cc5request = new XmlSerializer(typeof(CC5Request));
            var cc5response = new XmlSerializer(typeof(CC5Response));
            var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            cc5request.Serialize(writer, data, ns);
            try {
                var http = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) {
                    Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml")
                };
                var response = http.Send(request);
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
    }
}