using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCardScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}