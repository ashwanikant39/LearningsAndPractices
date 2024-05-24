using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminKnowledgeBankViewModel
    {
        public PagePermission PagePermission { get; set; }
        public List<KnowledgeBank> ListKnowledgeBankActive { get; set; }
        public List<KnowledgeBank> ListKnowledgeBankInactive { get; set; }
        public List<KnowledgeBankType> ListKnowledgeBankType { get; set; }
    }
    public class KnowledgeBank
    {
        public Int32 knowledge_bank_id { get; set; }
        public Int32 knowledge_bank_type_id { get; set; }
        public String knowledge_bank_type_name { get; set; }
        public String knowledge_bank_name { get; set; }
        public String file_name { get; set; }
        public Boolean status { get; set; }
    }
    public class KnowledgeBankType
    {
        public Int32 knowledge_bank_type_id { get; set; }
        public String knowledge_bank_type_name { get; set; }
    }
    public class KnowledgeBankManageModel
    {
        public List<KnowledgeBankType> ListKnowledgeBankType { get; set; }
        public KnowledgeBank KnowledgeBank { get; set; }
        public KnowledgeBankType KnowledgeBankType { get; set; }
        public PagePermission PagePermission { get; set; }
        public String user_id { get; set; }
    }

   

    public class VideoLibrary
    {
        public Int32 video_id { get; set; }
        public Int32 sector_id { get; set; }
        public String sector_name { get; set; }
        public String technology { get; set; }
        public String video_url { get; set; }
        public Boolean status { get; set; }

        public VideoLibrary()
        {
            sector_name = "";
            technology = "";
            video_url = "";
            status = false;

        }
    }

}