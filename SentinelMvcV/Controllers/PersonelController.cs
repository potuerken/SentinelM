using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (jwtToken != null && user > 0)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelCrud(PersonelViewModel dto)
        {
            if (jwtToken != null && user > 0)
            {
                try
                {
                    PersonelService.SetToken = jwtToken;
                    if (dto.CrudPersonelDTO.Id == 0)
                    {
                        bool tcAndSicilAny = dto.PersonelListesi.Any((a => (a.Sicil == dto.CrudPersonelDTO.Sicil || a.Tckn == dto.CrudPersonelDTO.Tckn) && a.Id != dto.CrudPersonelDTO.Id));
                        if (tcAndSicilAny)
                        {
                            TempData.Add("FailedMessage", "TCKN VEYA SİCİL İLE EŞLEYEN KAYIT MEVCUT");
                            return RedirectToAction("PersonelListesi");
                        }

                        var result = dto.PersonelAdded(dto.CrudPersonelDTO, user);

                        if (result.Success)
                            TempData.Add("SuccessMessage", result.Message);
                        else
                            TempData.Add("FailedMessage", result.Message);
                        return RedirectToAction("PersonelListesi");
                    }
                    else if (dto.CrudPersonelDTO.Id > 0)
                    {
                        bool tcAndSicilAny = dto.PersonelListesi.Any((a => (a.Sicil == dto.CrudPersonelDTO.Sicil || a.Tckn == dto.CrudPersonelDTO.Tckn) && a.Id != dto.CrudPersonelDTO.Id));
                        if (tcAndSicilAny)
                        {
                            TempData.Add("FailedMessage", "TCKN VEYA SİCİL İLE EŞLEYEN KAYIT MEVCUT");
                            return RedirectToAction("PersonelListesi");
                        }
                        var result = dto.PersonelUpdated(dto.CrudPersonelDTO, user);
                        if (result.Success)
                            TempData.Add("SuccessMessage", result.Message);
                        else
                            TempData.Add("FailedMessage", result.Message);
                        return RedirectToAction("PersonelListesi");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult IzinMazeretListesi()
        {
            if (jwtToken != null && user > 0)
            {
                PersonelService.SetToken = jwtToken;
                IzinMazeretViewModel viewModel = new IzinMazeretViewModel();
                if (viewModel != null)
                {
                    TempData.Add("PersonelListesi", viewModel.PersonelListesi);
                    TempData.Add("IzinDD", viewModel.IzinDD);
                    TempData.Add("IzinListesi", viewModel.IzinListesi);
                    return View(viewModel);

                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IzinCrud(IzinMazeretViewModel dto)
        {
            if (jwtToken != null && user > 0)
            {
                PersonelService.SetToken = jwtToken;
                if (dto.CrudIzin.Id == 0)
                {
                    if (dto.CrudIzin.BaslangicTarihi > dto.CrudIzin.BitisTarihi)
                    {
                        TempData.Add("FailedMessage", "izin tarihleri hatalı");
                        return RedirectToAction("IzinMazeretListesi");
                    }

                    var result = dto.IzinMazeretAdded(dto.CrudIzin, user);
                    if (result.Success)
                        TempData.Add("SuccessMessage", result.Message);
                    else
                        TempData.Add("FailedMessage", result.Message);
                    return RedirectToAction("IzinMazeretListesi");
                }
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");

        }


    }
}
