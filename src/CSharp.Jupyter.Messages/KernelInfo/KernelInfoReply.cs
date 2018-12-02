using CSharp.Jupyter.Messages.General;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CSharp.Jupyter.Messages.KernelInfo
{
    public class KernelInfoReply : GeneralMessage<KernelInfoReply.KernelInfoReplyContent>
    {
        public class KernelInfoReplyContent
        {
            /// <summary>
            /// Version of messaging protocol.
            /// The first integer indicates major version.  It is incremented when
            /// there is any backward incompatible change.
            /// The second integer indicates minor version.  It is incremented when
            /// there is any backward compatible change.
            /// </summary>
            [JsonProperty("protocol_version")]
            public string ProtocolVersion { get; set;}

            /// <summary>
            /// The kernel implementation name
            /// (e.g. 'ipython' for the IPython kernel)
            /// </summary>
            [JsonProperty("implementation")]
            public string Implementation { get; set;}

            /// <summary>
            /// Implementation version number.
            /// The version number of the kernel's implementation
            /// (e.g. IPython.__version__ for the IPython kernel)
            /// </summary>
            [JsonProperty("implementation_version")]
            public string ImplementationVersion { get; set;}

            /// <summary>
            /// Information about the language of code for the kernel
            /// </summary>
            [JsonProperty("language_info")]
            public LanguageInfoContent LanguageInfo { get; set;}

            /// <summary>
            ///  A banner of information about the kernel,
            ///  which may be desplayed in console environments.
            /// </summary>
            [JsonProperty("banner")]
            public string Banner { get; set;}

            /// <summary>
            ///  Optional: A list of dictionaries, each with keys 'text' and 'url'.
            ///  These will be displayed in the help menu in the notebook UI.
            /// </summary>
            [JsonProperty("help_links")]
            public List<HelpLink> HelpLinks { get; set; }

            public class LanguageInfoContent
            {
                /// <summary>
                /// Name of the programming language that the kernel implements.
                /// Kernel included in IPython returns 'python'.
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set;}

                /// <summary>
                /// Language version number.
                /// It is Python version number (e.g., '2.7.3') for the kernel
                /// included in IPython.
                /// </summary>
                [JsonProperty("version")]
                public string Version { get; set;}

                /// <summary>
                /// mimetype for script files in this language
                /// </summary>
                [JsonProperty("mimetype")]
                public string MimeType { get; set;}

                /// <summary>
                /// Extension including the dot, e.g. '.py'
                /// </summary>
                [JsonProperty("file_extension")]
                public string FileExtension { get; set;}

                /// <summary>
                /// Pygments lexer, for highlighting
                /// Only needed if it differs from the 'name' field.
                /// </summary>
                [JsonProperty("pygments_lexer")]
                public string PygmentsLexer { get; set;}

                /// <summary>
                /// Codemirror mode, for for highlighting in the notebook.
                /// Only needed if it differs from the 'name' field.
                /// </summary>
                [JsonProperty("codemirror_mode")]
                public string CodeMirrorMode { get; set;}

                /// <summary>
                /// Nbconvert exporter, if notebooks written with this kernel should
                /// be exported with something other than the general 'script'
                /// exporter.
                /// </summary>
                [JsonProperty("nbconvert_exporter")]
                public string NbconvertExporter { get; set;}
            }

            public class HelpLink
            {
                /// <summary>
                /// Link text
                /// </summary>
                [JsonProperty("text")]
                public string Text { get; set;}

                /// <summary>
                /// Link url
                /// </summary>
                [JsonProperty("url")]
                public string URL { get; set;}
            }
        }
    }
}