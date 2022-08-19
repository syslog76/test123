using lang.Repository;
using lang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace lang.Controllers
{
    public class UserController : MilBaseController<UserController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        

        public UserController(
            ILogger<HomeController> logger,
            IUserRepository userRepository,
        IStringLocalizer<UserController> localizer
            ) : base(localizer)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        // GET: UserController
        public ActionResult Index()
        {
            LoadLocalization();
            return View("Register");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var email = collection["Email"];
                var nickName = collection["Nickname"];

                return View("Index","aa");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
