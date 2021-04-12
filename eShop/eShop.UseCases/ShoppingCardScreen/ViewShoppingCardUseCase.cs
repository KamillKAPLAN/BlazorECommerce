using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCardScreen
{
    public class ViewShoppingCardUseCase : IViewShoppingCardUseCase
    {
        private readonly IShoppingCart shoppingCard;

        public ViewShoppingCardUseCase(IShoppingCart shoppingCard)
        {
            this.shoppingCard = shoppingCard;
        }

        public Task<Order> Execute()
        {
            return shoppingCard.GetOrderAsync();
        }
    }
}
