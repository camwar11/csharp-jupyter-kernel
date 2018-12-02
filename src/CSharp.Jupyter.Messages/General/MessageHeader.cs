using Newtonsoft.Json;

namespace CSharp.Jupyter.Messages.General
{
    public class MessageHeader
    {
        [JsonProperty("msg_id")]
        public string MsgId { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("session")]
        public string Session { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("msg_type")]
        public string MsgType { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}