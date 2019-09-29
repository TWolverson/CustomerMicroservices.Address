namespace CustomerMicroservices.Address
{
    public class Customer : IHasPostalAddress
    {
        private IBus bus;
        private bool hasAddressHold;

        public Customer(IBus bus)
        {
            this.bus = bus;
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

        public void RequestAddressHold(AddressHoldRequested addressHoldRequested)
        {
            hasAddressHold = true;
        }

        public void RequestReleaseAddressHold(ReleaseAddressHoldRequested releaseAddressHoldRequested)
        {
            hasAddressHold = false;
        }
    }
}
