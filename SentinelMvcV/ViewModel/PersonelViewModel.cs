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
    public class PersonelViewModel
    {
        public PersonelViewModel()
        {
            PersonelListesi = PersonelService.GetAll();
            CinsiyetDD = UtilitesService.KodGetAll((short)KodTipEnum.Cinsiyet);
            RutbetDD = UtilitesService.KodGetAll((short)KodTipEnum.Rutbe);
            SubeDD = UtilitesService.KodGetAll((short)KodTipEnum.Sube);
        }
        public List<PersonelDTO> PersonelListesi { get; set; }
        public List<KodDTO> CinsiyetDD { get; set; }
        public List<KodDTO> RutbetDD { get; set; }
        public List<KodDTO> SubeDD { get; set; }
        public PersonelDTO CrudPersonelDTO { get; set; }


        public ServiceResult PersonelAdded(PersonelDTO dto, int userId)
        {
            dto.Ad = dto.Ad.Trim();
            dto.Soyad = dto.Soyad.Trim();
            dto.Sicil = dto.Sicil.Trim();
            dto.IKKId = userId;
            return PersonelService.PersonelAdded(dto);
        }
    }
}
