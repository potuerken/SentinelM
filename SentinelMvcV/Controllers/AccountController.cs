using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SentinelMvcV.Helpers;
using SentinelMvcV.Models;

namespace SentinelMvcV.Controllers
{
    public class AccountController : Controller
    {
        IHttpContextAccessor _httpContext;
        public AccountController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto dto)
        {
            string jsonToken = WebApiServices.GetToken(dto).Result;
            if (jsonToken != null)
            {
                SentinelMvcV.Helpers.AccessToken token = JsonConvert.DeserializeObject<AccessToken>(jsonToken);
                if (SetSessions(token))
                    return RedirectToAction("NobetSistemListesi", "NobetSistem");
            }
            return RedirectToAction("Index", "Home");
        }

        private bool SetSessions(AccessToken token)
        {
            if (token.Expiration > DateTime.Now)
            {
                _httpContext.HttpContext.Session.SetString("userId", token.UserId.ToString());
                _httpContext.HttpContext.Session.SetString("jwt", token.Token);
                _httpContext.HttpContext.Session.SetString("jwtexpire", token.Expiration.ToString());
                return true;
            }
            return false;
        }
    }
}
