using Check.DTO;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using SentinelMvcV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelMvcV.Services
{
    public static class PersonelService
    {

        private static string jsonData = "";
        public static string SetToken
        {
            set
            {
                WebApiServices.SetToken = value;
            }
        }

        public static List<PersonelDTO> GetAll()
        {
            jsonData = WebApiServices.GetAll("personel", "getpersonel").Result;
            if (jsonData != null)
            {
                var personelList = JsonConvert.DeserializeObject<List<PersonelDTO>>(jsonData);
                return personelList;
            }
            return null;
        }

        public static List<KodDTO> KodGetAll(short kodTipId)
        {
            jsonData = WebApiServices.GetSingle("utilites", "getallkod","?kodTipId=", kodTipId).Result;
            if (jsonData != null)
            {
                var kodList = JsonConvert.DeserializeObject<List<KodDTO>>(jsonData);
                return kodList;
            }
            return null;
        }

    }
}
