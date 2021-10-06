using Check.DTO;
using Check.Enum;
using Newtonsoft.Json;
using SentinelMvcV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.Services
{
    public class UtilitesService
    {

        private static string jsonData = "";
        public static string SetToken
        {
            set
            {
                WebApiServices.SetToken = value;
            }
        }


        public static List<KodDTO> KodGetAll(short kodTipId)
        {
            jsonData = WebApiServices.GetSingle("utilites", "getallkod", "?kodTipId=", kodTipId).Result;
            if (jsonData != null)
            {
                var kodList = JsonConvert.DeserializeObject<List<KodDTO>>(jsonData);
                return kodList;
            }
            return null;
        }

        public static ServiceResult KodAdded(KodDTO dto)
        {
            jsonData = WebApiServices.Post("utilites", "kodadded", dto).Result;
            if (jsonData != null)
            {
                var kodAdded = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return kodAdded;
            }
            return null;
        }

    }
}
