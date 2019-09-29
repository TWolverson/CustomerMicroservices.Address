using Xunit;

namespace CustomerMicroservices.Address.Tests
{
    public class ChangeAddressTests
    {
        [Fact]
        public void CanChangeAddress()
        {
            IBus bus = new TestBus();
            IHasPostalAddress customer = new Customer(bus);
            customer.RequestChangeAddress(new ChangeAddressRequested());
            Assert.True(bus.HasMessage(m => m is AddressChanged));
        }

        [Fact]
        public void WhenAddressHoldIsActive_CannotChangeAddress()
        {
            IBus bus = new TestBus();
            IHasPostalAddress customer = new Customer(bus);
            customer.RequestAddressHold(new AddressHoldRequested());
            customer.RequestChangeAddress(new ChangeAddressRequested());
            Assert.False(bus.HasMessage(m => m is AddressChanged));
            Assert.True(bus.HasMessage(m => m is BusinessLogicError<ChangeAddressRequested>));
        }

        [Fact]
        public void WhenAddressHold_IsActive_AndIsMadeInactive_CanChangeAddress() {

            IBus bus = new TestBus();
            IHasPostalAddress customer = new Customer(bus);
            customer.RequestAddressHold(new AddressHoldRequested());
            customer.RequestReleaseAddressHold(new ReleaseAddressHoldRequested());
            customer.RequestChangeAddress(new ChangeAddressRequested());
            Assert.True(bus.HasMessage(m => m is AddressChanged));
        }
    }
}
