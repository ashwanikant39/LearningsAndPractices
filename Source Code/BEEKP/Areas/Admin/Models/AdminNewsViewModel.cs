using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminNewsViewModel
    {

        public List<News> ListNewsActive { get; set; }
        public List<News> ListNewsInactive { get; set; }
        public News News { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }

        public AdminNewsViewModel()
        {
            ListNewsActive = new List<News>();
            ListNewsInactive = new List<News>();
        }
    }

    public class News
    {
        public Int32 news_id { get; set; }

        [Required(ErrorMessage = "This Field Can't be empty")]
        public String news_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String news_date { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String news_short_description { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String news_full_description { get; set; }
        public string news_image_name { get; set; }
        public Boolean status { get; set; }
        public String news_image_upload { get; set; }
        public List<NewsImage> listNewsImage { get; set; }

        public News()
        {
            news_id = 0;
            news_title = "";
            news_date = "";
            news_short_description = "";
            news_full_description = "";
            news_image_name = "";
            listNewsImage = new List<NewsImage>();
        }

    }
    public class NewsViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public News News { get; set; }

        public String user_id { get; set; }

        public NewsViewAddEditModel()
        {
            PagePermission = new PagePermission();
            News = new News();

            user_id = "";
        }
    }
    public class NewsImage
    {
        public Int32 news_image_id { get; set; }
        public Int32 news_id { get; set; }
        public String news_image_name { get; set; }


    }

    public class NewsImageAddEditViewModel
    {
        public PagePermission PagePermission { get; set; }
        public Int32 news_id { get; set; }
        public NewsImage NewsImage { get; set; }
        public String user_id { get; set; }


        public NewsImageAddEditViewModel()
        {
            PagePermission = new PagePermission();
            NewsImage = new NewsImage();
            user_id = "";
        }
    }
}