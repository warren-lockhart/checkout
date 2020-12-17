namespace CheckoutServices
{
    public interface IScanService
    {
        void Scan(string item);

        double Total();
    }
}
