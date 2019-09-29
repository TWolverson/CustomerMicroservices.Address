using System;

namespace CustomerMicroservices.Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class BusinessLogicError<T> : Message
    {
        public T RelatesTo { get; private set; }

        public BusinessLogicError(T relatesTo)
        {
            RelatesTo = relatesTo;
        }
    }
}
