using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.ShoppingCard.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string cstrShoppingCart = "eShop.ShoppingCart";
        private readonly IJSRuntime jsRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            this.jsRuntime = jsRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public Task EmptyAsync()
        {
            return SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quanity)
        {
            var order = await GetOrder();
            if (quanity < 0)
                return order;
            else if (quanity == 0)
                return await DeleteProductAsync(productId);

            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
            if (lineItem != null) lineItem.Quantity = quanity;
            await SetOrder(order);

            return order;
        }

        public async Task<Order> GetOrder()
        {
            Order order = null;

            var strOrder = await jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != null)
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }
            if (order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    item.Product = productRepository.GetProduct(item.ProductId);
                }
            }

            return order;
        }

        public async Task SetOrder(Order order)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
