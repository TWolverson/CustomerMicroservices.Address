using System;
using System.Collections.Generic;

namespace CustomerMicroservices.Address.Tests
{
    class TestBus : IBus
    {
        private List<Message> messages = new List<Message>();

        public bool HasMessage(Predicate<Message> findMessage)
        {
            return messages.Find(findMessage) != null;
        }

        public void Publish(Message message)
        {
            messages.Add(message);
        }
    }
}
