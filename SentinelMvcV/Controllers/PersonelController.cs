using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentinelMvcV.Dto;
using SentinelMvcV.Services;

namespace SentinelMvcV.Controllers
{
    public class PersonelController : Controller
    {
        private readonly string jwtToken;
        private readonly IHttpContextAccessor _httpContext;

        public PersonelController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            var tkn = _httpContext.HttpContext.Session.GetString("jwt");
            if (!string.IsNullOrEmpty(tkn))
                jwtToken = tkn;
        }

       [HttpGet]
        public IActionResult PersonelListesi()
        {
            PersonelService.SetToken = jwtToken;
            var list = PersonelService.GetAll();
            return View(list);
        }
    }
}
