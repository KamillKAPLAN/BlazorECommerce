namespace BlazorECommerce.DependencyInjection
{
    public interface ICustomerService
    {
        string UId { get; set; }

        Customer GetCustomerById(int id);
    }
}