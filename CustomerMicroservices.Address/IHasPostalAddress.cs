namespace CustomerMicroservices.Address
{
    public interface IHasPostalAddress
    {
        void RequestChangeAddress(ChangeAddressRequested changeAddressRequested);

        void RequestAddressHold(AddressHoldRequested addressHoldRequested);

        void RequestReleaseAddressHold(ReleaseAddressHoldRequested releaseAddressHoldRequested);
    }
}
