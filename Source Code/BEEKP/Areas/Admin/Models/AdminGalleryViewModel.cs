using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminPhotoGalleryViewModel
    {
        public List<Photo> ListPhotoGalleryActive { get; set; }
        public List<Photo> ListPhotoGalleryInActive { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminPhotoGalleryViewModel()
        {
            ListPhotoGalleryActive = new List<Photo>();
            ListPhotoGalleryInActive = new List<Photo>();
        }
    }
    public class AdminVideoGalleryViewModel
    {
        public List<Video> ListVideoActive { get; set; }
        public List<Video> ListVideoInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminVideoGalleryViewModel()
        {
            ListVideoActive = new List<Video>();
            ListVideoInactive = new List<Video>();
        }
    }
    public class Photo
    {
        public Int32 photo_id { get; set; }
       
        public String photo_title { get; set; }
       
        public String photo_name { get; set; }
        public Boolean status { get; set; }
        public Boolean display_dashboard { get; set; }
        public Photo()
        {
            photo_title = "";
            photo_name = "";
            status = false;
            display_dashboard = false;
        }
    }
    public class PhotoManageModel
    {
        public PagePermission PagePermission { get; set; }
        public Photo Photo { get; set; }
        
        public String user_id { get; set; }

        public PhotoManageModel()
        {
            Photo = new Photo();
            user_id = "";
        }
    }
    public class Video
    {
        public Int32 video_id { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public String video_title { get; set; }
        public String video_image_name { get; set; }

        [Url(ErrorMessage ="Invalid Url")]
        [Required(ErrorMessage ="This Field Is Required")]
        public String video_url { get; set; }
        public Int32 sectors_id { get; set; }
        public String sectors_name { get; set; }
        public Boolean status { get; set; }
        public Boolean display_dashboard { get; set; }
        public Video()
        {
            video_title = "";
            video_image_name = "";
            video_url = "";
            status = false;
            display_dashboard = false;
        }
    }
    public class VideoManageModel
    {
        public PagePermission PagePermission { get; set; }
        public Video Video { get; set; }
        public String user_id { get; set; }
        public List<Sectors> ListSectors { get; set; }

        public VideoManageModel()
        {
            Video = new Video();
            user_id = "";
           
        }
    }
}