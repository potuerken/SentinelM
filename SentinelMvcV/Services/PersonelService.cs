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

        public static ServiceResult PersonelAdded(PersonelDTO dto)
        {
            jsonData = WebApiServices.Post("personel", "personeladded", dto).Result;
            if (jsonData != null)
            {
                var personelAdded = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return personelAdded;
            }
            return null;
        }

        public static ServiceResult PersonelUpdated(PersonelDTO dto)
        {
            jsonData = WebApiServices.Post("personel", "personelupdated", dto).Result;
            if (jsonData != null)
            {
                var personelUpdated = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return personelUpdated;
            }
            return null;
        }


        public static ServiceResult PersonelDeleted(PersonelDTO dto)
        {
            jsonData = WebApiServices.Post("personel", "personeldeleted", dto).Result;
            if (jsonData != null)
            {
                var personelDeleted = JsonConvert.DeserializeObject<ServiceResult>(jsonData);
                return personelDeleted;
            }
            return null;
        }
    }
}
