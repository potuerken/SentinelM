using Check.DTO;
using Check.Enum;
using SentinelMvcV.Helpers;
using SentinelMvcV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.ViewModel
{
    public class NobetSistemViewModel
    {
        public NobetSistemViewModel()
        {
            RutbeDD = UtilitesService.KodGetAll((short)KodTipEnum.Rutbe);
            SubeDD = UtilitesService.KodGetAll((short)KodTipEnum.Sube);
            PersonelListesi = PersonelService.GetAll().OrderBy(a => a.RutbeKod.SiraNo).ToList();
            NobetSistemListesi = NobetSistemService.GetAll();

        }

        public List<PersonelDTO> PersonelListesi { get; set; }
        public List<NobetSistemDTO> NobetSistemListesi { get; set; }
        public List<KodDTO> RutbeDD { get; set; }
        public List<KodDTO> SubeDD { get; set; }
        public NobetSistemDTO CrudNobetSistemDTO { get; set; }

        public ServiceResult NobetSistemAdded(NobetSistemDTO dto, int userId)
        {
            dto.IlkKaydedenKullaniciId = userId;
            dto.SabitNobetciListesi = null;
            return NobetSistemService.SistemAdded(dto);
        }

    }
}
