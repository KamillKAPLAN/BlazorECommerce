using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCardScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}