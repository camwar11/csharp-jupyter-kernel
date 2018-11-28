using CSharp.Jupyter.Messages.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharp.Jupyter.Messages.Execute
{
    public class ExecuteRequest : GeneralMessage<ExecuteRequest.ExecuteRequestContent>
    {
        [JsonDictionary]
        public class ExecuteRequestContent
        {
            /// <summary>
            /// Source code to be executed by the kernel, one or more lines.
            /// </summary>
            [JsonProperty("code")]
            public string Code { get; set;}

            /// <summary>
            /// A boolean flag which, if True, signals the kernel to execute
            /// this code as quietly as possible.
            /// silent=True forces store_history to be False,
            /// and will *not*:
            ///   - broadcast output on the IOPUB channel
            ///   - have an execute_result
            /// The default is False.
            /// </summary>
            [JsonProperty("silent")]
            public bool Silent { get; set;}

            /// <summary>
            /// A boolean flag which, if True, signals the kernel to populate history
            /// The default is True if silent is False.  If silent is True, store_history
            /// is forced to be False.
            /// </summary>
            [JsonProperty("store_history")]
            public bool StoreHistory { get; set;}

            /// <summary>
            /// A dict mapping names to expressions to be evaluated in the
            /// user's dict. The rich display-data representation of each will be evaluated after execution.
            /// See the display_data content for the structure of the representation data.
            /// </summary>
            [JsonProperty("user_expressions")]
            public JObject UserExpressions { get; set; }

            /// <summary>
            /// Some frontends do not support stdin requests.
            /// If this is true, code running in the kernel can prompt the user for input
            /// with an input_request message (see below). If it is false, the kernel
            /// should not send these messages.
            /// </summary>
            [JsonProperty("allow_stdin")]
            public bool AllowStdin { get; set;}

            /// <summary>
            /// A boolean flag, which, if True, does not abort the execution queue, if an exception is encountered.
            /// This allows the queued execution of multiple execute_requests, even if they generate exceptions.
            /// </summary>
            [JsonProperty("stop_on_error")]
            public bool StopOnError { get; set;}
        }
    }
}