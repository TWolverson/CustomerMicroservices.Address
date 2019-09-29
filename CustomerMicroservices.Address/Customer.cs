namespace CustomerMicroservices.Address
{
    public class Customer : IHasPostalAddress
    {
        private IBus bus;
        private readonly bool hasAddressHold;

        public Customer(IBus bus, bool hasAddressHold)
        {
            this.bus = bus;
            this.hasAddressHold = hasAddressHold;
        }

        public void RequestChangeAddress(ChangeAddressRequested changeAddressRequested)
        {
            if (CanChangeAddress())
            {
                bus.Publish(new AddressChanged());
            }
            else
            {
                bus.Publish(new BusinessLogicError<ChangeAddressRequested>(changeAddressRequested));
            }
        }

        private bool CanChangeAddress()
        {
            return !hasAddressHold;
        }
    }
}
