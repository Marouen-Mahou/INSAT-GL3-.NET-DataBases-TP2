using Online_Shopping.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting ...");

            int rep;
            ShoppingDbContext db = new ShoppingDbContext();

            do
            {
                Console.WriteLine("\n\n Online shopping");
                Console.WriteLine(" 1-Products");
                Console.WriteLine(" 2-Categories");
                Console.WriteLine(" 3-Order");
                Console.WriteLine(" 0-Quitter");
                Console.Write("Reponse : ");
                rep = Int32.Parse(Console.ReadLine());

                if (rep == 1)
                {
                    Console.WriteLine("\n\n Products");
                    Console.WriteLine(" 1- List Products");
                    Console.WriteLine(" 2- Add Product");
                    Console.WriteLine(" 3- Add Product to Order");
                    Console.WriteLine(" 4- Update Product");
                    Console.WriteLine(" 5- Delete Product");
                    Console.WriteLine(" 0-Quitter");
                    Console.Write("Reponse : ");
                    rep = Int32.Parse(Console.ReadLine());

                    ProductRepository pDao = new ProductRepository(db);

                    if(rep == 1)
                    {
                        Console.WriteLine("\n\n List of products \n");
                        var list = pDao.GetProducts();
                        foreach(var p in list)
                        {
                            Console.WriteLine($"{p.ProductId} - {p.Name} - {p.Price} - {p.Category}");
                        }
                    } else if(rep == 2)
                    {
                        Console.Write("\n\nName : ");
                        string name = Console.ReadLine();
                        Console.Write("Price: ");
                        int price = Int32.Parse(Console.ReadLine());
                        Console.Write("CategoryId:");
                        int categoryId = Int32.Parse(Console.ReadLine());

                        Product p = new Product();
                        p.Name = name;
                        p.Price = price;
                        p.CategoryId = categoryId;

                        pDao.InsertProduct(p);
                        pDao.Save();
                    }
                    else if (rep == 3)
                    {
                        Console.Write("\n\nProductId : ");
                        int id = Int32.Parse(Console.ReadLine());

                        Console.Write("\n\nOrderId : ");
                        int Oid = Int32.Parse(Console.ReadLine());
   
                        pDao.OrderProduct(id, Oid);
                        pDao.Save();
                    } else if(rep == 4)
                    {
                        Console.Write("\n\nProductId : ");
                        int id = Int32.Parse(Console.ReadLine());

                        Console.Write("\n\nName : ");
                        string name = Console.ReadLine();
                        Console.Write("Price: ");
                        int price = Int32.Parse(Console.ReadLine());
                        Console.Write("CategoryId:");
                        int categoryId = Int32.Parse(Console.ReadLine());

                        Product p = new Product();
                        p.Name = name;
                        p.Price = price;
                        p.CategoryId = categoryId;
                        p.ProductId = id;

                        pDao.UpdateProduct(p);
                        pDao.Save();
                    } else if(rep == 5)
                    {
                        Console.Write("\n\nProductId : ");
                        int id = Int32.Parse(Console.ReadLine());
                        pDao.DeleteProduct(id);
                        pDao.Save();
                    }
                }
                else if (rep == 2)
                {
                    Console.WriteLine("\n\n Categories");
                    Console.WriteLine(" 1- List Categories");
                    Console.WriteLine(" 2- Add Category");
                    Console.WriteLine(" 3- Get products of category");
                    Console.WriteLine(" 4- Update Category");
                    Console.WriteLine(" 5- Delete Category");
                    Console.WriteLine(" 0-Quitter");
                    Console.Write("Reponse : ");
                    rep = Int32.Parse(Console.ReadLine());

                    CategoryRepository cDao = new CategoryRepository(db);

                    if (rep == 1)
                    {
                        Console.WriteLine("\n\n List of Categories \n");
                        var list = cDao.GetCategories();
                        foreach (Category c in list)
                        {
                            Console.WriteLine($"{c.CategoryId} - {c.Nom}");
                        }
                    }
                    else if (rep == 2)
                    {
                        Console.Write("\n\nName : ");
                        string name = Console.ReadLine();

                        Category c = new Category();
                        c.Nom = name;

                        cDao.InsertCategory(c);
                        cDao.Save();
                    }
                    else if (rep == 3)
                    {
                        Console.Write("\n\nCategory Id : ");
                        int id = Int32.Parse(Console.ReadLine());

                        var list = cDao.GetProducts(id);

                        Console.WriteLine("\n\n List of products of categroy \n");

                        foreach (var p in list)
                        {
                            Console.WriteLine($"{p.ProductId} - {p.Name} - {p.Price} - {p.Category}");
                        }

                    }
                    else if (rep == 4)
                    {
                        Console.Write("\n\nCategory Id : ");
                        int id = Int32.Parse(Console.ReadLine());

                        Console.Write("\n\nName : ");
                        string name = Console.ReadLine();

                        Category c = new Category();
                        c.Nom = name;
                        c.CategoryId = id;

                        cDao.UpdateCategory(c);
                        cDao.Save();
                    }
                    else if (rep == 5)
                    {
                        Console.Write("\n\nCategoryId : ");
                        int id = Int32.Parse(Console.ReadLine());
                        cDao.DeleteCategory(id);
                        cDao.Save();
                    }
                }
                else if (rep == 3)
                {
                    Console.WriteLine("\n\n Orders");
                    Console.WriteLine(" 1- List Orders");
                    Console.WriteLine(" 2- Create Order");
                    Console.WriteLine(" 3- Get products of order");
                    Console.WriteLine(" 4- Delete Order");
                    Console.WriteLine(" 0-Quitter");
                    Console.Write("Reponse : ");
                    rep = Int32.Parse(Console.ReadLine());

                    OrderRepository oDao = new OrderRepository(db);

                    if (rep == 1)
                    {
                        Console.WriteLine("\n\n List of orders \n");
                        var list = oDao.GetOrders();
                        foreach (Order p in list)
                        {
                            Console.WriteLine($"{p.OrderId} - {p.quantity}");
                        }
                    }
                    else if (rep == 2)
                    {

                        Order o = new Order();

                        o.quantity = 0;

                        oDao.InsertOrder(o);
                        oDao.Save();

                        Console.WriteLine("\n Order created \n");
                    }
                    else if (rep == 3)
                    {
                        Console.Write("\n\nOrderId : ");
                        
                        int id = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("\n\n List of products of an order \n");

                        var list = oDao.GetProducts(id);
                        foreach (var p in list)
                        {
                            Console.WriteLine($"{p.ProductId} - {p.Name} - {p.Price} - {p.Category}");
                        }
                    }
                    else if (rep == 4)
                    {
                        Console.Write("\n\nOrderId : ");
                        int id = Int32.Parse(Console.ReadLine());
                        oDao.DeleteOrder(id);
                        oDao.Save();
                    }
                }
            } while (rep != 0);
            Console.Write("\nAu revoir ! ");
            db.SaveChanges();
        }
    }
}
