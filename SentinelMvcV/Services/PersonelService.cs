using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using SentinelMvcV.Dto;
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
            var personelList = JsonConvert.DeserializeObject<List<PersonelDTO>>(jsonData);
            return personelList;
        }
    }
}
