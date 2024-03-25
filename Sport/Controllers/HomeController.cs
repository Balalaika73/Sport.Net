using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sport.Models;
using System.Diagnostics;
using System.Security.Claims;
using Activity = System.Diagnostics.Activity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Antiforgery;

namespace Sport.Controllers
{
    public class HomeController : Controller
    {
        private FitnesCenter_DataBaseContext _dataBaseContext;
        private readonly IAntiforgery _antiforgery;
        public HomeController(FitnesCenter_DataBaseContext context, IAntiforgery antiforgery)
        {
            _dataBaseContext = context;
            _antiforgery = antiforgery;
        }

        public IActionResult Index()
        {
            var typeRoom = _dataBaseContext.TypeRooms.ToList();
            var typeAbon = _dataBaseContext.TypeAbonements.ToList();
            MainPage model = new MainPage();
            model.typeRooms = typeRoom;
            model.typeAbonements = typeAbon;
            return View(model);
        }

        public IActionResult AuthIndex()
        {
            var typeRoom = _dataBaseContext.TypeRooms.ToList();
            var typeAbon = _dataBaseContext.TypeAbonements.ToList();
            MainPage model = new MainPage();
            model.typeRooms = typeRoom;
            model.typeAbonements = typeAbon;
            return View(model);
        }

        public async Task<IActionResult> Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userEmail = User.Identity.Name;
                User user = await _dataBaseContext.Users
                    .Include(u => u.Role)
                    .Include(u => u.Trainers)
                    .Include(u => u.Abonements) // Include the Abonement entity
                    .ThenInclude(a => a.TypeAbon) // Include the related TypeAbonement entity
                    .FirstOrDefaultAsync(u => u.EmailUser == userEmail);

                if (user != null)
                {
                    var profilePage = new ProfilePage
                    {
                        user = user,
                        role = user.Role,
                        trainer = user.Trainers.FirstOrDefault(),
                        abonement = user.Abonements.FirstOrDefault() // Assign the first abonnement to the abonement property
                    };

                    return View(profilePage);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditProfile(int? id)
        {
            if (id != null)
            {
                User user = await _dataBaseContext.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(User user)
        {
            _dataBaseContext.Attach(user); // Attach the user object to the context
            _dataBaseContext.Entry(user).State = EntityState.Modified; // Mark the user object as modified
            await _dataBaseContext.SaveChangesAsync();
            return RedirectToAction("Profile");
        }



        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignIn() //проверка авторизованного пользователя
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("AuthIndex", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User client = await _dataBaseContext.Users.FirstOrDefaultAsync(u => u.EmailUser == model.Login && u.PassUser == model.Password);
                if (client != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login);

                    // Получить токен антифоргерийной метки
                    var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
                    var token = tokens.RequestToken;

                    // Вывести токен в консоль браузера
                    ViewData["AntiforgeryToken"] = token;

                    return RedirectToAction("AuthIndex", "Home");
                }
                ModelState.AddModelError("", "Некорректный логин и(или) пароль");
            }
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName) //сохранение пользователя в Cookie
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut() //удаление Cookie
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("Index", "Home");
        }
    }
}