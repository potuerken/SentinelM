using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentinelMvcV.Services;
using SentinelMvcV.ViewModel;

namespace SentinelMvcV.Controllers
{
    public class UtilitesController : Controller
    {
        private readonly int user;
        private readonly string jwtToken;
        private readonly IHttpContextAccessor _httpContext;
        public UtilitesController(IHttpContextAccessor httpContext)
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
        public IActionResult SubeListesi()
        {
            if (jwtToken != null || user <= 0)
            {
                UtilitesService.SetToken = jwtToken;
                KodSubeViewModel viewModel = new KodSubeViewModel();
                if (viewModel != null)
                {
                    TempData.Add("SubeDD", viewModel.SubeDD);
                    return View(viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
