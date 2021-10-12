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
            if (jwtToken != null && user > 0)
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
        [ValidateAntiForgeryToken]
        public IActionResult SubeCrud(KodSubeViewModel dto)
        {
            if (jwtToken != null &&  user > 0)
            {
                UtilitesService.SetToken = jwtToken;
                if (string.IsNullOrWhiteSpace(dto.CrudSubeKodDTO.Ad))
                {
                    TempData.Add("FailedMessage", "Herhangi bir şey girmeden boşluk bırakarak şube müdürlüğü ekleyemezsiniz.");
                    return RedirectToAction("SubeListesi");
                }
                if (dto.CrudSubeKodDTO.Id == 0)
                {
                    var result = dto.SubeAdded(dto.CrudSubeKodDTO, user);
                    if (result.Success)
                        TempData.Add("SuccessMessage", result.Message);
                    else
                        TempData.Add("FailedMessage", "Hata meydana geldi");
                }
                else if (dto.CrudSubeKodDTO.Id > 0 && dto.CrudSubeKodDTO.UstKodId == 0)
                {
                    if (dto.CrudSubeKodDTO.Ad == dto.SubeDD.Where(a => a.Id == dto.CrudSubeKodDTO.Id).Select(b => b.Ad).FirstOrDefault())
                    {
                        TempData.Add("FailedMessage", "Değiştirmek istenen şube müdürlüğü adı ile yeni eklenen şube müdürlüğü adı aynıdır.");
                        return RedirectToAction("SubeListesi");
                    }
                    var result = dto.SubeUpdated(dto.CrudSubeKodDTO, user);
                    if (result.Success)
                        TempData.Add("SuccessMessage", result.Message);
                    else
                        TempData.Add("FailedMessage", "Hata meydana geldi");
                }
                else if (dto.CrudSubeKodDTO.UstKodId > 0 && dto.CrudSubeKodDTO.Id > 0)
                {
                    var result = dto.SubeDeleted(dto.CrudSubeKodDTO, user);
                    if (result.Success)
                        TempData.Add("SuccessMessage", result.Message);
                    else
                        TempData.Add("FailedMessage", result.Message);
                }
                return RedirectToAction("SubeListesi");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
