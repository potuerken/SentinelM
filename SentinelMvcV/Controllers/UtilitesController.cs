using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Check.DTO;
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

        [HttpPost]
        public IActionResult SubeCrud(KodSubeViewModel dto)
        {
            if (jwtToken != null ||  user <= 0)
            {
                UtilitesService.SetToken = jwtToken;
                if (string.IsNullOrWhiteSpace(dto.CrudSubeKodDTO.Ad))
                {
                    TempData.Add("FailedMessage", "Herhangi bir şey girmeden boşluk bırakarak şube müdürlüğü ekleyemezsiniz.");
                    return RedirectToAction("SubeListesi");
                }
                if (dto.CrudSubeKodDTO.Id == 0)
                {
                    dto.CrudSubeKodDTO.Ad = dto.CrudSubeKodDTO.Ad.Trim();
                    dto.CrudSubeKodDTO.UstKodId = Check.Enum.KodTipEnum.Sube;
                    dto.CrudSubeKodDTO.IKKId = user;
                    var result = UtilitesService.KodAdded(dto.CrudSubeKodDTO);
                    if (result.Success)
                    {
                        TempData.Add("SuccessMessage", result.Message);
                    }
                    else
                    {
                        TempData.Add("FailedMessage", "Hata meydana geldi");
                    }
                }
                return RedirectToAction("SubeListesi");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
