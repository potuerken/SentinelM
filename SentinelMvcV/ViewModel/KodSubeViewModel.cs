using Check.DTO;
using Check.Enum;
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
    }
}
