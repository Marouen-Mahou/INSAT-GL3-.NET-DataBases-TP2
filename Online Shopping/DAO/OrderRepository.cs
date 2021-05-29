using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.DAO
{
    class OrderRepository
    {
        private ShoppingDbContext Db;

        public OrderRepository(ShoppingDbContext Db)
        {
            this.Db = Db;
        }

        public IEnumerable<Order> GetOrders()
        {
            var list = (from o in Db.Orders
                        select o).ToList();
            return list;
        }

        public IEnumerable<dynamic> GetProducts(int id)
        {
            var list = (from p in Db.Products
                        join c in Db.Categories on p.CategoryId equals c.CategoryId
                        where p.OrderId == id
                        select new
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Price = p.Price,
                            Category = c.Nom,
                        }).ToList();
            return list;
        }
        public Order GetOrderByID(int Id)
        {
            return (from Order o in Db.Orders
                    where o.OrderId == Id
                    select o).SingleOrDefault();
        }

        public void InsertOrder(Order order)
        {
            Db.Orders.Add(order);
        }

        public void DeleteOrder(int Id)
        {
            var list = (from Product p in Db.Products
                        where p.OrderId == Id
                        select p).ToList();

            ProductRepository pDao = new ProductRepository(Db);
            foreach (Product p in list)
            {
                p.OrderId = null;
                pDao.UpdateProduct(p);
            }

            Order order = (from Order o in Db.Orders
                               where o.OrderId == Id
                               select o).SingleOrDefault();
            Db.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            Db.Orders.Attach(order);
            Db.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
