﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
