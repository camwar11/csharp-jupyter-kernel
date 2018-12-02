using CSharp.Jupyter.Messages.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharp.Jupyter.Messages.Execute
{
    public class ExecuteReply : GeneralMessage<ExecuteReply.ExecuteReplyContent>
    {
        public class ExecuteReplyContent
        {
            /// <summary>
            /// One of: 'ok' OR 'error' OR 'abort'
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set;}

            /// <summary>
            /// The global kernel counter that increases by one with each request that
            /// stores history.  This will typically be used by clients to display
            /// prompt numbers to the user.  If the request did not store history, this will
            /// be the current value of the counter in the kernel.
            /// </summary>
            [JsonProperty("execution_count")]
            public int ExecutionCount { get; set;}

            /// <summary>
            /// Results for the user_expressions.
            /// </summary>
            [JsonProperty("user_expressions")]
            public JObject UserExpressions { get; set; }
        }
    }
}