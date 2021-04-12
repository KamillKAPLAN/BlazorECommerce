using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCardScreen
{
    public class ViewShoppingCardUseCases
    {
        private readonly IShoppingCart shoppingCard;

        public ViewShoppingCardUseCases(IShoppingCart shoppingCard)
        {
            this.shoppingCard = shoppingCard;
        }

        public Task<Order> Execute()
        {
            return shoppingCard.GetOrderAsync();
        }
    }
}
