using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentinelMvcV.Services;
using SentinelMvcV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.Controllers
{
    public class NobetSistemController : Controller
    {
        private readonly int user;
        private readonly string jwtToken;
        private readonly IHttpContextAccessor _httpContext;

        public NobetSistemController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            var tkn = _httpContext.HttpContext.Session.GetString("jwt");
            int userId = Convert.ToInt32(_httpContext.HttpContext.Session.GetString("userId"));
            if (!string.IsNullOrEmpty(tkn) || userId > 0)
            {
                jwtToken = tkn;
                user = userId;
            }
        }

        [HttpGet]
        public IActionResult NobetSistemListesi()
        {
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                NobetSistemViewModel viewModel = new NobetSistemViewModel();
                if (viewModel != null)
                {
                    TempData.Add("RutbeDD", viewModel.RutbeDD);
                    TempData.Add("SubeDD", viewModel.SubeDD);
                    TempData.Add("PersonelListesiDD", viewModel.PersonelListesi);
                    TempData.Add("NobetSistemListesiDD", viewModel.NobetSistemListesi);
                    TempData.Add("SabitNobetSistemListesiDD", viewModel.SabitNobetSistemListesi);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
