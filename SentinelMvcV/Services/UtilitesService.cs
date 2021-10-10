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
                var kodList = JsonConvert.DeserializeObject<List<KodDTO>>(jsonData).OrderBy(a=>a.SiraNo).ToList();
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


        public static ServiceResult KodUpdated(KodDTO dto)
        {
            jsonData = WebApiServices.Put("utilites", "kodupdated", dto).Result;
            if (jsonData != null)
            {
                var kodUpdated = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return kodUpdated;
            }
            return null;
        }

        public static ServiceResult KodDeleted(KodDTO dto)
        {
            jsonData = WebApiServices.Put("utilites", "koddeleted", dto).Result;
            if (jsonData != null)
            {
                var kodDeleted = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return kodDeleted;
            }
            return null;
        }

    }
}
