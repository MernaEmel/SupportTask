using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPages.Data;
using SupportTask.Models;

namespace ProjectPages.Pages.companies
{
    public class UpdateModelModel (ApplicationDbContext _db): PageModel
    {
        [BindProperty]
        public Company company { get; set; }
        public void OnGet(int id)
        {
            if(id!=0 && id!=null)
            { 
                company=_db.Companies.FirstOrDefault(c=>c.Id==id);
            }
        }
        public IActionResult OnPost()
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
