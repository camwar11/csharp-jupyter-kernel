using System;
using NetMQ;
using NetMQ.Sockets;

namespace CSharp.Jupyter.Kernel.Sockets.Stdin
{
    public class StdinSocket : IStdinSocket
    {
        private readonly RouterSocket _socket;
        public StdinSocket()
        {
            _socket = new RouterSocket();
        }

        public void Bind(string address)
        {
            _socket.Bind(address);
        }

        public bool TryReceive(ref Msg msg, TimeSpan timeout)
        {
            return _socket.TryReceive(ref msg, timeout);
        }

        public bool TrySend(ref Msg msg, TimeSpan timeout, bool more)
        {
            return _socket.TrySend(ref msg, timeout, more);
        }
    }
}