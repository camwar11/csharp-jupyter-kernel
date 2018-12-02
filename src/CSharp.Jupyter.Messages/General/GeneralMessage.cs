using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharp.Jupyter.Messages.General
{
    public abstract class GeneralMessage<T>
    {
        [JsonProperty("header")]
        public MessageHeader Header { get; set;}

        [JsonProperty("parent_header")]
        public MessageHeader ParentHeader { get; set;}

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set;}

        [JsonProperty("content")]
        public T Content {get; set;}

        [JsonProperty("buffers")]
        public List<byte[]> Buffers {get; set;}
    }
}
