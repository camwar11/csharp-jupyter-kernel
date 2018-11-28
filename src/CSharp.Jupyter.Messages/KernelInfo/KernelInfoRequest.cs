using CSharp.Jupyter.Messages.General;

namespace CSharp.Jupyter.Messages.KernelInfo
{
    public class KernelInfoRequest : GeneralMessage<KernelInfoRequest.KernelInfoRequestContent>
    {
        public class KernelInfoRequestContent
        {
            // Nothing to see here folks, the request content is empty.
        }
    }
}