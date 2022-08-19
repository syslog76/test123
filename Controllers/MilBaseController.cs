using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace lang.Controllers
{
    public class MilBaseController : Controller
    {
        public readonly IStringLocalizer<HomeController> _localizer;
        public MilBaseController(
            IStringLocalizer<HomeController> localizer
            )
        {
            _localizer = localizer;
        }

        protected void LoadLocalization()
        {
            _localizer.GetAllStrings().ToList().ForEach(item => { ViewData[item.Name] = item.Value as string; });
        }
    }
}
