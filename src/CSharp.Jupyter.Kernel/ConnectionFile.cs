using Newtonsoft.Json;

namespace CSharp.Jupyter.Kernel
{
    [JsonDictionary]
    public class ConnectionFile
    {
        [JsonProperty("control_port")]
        public int ControlPort { get; set;}

        [JsonProperty("shell_port")]
        public int ShellPort { get; set;}

        [JsonProperty("transport")]
        public string Transport { get; set;}

        [JsonProperty("signature_scheme")]
        public string SignatureScheme { get; set;}

        [JsonProperty("stdin_port")]
        public int StdinPort { get; set;}

        [JsonProperty("hb_port")]
        public int HBPort { get; set;}

        [JsonProperty("ip")]
        public string IP { get; set;}

        [JsonProperty("iopub_port")]
        public int IOPubPort { get; set;}

        [JsonProperty("key")]
        public string Key { get; set;}
    }
}