using NetMQ;

namespace CSharp.Jupyter.Kernel.Sockets
{
    public interface ISocket : IOutgoingSocket, IReceivingSocket
    {   
        void Bind(string address);

        void Poll();
    }
}