using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTask.Data;
using SupportTask.Models;

namespace SupportTask.Controllers
{
    public class Index1Controller : Controller
    {
        private static List<Product> _products = new List<Product>();
        private static List<Company> _company = new List<Company>();
        private readonly ApplicationDbContext _db;

        public  Index1Controller(ApplicationDbContext db)
        {
            _db = db;
            _company.Add(new Company { Id = 1, Name = "nike" });
            _company.Add(new Company { Id = 2, Name = "adidas" });
            
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct() {

            return View();

        }
        [HttpPost]
        public IActionResult AddProduct(Product product) {
            if (!ModelState.IsValid)
            {
                return View(product);   
            }
          _db.products.Add(product);
            _db.SaveChanges();
            _products.Add(product);
            return RedirectToAction("Index");
        }
        #region GetAll
        public IActionResult GetAllData()
        {
            var product = _db.products.Include(p=> p.company).ToList();
            return View(product);
        }

        #endregion
        #region DeleteProduct
        public IActionResult Delete(int id)
        {
            Product? product=_db.products.FirstOrDefault(x => x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("GetAllData");
            
        }
        #endregion
        #region EditProduct
        public IActionResult EditProduct(int id)
        {
            Product product=_db.products.FirstOrDefault(x=>x.Id==id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            Product pd=_db.products.FirstOrDefault(c=>c.Id==product.Id);
            pd.Name= product.Name;
            pd.Description= product.Description;
            pd.Price= product.Price;
            pd.Quantity= product.Quantity;
            pd.EnableSize= product.EnableSize;
            pd.CompanyId=product.CompanyId;
            _db.products.Update(pd);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion

    }
}
