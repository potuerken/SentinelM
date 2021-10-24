using Check.DTO;
using SentinelMvcV.Helpers;
using SentinelMvcV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.ViewModel
{
    public class NobetListesiViewModel
    {
        public NobetListesiViewModel()
        {
            NobetSistemListesi = NobetSistemService.GetAll();
            CrudNobetListesi = new NobetListesiDTO();
            NobetListesi = NobetSistemService.GetAllNobetListesi();
        }

        public List<NobetListesiDTO> NobetListesi { get; set; }
        public List<NobetSistemDTO> NobetSistemListesi { get; set; }
        public NobetListesiDTO CrudNobetListesi { get; set; }

        public int NobetListesiId { get; set; }


        public ServiceResult NobetSistemAdded(NobetListesiDTO dto, int userId)
        {
            var varMi = NobetListesi.Any(a => a.Ay == dto.Ay && a.Yil == dto.Yil && a.NobetSistem.Id == dto.NobetSistem.Id);
            if (varMi)
            {
                return new ServiceResult(false, "liste mevcut");
            }

            dto.IlkKaydedenKullaniciId = userId;
            return NobetSistemService.ListeAdd(dto);
        }

    }
}
