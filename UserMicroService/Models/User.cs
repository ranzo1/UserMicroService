using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserMicroService.Models
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }


    }
}