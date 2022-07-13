using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Global İsimlendirme oldugu icin '_' kullanılır
        List<Product> _products;
        public InMemoryProductDal()
        {
            // ctor+TAB+TAB Yap || Bellekte Veri Oluşturdu
            _products = new List<Product> 
            {
                new Product{ProductId=1, CategoryId=1, 
                    ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=2,
                    ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2,
                    ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2,
                    ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2,
                    ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Olusturdugumuz veri ile referans id si farklı oldugu için _products.Remove(); calismaz
            //LINQ = Language Integred Query
         //   Product productToDelete = null;//  = new Product(); yaparsak belleği  boş yere yorar
        /*   foreach (var p in _products)
            {
                if(product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }

            } aşağıdaki kısımın açılımı
         */
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // Where içindeki bütün elemanları yeni bir liste halinde döndürür 
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
        public void Update(Product product)
        {   
            // Gönderdiğim ürün id'sine sahip olan listededki ürnü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
