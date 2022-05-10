using static Domain.Enums.Enums;

namespace Application.Interfaces
{
    public interface IMessageServices
    {
        string GetMessage(int Code, MessageType messageType);
    }
}
