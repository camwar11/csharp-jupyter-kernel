using System;
using System.Collections.Generic;
using CSharp.Jupyter.Messages.KernelInfo;
using NetMQ;
using NetMQ.Sockets;

namespace CSharp.Jupyter.Kernel.Sockets.Shell
{
    public class ShellSocket : IShellSocket
    {
        private readonly RouterSocket _socket;
        private Msg? _msg;

        public ShellSocket()
        {
            _socket = new RouterSocket();
        }

        public void Bind(string address)
        {
            _socket.Bind(address);
        }

        public void Poll()
        {
            if(_msg == null)
            {
                _msg = new Msg();
                _msg.Value.InitEmpty();
            }

            KernelInfoRequest infoRequest;

            if(this.TryGetMessage<KernelInfoRequest, KernelInfoRequest.KernelInfoRequestContent>(out infoRequest))
            {
                
            }
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