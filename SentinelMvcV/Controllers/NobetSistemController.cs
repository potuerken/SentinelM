using Check.DTO;
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
                    if (viewModel.NobetSistemListesi.Count() > 0)
                    {
                        foreach (var item in viewModel.NobetSistemListesi)
                        {
                            if (item.SubeIliskiListesi.Count() > 0)
                            {
                                foreach (var itemTwo in item.SubeIliskiListesi)
                                {
                                    item.SubeListesi.Add(itemTwo.SubeKod.Id);
                                }
                            }

                            if (item.RutbeIliskiListesi.Count() > 0)
                            {
                                foreach (var itemThree in item.RutbeIliskiListesi)
                                {
                                    item.RutbeListesi.Add(itemThree.RutbeKod.Id);
                                }
                            }
                        }


                    }


                    TempData.Add("RutbeDD", viewModel.RutbeDD);
                    TempData.Add("SubeDD", viewModel.SubeDD);
                    TempData.Add("PersonelListesiDD", viewModel.PersonelListesi);
                    TempData.Add("NobetSistemListesiDD", viewModel.NobetSistemListesi);
                    //TempData.Add("SabitNobetSistemListesiDD", viewModel.SabitNobetSistemListesi);
                    return View(viewModel);

                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult NobetSistemCrud(NobetSistemViewModel dto)
        {
            if (jwtToken != null && user > 0)
            {
                try
                {
                    NobetSistemService.SetToken = jwtToken;
                    if (dto.CrudNobetSistemDTO.Id == 0)
                    {
                        if (
                            (dto.CrudNobetSistemDTO.HaftaIciGeceNobetciSayisi > 0 && dto.CrudNobetSistemDTO.HaftaIciGeceSaat.Length != 11) &&
                            (dto.CrudNobetSistemDTO.HaftaSonuGeceNobetciSayisi > 0 && dto.CrudNobetSistemDTO.HaftaSonuGeceSaat.Length != 11) &&
                            (dto.CrudNobetSistemDTO.ResmiTatilGeceNobetciSayisi > 0 && dto.CrudNobetSistemDTO.ResmiTatilGeceSaat.Length != 11)
                            )
                        {
                            TempData.Add("FailedMessage", "gece nöbetlerindeki saat ve nöbetçi sayısı hatalı");
                            return RedirectToAction("NobetSistemListesi");
                        }
                        List<NobetSistemSubeIliskiDTO> subeL = new List<NobetSistemSubeIliskiDTO>();
                        List<NobetSistemRutbeIliskiDTO> rutbeL = new List<NobetSistemRutbeIliskiDTO>();
                        NobetSistemSubeIliskiDTO _nobsisSube;
                        NobetSistemRutbeIliskiDTO _nobsisRutbe;

                        foreach (var item in dto.CrudNobetSistemDTO.SubeListesi)
                        {
                            _nobsisSube = new NobetSistemSubeIliskiDTO
                            {
                                AktifMi = true,
                                IlkKaydedenKullaniciId = user,
                                SubeKod = new KodDTO()
                                {
                                    Id = item
                                }
                            };
                            subeL.Add(_nobsisSube);
                        }
                        foreach (var item in dto.CrudNobetSistemDTO.RutbeListesi)
                        {
                            _nobsisRutbe = new NobetSistemRutbeIliskiDTO
                            {
                                AktifMi = true,
                                IlkKaydedenKullaniciId = user,
                                RutbeKod = new KodDTO()
                                {
                                    Id = item
                                }
                            };
                            rutbeL.Add(_nobsisRutbe);
                        }

                        dto.CrudNobetSistemDTO.SubeIliskiListesi = subeL;
                        dto.CrudNobetSistemDTO.RutbeIliskiListesi = rutbeL;

                        var result = dto.NobetSistemAdded(dto.CrudNobetSistemDTO, user);

                        if (result.Success)
                            TempData.Add("SuccessMessage", result.Message);
                        else
                            TempData.Add("FailedMessage", result.Message);
                        return RedirectToAction("NobetSistemListesi");
                    }
                    return RedirectToAction("NobetSistemListesi");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");

                    throw ex;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
