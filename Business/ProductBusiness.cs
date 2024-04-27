using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();
            ProductData data = new ProductData();
            var product= data.GetProducts();
            
            return product;
        }
        public List<Product> GetProductsByName(string name)
        {
            List<Product> products = new List<Product>();
            ProductData data = new ProductData();
            products = data.GetProducts();
            var result = products.Where(x => x.name.Contains(name)).ToList();
            return result;
        }
    }
}
