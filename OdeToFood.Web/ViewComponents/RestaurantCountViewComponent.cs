using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData data;

        public RestaurantCountViewComponent(IRestaurantData data)
        {
            this.data = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = data.GetCountOfRestaurants();
            return View(count);
        }
    }
}
