using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminDiscussionForumViewModel
    {
        public List<DiscussionForum> ListDiscussionForumActive { get; set; }
        public List<DiscussionForum> ListDiscussionForumInactive { get; set; }
        public PagePermission PagePermission { get; set; }

        public AdminDiscussionForumViewModel()
        {
            ListDiscussionForumActive = new List<DiscussionForum>();
            ListDiscussionForumInactive = new List<DiscussionForum>();
        }
    }

    public class AdminDiscussionForumApprovedViewModel
    {
        public List<DiscussionForum> ListDiscussionForumApproval_Pending { get; set; }
        public List<DiscussionForum> ListDiscussionForumApproval_Approved { get; set; }
        public List<DiscussionForum> ListDiscussionForumApproval_Rejected { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminDiscussionForumApprovedViewModel()
        {
            ListDiscussionForumApproval_Pending = new List<DiscussionForum>();
            ListDiscussionForumApproval_Approved = new List<DiscussionForum>();
            ListDiscussionForumApproval_Rejected = new List<DiscussionForum>();
        }
    }


    public class DiscussionForum
    {
        public Int32 forum_id { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public Int32 cluster_id { get; set; }
        //[Required(ErrorMessage ="This Field is required")]
        public String cluster_name { get; set; }
        public String forum_topic { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public String forum_description { get; set; }
        public Boolean status { get; set; }
        public Int32 approval_status { get; set; }
        public String approval_status_message { get; set; }
        //public String approved_forum_topic { get; set; }
        //public String approved_forum_description { get; set; }
        public String remarks { get; set; }

        public DiscussionForum()
        {
            forum_topic = "";
            forum_description = "";
            //approved_forum_topic = "";
            //approved_forum_description = "";
            remarks = "";
            approval_status_message = "";
        }
    }

    public class DiscussionForumManageModel
    {
        public PagePermission PagePermission { get; set; }
        public DiscussionForum DiscussionForum { get; set; }

        public List<Cluster> ListCluster { get; set; }
        public String user_id { get; set; }


    }

    public class DiscussionForumApproveModel
    {
        public PagePermission PagePermission { get; set; }
        public DiscussionForum DiscussionForum { get; set; }
        public String user_id { get; set; }

    }
}