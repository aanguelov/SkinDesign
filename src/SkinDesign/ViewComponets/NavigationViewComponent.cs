using Microsoft.AspNetCore.Mvc;

namespace SkinDesign.ViewComponets
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
