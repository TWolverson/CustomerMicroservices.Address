namespace CustomerMicroservices.Address
{
    public interface IHasPostalAddress
    {
        void RequestChangeAddress(ChangeAddressRequested changeAddressRequested);
    }
}
