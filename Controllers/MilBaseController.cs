using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace lang.Controllers
{
    public class MilBaseController<T> : Controller where T : class
    {
        public readonly IStringLocalizer<T> _localizer;
        public MilBaseController(
            IStringLocalizer<T> localizer
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
