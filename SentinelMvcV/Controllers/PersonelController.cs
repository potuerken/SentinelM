using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentinelMvcV.Services;
using SentinelMvcV.ViewModel;

namespace SentinelMvcV.Controllers
{
    public class PersonelController : Controller
    {
        private readonly int user;
        private readonly string jwtToken;
        private readonly IHttpContextAccessor _httpContext;

        public PersonelController(IHttpContextAccessor httpContext)
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
        public IActionResult PersonelListesi()
        {
            if (jwtToken != null || user <= 0)
            {
                PersonelService.SetToken = jwtToken;
                PersonelViewModel viewModel = new PersonelViewModel(); 
                if (viewModel != null)
                {
                    TempData.Add("CinsiyetDD", viewModel.CinsiyetDD);
                    TempData.Add("RutbeDD", viewModel.RutbetDD);
                    TempData.Add("SubeDD", viewModel.SubeDD);
                    TempData.Add("PersonelListesi", viewModel.PersonelListesi);
                    return View(viewModel);
                }
                return RedirectToAction("Index", "Home");
            }            
            return RedirectToAction("Index", "Home");
        }
    }
}
