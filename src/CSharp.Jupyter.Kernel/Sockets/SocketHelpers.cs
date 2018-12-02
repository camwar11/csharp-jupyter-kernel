using NetMQ;
using CSharp.Jupyter.Messages.General;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharp.Jupyter.Kernel.Sockets
{
    public static class SocketHelpers
    {
        public static string GetConnectionString(string protocol, string address, int port)
        {
            return string.Format("{0}://{1}:{2}", protocol, address, port);
        }

        private static string GetConnectionString(ConnectionFile file, int port)
        {
            return string.Format("{0}://{1}:{2}", file.Transport, file.IP, port);
        }

        public static string ControlConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.ControlPort);
        }

        public static string HeartbeatConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.HBPort);
        }

        public static string IOPubConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.IOPubPort);
        }

        public static string ShellConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.ShellPort);
        }

        public static string StdinConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.StdinPort);
        }

        public static bool TryGetMessage<T,Q>(this IReceivingSocket socket, out T message) where T : GeneralMessage<Q>, new()
        {
            List<byte[]> frames = null;
            if(!socket.TryReceiveMultipartBytes(ref frames, 6))
            {
                message = null;
                return false;
            }

            message = new T();

            bool hitDelimiter = false;
            int messageSeqIdx = 0;
            foreach (byte[] frame in frames)
            {
                string decoded = System.Text.Encoding.UTF8.GetString(frame);

                if(decoded == Constants.MESSAGE_DELIMITER)
                {
                    hitDelimiter = true;
                    continue;
                }

                if(!hitDelimiter)
                {
                    message.RoutingPrefix.Add(decoded);
                    continue;
                }

                switch (messageSeqIdx)
                {
                    case 0:
                        message.HMACSignature = decoded;
                        break;
                    case 1:
                        message.Header = JsonConvert.DeserializeObject<MessageHeader>(decoded);
                        break;
                    case 2:
                        message.ParentHeader = JsonConvert.DeserializeObject<MessageHeader>(decoded);
                        break;
                    case 3:
                        message.Metadata = JsonConvert.DeserializeObject<Dictionary<string, object>>(decoded);
                        break;
                    case 4:
                        message.Content = JsonConvert.DeserializeObject<Q>(decoded);
                        break;
                    case 5:
                        message.Buffers = JsonConvert.DeserializeObject<List<byte[]>>(decoded);
                        break;
                    default:
                        break;
                }

                messageSeqIdx++;
            }

            return true;
        }
    }
}