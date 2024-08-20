using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _CarouselComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
