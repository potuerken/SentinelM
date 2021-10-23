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
    public class IzinMazeretViewModel
    {
        public IzinMazeretViewModel()
        {
            PersonelListesi = PersonelService.GetAll().OrderBy(a => a.RutbeKod.SiraNo).ToList();
            IzinDD = UtilitesService.KodGetAll((short)KodTipEnum.IzinMazeretSebebi);
            IzinListesi = PersonelService.IzinListesi();
        }


        public List<IzinMazeretDTO> IzinListesi { get; set; }

        public List<PersonelDTO> PersonelListesi { get; set; }

        public List<KodDTO> IzinDD { get; set; }

        public IzinMazeretDTO CrudIzin { get; set; }


        public ServiceResult IzinMazeretAdded(IzinMazeretDTO dto, int userId)
        {
            dto.IlkKaydedenKullaniciId = userId;
            return PersonelService.IzinAdded(dto);
        }
    }

}
