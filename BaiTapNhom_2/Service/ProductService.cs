using BaiTapNhom_2.Models;
namespace BaiTapNhom_2.Service
{
    public interface ProductService
    {
        List<Product> GetAll();
        Product GetById(int id);

    }
}
