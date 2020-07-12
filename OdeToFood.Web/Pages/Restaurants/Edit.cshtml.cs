using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using static OdeToFood.Core.Restaurant;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
       
       
        private readonly IRestaurantData data;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData data, IHtmlHelper htmlHelper)
        {
            this.data = data;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId == null)
            {
                Restaurant = new Restaurant();
                return Page();
            }
            else
            {
                Restaurant = data.GetById(restaurantId.Value);
                if (Restaurant != null)
                {
                    return Page();
                }
            }   
            return RedirectToPage("NotFound");
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.Id == 0)
            {
                Restaurant = data.Create(Restaurant);
                TempData["Message"] = "Restaurant Created!";
            }
            else
            {
                Restaurant = data.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated!";
            }
            data.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}