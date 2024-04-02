using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class ProductLogic
    {
        private List<Product> _products;
        Dictionary<string, CatFood> _catFood;
        Dictionary<string, DogLeash> _dogLeash;

        public ProductLogic()
        {
            _products = new List<Product>();
            _catFood = new Dictionary<string, CatFood>();
            _dogLeash = new Dictionary<string, DogLeash>();
        }

        public void AddProduct(Product product)
        {
            if(product is CatFood)
            {
                _catFood.Add(product.Name, (CatFood)product);
            }
            else if(product is DogLeash)
            {
                _dogLeash.Add(product.Name, (DogLeash)product);
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            return _dogLeash[name];
        }

        public CatFood GetCatFoodByName(string name)
        {
            return _catFood[name];
        }
    }
}
