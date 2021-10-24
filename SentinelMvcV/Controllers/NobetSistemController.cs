using Check.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                        #region Old Code
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

                            item.SabitciList = JsonConvert.SerializeObject(item.SabitNobetciListesi);
                            item.RutbeList = JsonConvert.SerializeObject(item.RutbeListesi);
                            item.SubeList = JsonConvert.SerializeObject(item.SubeListesi);
                        }
                        #endregion
                    }
                    TempData.Add("RutbeDD", viewModel.RutbeDD);
                    TempData.Add("SubeDD", viewModel.SubeDD);
                    TempData.Add("PersonelListesiDD", viewModel.PersonelListesi);
                    TempData.Add("NobetSistemListesiDD", viewModel.NobetSistemListesi);
                    TempData.Add("SabitNobetDD", viewModel.SabitNobetDD);
                    //TempData.Add("SabitNobetSistemListesiDD", viewModel.SabitNobetSistemListesi);
                    return View(viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult NobetListesi()
        {
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                NobetListesiViewModel viewModel = new NobetListesiViewModel();
                if (viewModel != null)
                {
                    if (viewModel.NobetSistemListesi.Count() <= 0)
                    {
                        TempData.Add("FailedMessage", "aktif bir nöbet sistemi mevcut değil.");
                        return RedirectToAction("NobetListesi");
                    }
                    TempData.Add("NobetListesiDD", viewModel.NobetListesi);

                    TempData.Add("NobetSistemDD", viewModel.NobetSistemListesi);
                    return View(viewModel);

                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    }
                    else
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
                                NobetSistemId = dto.CrudNobetSistemDTO.Id,
                                AktifMi = true,
                                SonKaydedenKullaniciId = user,
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
                                NobetSistemId = dto.CrudNobetSistemDTO.Id,
                                AktifMi = true,
                                SonKaydedenKullaniciId = user,
                                RutbeKod = new KodDTO()
                                {
                                    Id = item
                                }
                            };
                            rutbeL.Add(_nobsisRutbe);
                        }

                        dto.CrudNobetSistemDTO.SubeIliskiListesi = subeL;
                        dto.CrudNobetSistemDTO.RutbeIliskiListesi = rutbeL;

                        var result = dto.NobetSistemUpdated(dto.CrudNobetSistemDTO, user);

                        if (result.Success)
                            TempData.Add("SuccessMessage", result.Message);
                        else
                            TempData.Add("FailedMessage", result.Message);
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NobetListesiCrud(NobetListesiViewModel dto)
        {
            if (jwtToken != null && user > 0)
            {
                try
                {
                    NobetSistemService.SetToken = jwtToken;
                    if (dto.CrudNobetListesi.Id == 0)
                    {
                        DateTime currentDate = DateTime.Now;
                        if (dto.CrudNobetListesi.DenemeTarihi < currentDate)
                        {
                            TempData.Add("FailedMessage", "geçmişe yönelik nöbet listesi hazırlanamaz");
                            return RedirectToAction("NobetListesi");
                        }

                        dto.CrudNobetListesi.Ay = (short)dto.CrudNobetListesi.DenemeTarihi.Month;
                        dto.CrudNobetListesi.Yil = (short)dto.CrudNobetListesi.DenemeTarihi.Year;

                        var result = dto.NobetSistemAdded(dto.CrudNobetListesi, user);
                        if (result.Success)
                            TempData.Add("SuccessMessage", result.Message);
                        else
                            TempData.Add("FailedMessage", result.Message);
                        return RedirectToAction("NobetListesi");


                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");

                    throw ex;
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NobetSistemSabitlerCrud(NobetSistemViewModel dto)
        {
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                if (dto.CrudSabitNobetciDTO.Id <= 0)
                {
                    if (dto.CrudSabitNobetciDTO.NobetSistemId <= 0 || dto.CrudSabitNobetciDTO.SabitNobetSistemiKod.Id <= 0 || dto.CrudSabitNobetciDTO.SabitPersonel.Id <= 0)
                    {
                        TempData.Add("FailedMessage", "veriler gönderilirken hata meydana geldi");
                        return RedirectToAction("NobetSistemListesi");
                    }
                    dto.CrudSabitNobetciDTO.AktifMi = true;
                    dto.CrudSabitNobetciDTO.IlkKaydedenKullaniciId = user;

                    var result = NobetSistemService.SistemSabitAdded(dto.CrudSabitNobetciDTO);
                    if (result.Success)
                        TempData.Add("SuccessMessage", result.Message);
                    else
                        TempData.Add("FailedMessage", result.Message);
                    return RedirectToAction("NobetSistemListesi");

                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public string GetSabitListesi(int id)
        {
            string jsonRes = string.Empty;
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                NobetSistemViewModel viewModel = new NobetSistemViewModel();
                if (viewModel != null)
                {
                    if (viewModel.NobetSistemListesi.Count() > 0)
                    {
                        var sonuc = viewModel.NobetSistemListesi.Where(q => q.Id == id).Select(s => s.SabitNobetciListesi.Select(x => x.SabitPersonel)).ToList();
                        jsonRes = JsonConvert.SerializeObject(sonuc[0]);
                    }
                }
            }
            return jsonRes;
        }

        [HttpGet]
        public string NobetListesiHazirla(int id)
        {
            string jsonRes = string.Empty;
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                var nobetListesiDetay = NobetSistemService.GetAllNobetListesiDetay(id);
                if (nobetListesiDetay.Count() == 0)
                {
                    //ekleme metodu gelcek
                }
                jsonRes = JsonConvert.SerializeObject(nobetListesiDetay[0]);

            }
            return jsonRes;
        }

        [HttpGet]
        public IActionResult NobetListesiDetay(int Id)
        {
            if (jwtToken != null && user > 0)
            {
                NobetSistemService.SetToken = jwtToken;
                NobetListesiViewModel viewModel = new NobetListesiViewModel();
                if (viewModel != null)
                {
                    if (viewModel.NobetSistemListesi.Count() <= 0)
                    {
                        TempData.Add("FailedMessage", "aktif bir nöbet sistemi mevcut değil.");
                        return RedirectToAction("NobetListesi");
                    }
                    TempData.Add("NobetListesiDD", viewModel.NobetListesi);

                    TempData.Add("NobetSistemDD", viewModel.NobetSistemListesi);
                    return View(viewModel);

                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }




    }
}
