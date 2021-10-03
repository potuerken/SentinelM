using Check.DTO;
using Check.Enum;
using SentinelMvcV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.ViewModel
{
    public class PersonelViewModel
    {
        public PersonelViewModel()
        {
            PersonelListesi = PersonelService.GetAll();
            CinsiyetDD = PersonelService.KodGetAll((short)KodTipEnum.Cinsiyet);
            RutbetDD = PersonelService.KodGetAll((short)KodTipEnum.Rutbe);
            SubeDD = PersonelService.KodGetAll((short)KodTipEnum.Sube);
        }
        public List<PersonelDTO> PersonelListesi { get; set; }
        public List<KodDTO> CinsiyetDD { get; set; }
        public List<KodDTO> RutbetDD { get; set; }
        public List<KodDTO> SubeDD { get; set; }
        public PersonelDTO CrudPersonelDTO { get; set; }
    }
}
