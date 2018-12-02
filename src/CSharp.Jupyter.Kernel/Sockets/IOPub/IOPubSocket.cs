using System;
using NetMQ;
using NetMQ.Sockets;

namespace CSharp.Jupyter.Kernel.Sockets.IOPub
{
    public class IOPubSocket : IIOPubSocket
    {
        private readonly PublisherSocket _socket;
        public IOPubSocket()
        {
            _socket = new PublisherSocket();
        }

        public void Bind(string address)
        {
            _socket.Bind(address);
        }

        public void Poll()
        {
            throw new NotImplementedException();
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