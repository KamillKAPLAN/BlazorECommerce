using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCardScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCard;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCard)
        {
            this.shoppingCard = shoppingCard;
        }

        public Task<Order> Execute()
        {
            return shoppingCard.GetOrderAsync();
        }
    }
}
