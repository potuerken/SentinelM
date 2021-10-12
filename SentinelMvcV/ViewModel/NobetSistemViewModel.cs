using Check.DTO;
using Check.Enum;
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
            SabitNobetSistemListesi = UtilitesService.KodGetAll((short)KodTipEnum.SabitNobetSistemi);
        }

        public List<PersonelDTO> PersonelListesi { get; set; }
        public List<NobetSistemDTO> NobetSistemListesi { get; set; }
        public List<KodDTO> RutbeDD { get; set; }
        public List<KodDTO> SubeDD { get; set; }
        public List<KodDTO> SabitNobetSistemListesi { get; set; }
        public NobetSistemDTO CrudNobetSistemDTO { get; set; }
    }
}
