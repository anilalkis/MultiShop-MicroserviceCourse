using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
