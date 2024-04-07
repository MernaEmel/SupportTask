using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPages.Data;
using SupportTask.Models;

namespace ProjectPages.Pages.companies
{
    public class AddModelModel (ApplicationDbContext _db): PageModel
    {
        [BindProperty]
        public Company company { get; set; }    
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    
    }
}
