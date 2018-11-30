using NetMQ;
using NetMQ.Sockets;

namespace CSharp.Jupyter.Kernel.Sockets.Heartbeat
{
    public class HeartbeatSocket
    {
        public HeartbeatSocket(string connection)
        {
            NetMQSocket socket = new ResponseSocket();
            socket.Bind(connection);
        }
    }
}