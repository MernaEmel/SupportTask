using SupportTask.Models;
using System.ComponentModel.DataAnnotations;

namespace SupportTask.Utilities
{
    
    public class MaxPriceAttribute : ValidationAttribute
    {
        private readonly int _MaxPrice;
        public MaxPriceAttribute(int price) {
            _MaxPrice = price;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product p = (Product)validationContext.ObjectInstance;
            int price;
            if(!int .TryParse(value.ToString(), out price))
            {
                return new ValidationResult("Enter int value");

            }
            if(p.CompanyId==2&& price>_MaxPrice)
            {
                return new ValidationResult("Addidas price Less than"+ _MaxPrice.ToString());
            }
            return ValidationResult.Success;
        }
    }
   
}
