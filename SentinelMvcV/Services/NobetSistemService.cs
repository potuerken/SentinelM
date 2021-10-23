using Check.DTO;
using Newtonsoft.Json;
using SentinelMvcV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.Services
{
    public class NobetSistemService
    {
        private static string jsonData = "";
        public static string SetToken
        {
            set
            {
                WebApiServices.SetToken = value;
            }
        }
         
        public static List<NobetSistemDTO> GetAll()
        {
            jsonData = WebApiServices.GetAll("nobetsistem", "getsistemlist").Result;
            if (jsonData != null)
            {
                var sistemList = JsonConvert.DeserializeObject<List<NobetSistemDTO>>(jsonData);
                return sistemList;
            }
            return null;
        }

        public static ServiceResult SistemAdded(NobetSistemDTO dto)
        {
            jsonData = WebApiServices.Post("nobetsistem", "nobetsistemadded", dto).Result;
            if (jsonData != null)
            {
                var sistemAdded = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return sistemAdded;
            }
            return null;
        }

        public static ServiceResult SistemUpdated(NobetSistemDTO dto)
        {
            jsonData = WebApiServices.Put("nobetsistem", "nobetsistemupdated", dto).Result;
            if (jsonData != null)
            {
                var sistemUpdated = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return sistemUpdated;
            }
            return null;
        }

        public static ServiceResult SistemSabitAdded(NobetSistemSabitNobetciIliskiDTO dto)
        {
            jsonData = WebApiServices.Post("nobetsistem", "nobetsistemsabitadded", dto).Result;
            if (jsonData != null)
            {
                var sistemUpdated = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return sistemUpdated;
            }
            return null;
        }

    }
}
