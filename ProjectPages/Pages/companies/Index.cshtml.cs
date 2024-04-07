using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPages.Data;
using SupportTask.Models;


namespace ProjectPages.Pages.companies
{
    public class IndexModel(ApplicationDbContext _db): PageModel
    {
        public List<Company> companies=new List<Company>();
        public void OnGet()
        {
            companies = _db.Companies.ToList();
        }
        public IActionResult OnPostDelete(int id)
        {
            var company = _db.Companies.FirstOrDefault(c=>c.Id == id);
            if (company != null)
            {
                _db.Companies.Remove(company);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
