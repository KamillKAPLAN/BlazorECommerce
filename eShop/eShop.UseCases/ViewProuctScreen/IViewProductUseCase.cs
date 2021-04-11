using eShop.CoreBusiness.Models;

namespace eShop.UseCases.ViewProuctScreen
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}
