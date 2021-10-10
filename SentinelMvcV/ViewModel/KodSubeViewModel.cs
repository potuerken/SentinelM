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
    public class KodSubeViewModel
    {
        public KodSubeViewModel()
        {
            SubeDD = UtilitesService.KodGetAll((short)KodTipEnum.Sube);
        }

        public List<KodDTO> SubeDD { get; set; }

        public KodDTO CrudSubeKodDTO { get; set; }


        public ServiceResult SubeAdded(KodDTO dto, int userId)
        {
            dto.Ad = dto.Ad.Trim();
            dto.UstKodId = Check.Enum.KodTipEnum.Sube;
            dto.IKKId = userId;
            return UtilitesService.KodAdded(dto);
        }

        public ServiceResult SubeUpdated(KodDTO dto, int userId)
        {
            dto.Ad = dto.Ad.Trim();
            dto.SKKId = userId;
            return  UtilitesService.KodUpdated(dto);
        }

        public ServiceResult SubeDeleted(KodDTO dto, int userId)
        {
            dto.SKKId = userId;
            return UtilitesService.KodDeleted(dto);
        }
    }
}
