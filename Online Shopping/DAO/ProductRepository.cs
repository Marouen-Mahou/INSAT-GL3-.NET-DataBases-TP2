using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.DAO
{
    class ProductRepository
    {
        private ShoppingDbContext Db;

        public ProductRepository(ShoppingDbContext Db)
        {
            this.Db = Db;
        }

        public IEnumerable<dynamic> GetProducts()
        {

            var list = (from p in Db.Products
                        join c in Db.Categories on p.CategoryId equals c.CategoryId
                        //where v.Modele.Contains(filter)
                        select new
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Price = p.Price,
                            Category = c.Nom,
                        }).ToList();
            return list;
        }
        public Product GetProductByID(int Id)
        {
            return (from Product p in Db.Products
                    where p.ProductId == Id
                    select p).SingleOrDefault();
        }

        public void InsertProduct(Product product)
        {
            Db.Products.Add(product);
        }

        public void DeleteProduct(int Id)
        {
            Product product = (from Product p in Db.Products
             where p.ProductId == Id
             select p).SingleOrDefault();
             Db.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            Db.Products.Attach(product);
            Db.Entry(product).State = EntityState.Modified;
        }
        public void OrderProduct(int id, int oid)
        {
            Product product = GetProductByID(id);
            product.OrderId = oid;
            Db.Products.Attach(product);
            Db.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
