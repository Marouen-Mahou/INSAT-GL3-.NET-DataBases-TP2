using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.DAO
{
    class CategoryRepository
    {
        private ShoppingDbContext Db;

        public CategoryRepository(ShoppingDbContext Db)
        {
            this.Db = Db;
        }

        public IEnumerable<Category> GetCategories()
        {
            var list = (from o in Db.Categories
                        select o).ToList();
            return list;
        }

        public IEnumerable<dynamic> GetProducts(int id)
        {
            var list = (from p in Db.Products
                        join c in Db.Categories on p.CategoryId equals c.CategoryId
                        where p.CategoryId == id
                        select new
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Price = p.Price,
                            Category = c.Nom,
                        }).ToList();
            return list;
        }

        public Category GetCategoryByID(int Id)
        {
            return (from Category o in Db.Categories
                    where o.CategoryId == Id
                    select o).SingleOrDefault();
        }

        public void InsertCategory(Category category)
        {
            Db.Categories.Add(category);
        }

        public void DeleteCategory(int Id)
        {
            var list = (from Product p in Db.Products
                        where p.CategoryId == Id
                        select p).ToList();

            foreach(Product p in list)
            {
                Db.Products.Remove(p);
            }

            Category category = (from Category o in Db.Categories
                               where o.CategoryId == Id
                               select o).SingleOrDefault();
            Db.Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            Db.Categories.Attach(category);
            Db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
