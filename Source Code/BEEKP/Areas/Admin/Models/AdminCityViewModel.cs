using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminCityViewModel
    {
        public List<City> ListCity { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminCityViewModel()
        {
            ListCity = new List<City>();
        }
    }

    public class City
    {
        public Int32 city_id { get; set; }
        public Int32 state_id { get; set; }
        public String city_name { get; set; }
        public String state_name { get; set; }
       

        public City()
        {
            city_name = "";
            state_name = "";
        }
    }
    public class CityManageModel
    {
        public PagePermission PagePermission { get; set; }
        public City City { get; set; }
        public List<State> ListState { get; set; }
        public String user_id { get; set; }

        public CityManageModel()
        {
            City = new City();
            ListState = new List<State>();
        }
    }

    public class State
    {
        public Int32 state_id { get; set; }
        public String state_name { get; set; }
        public State()
        {
            state_name = "";
        }
    }

}