using System;

namespace CustomerMicroservices.Address
{
    public interface IBus {
        void Publish(Message message);

        bool HasMessage(Predicate<Message> findMessage);
    }
}
